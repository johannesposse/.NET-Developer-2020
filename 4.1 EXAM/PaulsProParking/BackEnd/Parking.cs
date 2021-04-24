using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BackEnd
{
    public class Parking
    {
        static List<Vehicle> vehicles = new List<Vehicle>(); //lista med de fordon som finns parkerade
        static List<string> infoMessages = new List<string>(); //lista med informationsmeddelanden
        static readonly string conStr = "Data Source=.\\sqlexpress; Database=PPDBJohannesPosse; Integrated Security = true"; //string för att ansluta till databasen

        public void ReadFromDataBase() //metod för att hämta data från databasen och skapa fordonsobjekt
        {
            string cmdText = "GetParkedVehicleInfo"; //kallar på sp i databasen
            vehicles.Clear(); //tömmer listan av forodn

            SqlConnection con = new SqlConnection(); 
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;

            con.ConnectionString = conStr;
            cmd.CommandText = cmdText;
            cmd.Connection = con;
            using (con)
            {
                try
                {
                    con.Open();
                    rdr = cmd.ExecuteReader(); //startar sql kommandot

                    using (rdr)
                    {
                        while (rdr.Read())
                        {
                            Vehicle temp = new Vehicle((int)rdr[0], (string)rdr[1], (int)rdr[2], (DateTime)rdr[3], (int)rdr[4], (int)rdr[5]); //skapar nytt fordon med datan från databasen
                            vehicles.Add(temp); //stoppar in fordonet i fordonslitan
                        }
                    }
                }
                catch (Exception x) //fåntar fel
                {
                    throw new Exception(x.Message);
                }
            }

        }


        public string AddToDataBase(string regNr, int vehicleType) //metod för att lägga till fordon i databasen
        {
            string result = "";

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = conStr;

            SqlParameter parRegNr = new SqlParameter //skapar in/ut parametrar till sql kommandot med de mottagna värdena
            {
                ParameterName = "@RegNr",
                SqlDbType = System.Data.SqlDbType.NVarChar, //väljer variabel typ
                Value = regNr, //sätter värdet på parametern
                Direction = System.Data.ParameterDirection.Input //sätter vilket håll parametern ska gå

            };
            SqlParameter parVehicleType = new SqlParameter
            {
                ParameterName = "@VehicleType",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = vehicleType,
                Direction = System.Data.ParameterDirection.Input

            };
            SqlParameter parParkingSlotOut = new SqlParameter
            {
                ParameterName = "@parkingSlotOut",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output

            };

            cmd.Parameters.Add(parVehicleType); //lägger till parametrarna 
            cmd.Parameters.Add(parRegNr);
            cmd.Parameters.Add(parParkingSlotOut);

            using (con)
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction(); //startar transaktionen

                try
                {   //sql kommandot som lägger till fordonet i databasen
                    cmd.CommandText = 
                        "DECLARE @firstAvailableSpot int; " +
                        "DECLARE @VehicleID int; " +
                        "IF(@VehicleType = 2) " +
                        "BEGIN " +
                        "SET @firstAvailableSpot = (Select TOP(1) ParkingSpaceID From ParkingSpace WHERE Size = 0) " +
                        "END " +
                        "IF (@VehicleType = 1) " +
                        "BEGIN " +
                        "SET @firstAvailableSpot = (Select TOP(1) ParkingSpaceID From ParkingSpace WHERE Size = 1 OR Size = 0) " +
                        "END " +
                        "INSERT INTO Vehicle(RegNr,VehicleType) " +
                        "VALUES(@RegNr,@vehicleType) " +
                        "SET @VehicleID = (SELECT VehicleID FROM Vehicle WHERE RegNr = @RegNr) " +
                        "INSERT INTO ParkedVehicles(VehicleID,ParkingSpaceID,Size) " +
                        "VALUES(@VehicleID,@firstAvailableSpot,@vehicleType) " +
                        "SET @parkingSlotOut = @firstAvailableSpot ";

                    cmd.Connection = con;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery(); //utför sql kommandot
                    transaction.Commit(); //gick allt utan fel så färdigställs transaktionen
                    result = regNr + " was parked on " + parParkingSlotOut.Value.ToString(); //skapar en string med ut parametern
                }
                catch (Exception x) //fångar möjliga fel
                {
                    transaction.Rollback(); //återställer transaktionen
                    throw new Exception(x.Message);
                }
            }

            return result; 
        }

        public string RemoveFromDataBase(string regNr) //metod för att ta bort fordon från databasen
        {
            string result = "";

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = conStr;

            SqlParameter parRegNr = new SqlParameter //skapar in/ut parametrar till sql kommandot med de mottagna värdena
            {
                ParameterName = "@RegNr",
                SqlDbType = System.Data.SqlDbType.NVarChar, //väljer variabel typ
                Value = regNr, //sätter värdet på parametern
                Direction = System.Data.ParameterDirection.Input //sätter vilket håll parametern ska gå

            };

            SqlParameter parParkingSlotOut = new SqlParameter
            {
                ParameterName = "@parkingSlotOut",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output

            };


            cmd.Parameters.Add(parRegNr); //lägger till parametrarna 
            cmd.Parameters.Add(parParkingSlotOut);

            using (con)
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();  //startar transaktionen

                try
                {   //sql kommandot som lägger till fordonet i databasen
                    cmd.CommandText =
                        "DECLARE @VehicleID int " +
                        "SET @VehicleID = (SELECT VehicleID FROM Vehicle WHERE RegNr = @RegNr) " +
                        "SET @parkingSlotOut = (Select pv.ParkingSpaceID FROM ParkedVehicles pv JOIN Vehicle v ON pv.VehicleID =v.VehicleID WHERE v.RegNr = @RegNr) " +
                        "IF(@VehicleID IS NULL) " +
                        "BEGIN " +
                        "RAISERROR('Vehicle not found',18,1) " +
                        "END " +
                        "DELETE FROM ParkedVehicles " +
                        "WHERE VehicleID = @VehicleID ";

                    cmd.Connection = con;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery(); //utför sql kommandot
                    transaction.Commit(); //gick allt utan fel så färdigställs transaktionen
                    result = regNr + " was retreived from " + parParkingSlotOut.Value.ToString(); //skapar en string med ut parametern
                }
                catch (Exception x) //fångar möjliga fel
                {
                    transaction.Rollback();
                    result = "";
                    throw new Exception(x.Message);
                }
            }

            return result;
        }

        public string SearchRegNr(string regNr) //metod för att hitta fordon i databasen med regnr
        {
            string result = "";

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;

            con.ConnectionString = conStr;

            SqlParameter parRegNr = new SqlParameter //skapar in parametrar till sql kommandot med de mottagna värdena
            {
                ParameterName = "@RegNr",
                SqlDbType = System.Data.SqlDbType.NVarChar, //väljer variabel typ
                Value = regNr, //sätter värdet på parametern
                Direction = System.Data.ParameterDirection.Input //sätter vilket håll parametern ska gå

            };

            cmd.Parameters.Add(parRegNr); //lägger till parametrarna 

            using (con)
            {
                con.Open();
                try
                {   //sql kommandot som ska hitta fordonet
                    cmd.CommandText =
                        "SELECT pv.ParkingSpaceID, v.RegNr, v.ParkedTime,v.CurrentParkedTime, v.ParkingFee " +
                        "FROM Vehicle v " +
                        "JOIN ParkedVehicles pv ON " +
                        "v.VehicleID = pv.VehicleID " +
                        "WHERE v.RegNr = @RegNr ";


                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader(); //utför sql kommandot

                    while (rdr.Read())
                    {
                        result = $"Parking Slot: {rdr[0]}, RegNr: {rdr[1]}, Parked at: {rdr[2]}, Parked Time: {rdr[3]}min, Parking Fee: {rdr[4]}kr "; //tar emot information  från databasen till en string
                    }
                }
                catch (Exception x) //fångar möjliga fel
                {
                    throw new Exception(x.Message);
                }
            }
            if (result.Length < 1) //om inget fordon hittades
            {
                result = "The vehicle was not found";
            }
            return result;
        }

        public string SearchParkingSlot(int parkingSlot) //metod för att hitta fordon i databasen med parkeringsruta
        {
            string result = "";

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;

            con.ConnectionString = conStr;

            SqlParameter parParkingSlot = new SqlParameter //skapar in parametrar till sql kommandot med de mottagna värdena
            {
                ParameterName = "@ParkingSlot",
                SqlDbType = System.Data.SqlDbType.NVarChar, //väljer variabel typ
                Value = parkingSlot, //sätter värdet på parametern
                Direction = System.Data.ParameterDirection.Input //sätter vilket håll parametern ska gå

            };

            cmd.Parameters.Add(parParkingSlot); //lägger till parametrarna 

            using (con)
            {
                con.Open();
                try
                {   //sql kommandot som ska hitta fordonet
                    cmd.CommandText =
                        "SELECT pv.ParkingSpaceID, v.RegNr, v.ParkedTime,v.CurrentParkedTime, v.ParkingFee " +
                        "FROM Vehicle v " +
                        "JOIN ParkedVehicles pv ON " +
                        "v.VehicleID = pv.VehicleID " +
                        "WHERE pv.ParkingSpaceID = @ParkingSlot";


                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader(); //utför sql kommandot

                    while (rdr.Read())
                    {
                        result += $"Parking Slot: {rdr[0]}, RegNr: {rdr[1]}, Parked at:{rdr[2]}, Parked Time: {rdr[3]}min, Parking Fee: {rdr[4]}kr\n"; //tar emot information  från databasen till en string
                    }
                }
                catch (Exception x) //fångar möjliga fel
                {
                    throw new Exception(x.Message);
                }
            }
            if (result.Length < 1) //om parkeringsplatsen var tom eller om den inte fanns
            {
                result = "The parking slot was empty or don't exist";
            }
            return result;


        }

        public string MoveVehicle(string regNr, int parkingSlot) //metod för att flytta fordon i databasen
        {
            string result = "";

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = conStr;

            SqlParameter parRegNr = new SqlParameter //skapar in/ut parametrar till sql kommandot med de mottagna värdena
            {
                ParameterName = "@RegNr",
                SqlDbType = System.Data.SqlDbType.NVarChar, //väljer variabel typ
                Value = regNr, //sätter värdet på parametern
                Direction = System.Data.ParameterDirection.Input //sätter vilket håll parametern ska gå

            };
            SqlParameter parParkingSlot = new SqlParameter
            {
                ParameterName = "@ParkingSlot",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = parkingSlot,
                Direction = System.Data.ParameterDirection.Input

            };

            SqlParameter parParkingSlotOut = new SqlParameter
            {
                ParameterName = "@parkingSlotOut",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output

            };

            cmd.Parameters.Add(parRegNr); //lägger till parametrarna 
            cmd.Parameters.Add(parParkingSlot);
            cmd.Parameters.Add(parParkingSlotOut);

            using (con)
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction(); //startar transaktionen

                try
                {   //sql kommandot flyttar fordonet i databasen
                    cmd.CommandText =
                        "DECLARE @VehicleID int " +
                        "SET @VehicleID = (SELECT VehicleID FROM Vehicle WHERE RegNr = @RegNr) " +
                        "IF(@VehicleID IS NULL) " +
                        "BEGIN " +
                        "RAISERROR('Vehicle not found',18,1) " +
                        "END " +
                        "UPDATE ParkedVehicles " +
                        "SET ParkingSpaceID = @ParkingSlot " +
                        "WHERE VehicleID = @VehicleID " +
                        "SET @parkingSlotOut = @ParkingSlot ";


                    cmd.Connection = con;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery(); //utför sql kommandot
                    transaction.Commit(); //gick allt utan fel så färdigställs transaktionen
                    result = regNr + " was moved to parking slot " + parParkingSlotOut.Value.ToString(); //skapar en string med ut parametern
                }
                catch (Exception x) //fångar möjliga fel
                {
                    transaction.Rollback(); //återställer transaktionen
                    throw new Exception(x.Message);
                }
            }


            return result;
        }

        public string OptimizeMcParking() //metod för att optimisera mc parkeringsplatser i databasen
        {
            string result = "";

            var test = new StringBuilder();

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = conStr;
            con.InfoMessage += new SqlInfoMessageEventHandler(con_InfoMessage); //tar emot info meddelanden från databasen

            using (con)
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction(); //startar transaktionen

                try
                {
                    //sql kommandot för att optimisera mc parkeringsplatser i databasen
                    cmd.CommandText =
                        "DECLARE mcCursor CURSOR READ_ONLY FOR SELECT v.VehicleID, v.RegNr FROM Vehicle v " +
                        "JOIN ParkedVehicles pv ON " +
                        "v.VehicleID = pv.VehicleID " +
                        "JOIN ParkingSpace ps ON " +
                        "pv.ParkingSpaceID = ps.ParkingSpaceID " +
                        "WHERE v.VehicleType = 1 AND ps.Size < 2 " +
                        "DECLARE @VehicleID int " +
                        "DECLARE @RegNr nvarchar(10) " +
                        "DECLARE @firstAvailableSpot int " +
                        "DECLARE @fromParkingSlot int " +
                        "DECLARE @McCount int " +
                        "SET @McCount = 0 " +
                        "OPEN mcCursor " +
                        "FETCH NEXT FROM mcCursor INTO @VehicleID, @RegNr " +
                        "WHILE @@FETCH_STATUS = 0 " +
                        "BEGIN " +
                        "SET @firstAvailableSpot = (Select TOP(1) ParkingSpaceID From ParkingSpace WHERE Size = 1 OR Size = 0) " +
                        "SET @fromParkingSlot = (SELECT ParkingSpaceID FROM ParkedVehicles WHERE VehicleID = @VehicleID) " +
                        "UPDATE ParkedVehicles " +
                        "SET ParkingSpaceID = @firstAvailableSpot " +
                        "WHERE VehicleID = @VehicleID " +
                        "IF(@fromParkingSlot != @firstAvailableSpot) " +
                        "BEGIN " +
                        "PRINT @Regnr + ' was moved from ' + CAST(@fromParkingSlot AS nvarchar(3)) + ' to ' + CAST(@firstAvailableSpot AS nvarchar(3)) " +
                        "SET @McCount = @McCount + 1 " +
                        "END " +
                        "FETCH NEXT FROM mcCursor INTO @VehicleID, @RegNr " +
                        "END " +
                        "CLOSE mcCursor " +
                        "DEALLOCATE mcCursor " +
                        "IF(@McCount < 1) " +
                        "BEGIN " +
                        "PRINT 'Parkinglot is already optimized' " +
                        "END ";


                 

                    cmd.Connection = con;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery(); //utför sql kommandot
                    transaction.Commit(); //gick allt utan fel så färdigställs transaktionen
                    result = InfoMessage(""); //får infomeddelanden från databasen


                }
                catch (Exception x) //fångar möjliga fel
                {
                    transaction.Rollback(); //återställer transaktionen
                    throw new Exception(x.Message);
                }
            }

            return result;
        }

        public string GetMc() //metod för att få alla motorcyklar från databasen
        {
            StringBuilder result = new StringBuilder();

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;

            con.ConnectionString = conStr;
            //sql kommandot som ska hitta alla mc
            cmd.CommandText =
                "SELECT pv.ParkingSpaceID, v.RegNr, v.VehicleType, v.ParkedTime, v.ParkingFee FROM Vehicle v " +
                "JOIN ParkedVehicles pv " +
                "ON v.VehicleID = pv.VehicleID " +
                "WHERE v.VehicleType = 1 " +
                "ORDER BY pv.ParkingSpaceID ASC ";

            cmd.Connection = con;
            using (con)
            {
                try
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();  //utför sql kommandot

                    using (rdr)
                    {
                        while (rdr.Read()) //tar emot information  från databasen till en string
                        {
                            result.Append("ParkingSpace: " + rdr[0]);
                            result.Append(", RegNr: " + rdr[1]);
                            
                            if((int)rdr[2] == 1) //kollar typ av fordon
                            {
                                result.Append(", VehicleType: MC");
                            }
                            result.Append(", ParkedTime: " + rdr[3]);
                            result.Append(", ParkingFee: " + rdr[4] + "\n");

                        }
                    }
                }
                catch (Exception x) //fångar möjliga fel
                {
                    throw new Exception(x.Message);
                }
            }

            return result.ToString();
        }

        public void con_InfoMessage(object sender, SqlInfoMessageEventArgs e) //metod för att ta emot infomeddelanden från databasen
        {
            StringBuilder info = new StringBuilder();
            info.Clear();
            info.AppendLine(e.Message); //lägger till meddelandet
            InfoMessage(info.ToString()); //skickar meddelandet till InfoMessageMetoden
        }

        public string InfoMessage(string input) //metod för att hämta ut det senaste meddelandet som togs emot från databasen
        {
            if (input.Length > 1) //om meddelandet som togs emot var längre än 1 läggs det till i en lista
            {
                infoMessages.Add(input);
            }

            string result = infoMessages[infoMessages.Count - 1]; //tar ut det senaste meddelandet från listan
            return result;
        }

        public int PrintRemovedVehicle(string regNr, int forFree, out string info) //metod som hämtar ut det senaste borttagna fordonet, och väljer om avgiften ska vara gratis eller inte
        {
            string cmdText = "ReturnRemovedVehicleInfo"; //sql sp kommandot som ska hitta det senaste borttagna fordonet
            var rowsAffected = 0;
            info = "";

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;


            con.ConnectionString = conStr;
            cmd.CommandText = cmdText;
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure; //sätter att det ska vara en sp

            SqlParameter parRegNr = new SqlParameter //skapar in parametrar till sql kommandot med de mottagna värdena
            {
                ParameterName = "@RegNr", 
                SqlDbType = System.Data.SqlDbType.NVarChar, //väljer variabel typ
                Value = regNr, //sätter värdet på parametern
                Direction = System.Data.ParameterDirection.Input //sätter vilket håll parametern ska gå

            };

            SqlParameter parForFree = new SqlParameter
            {
                ParameterName = "@ForFree",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Value = forFree,
                Direction = System.Data.ParameterDirection.Input

            };

            cmd.Parameters.Add(parRegNr); //lägger till parametrarna
            cmd.Parameters.Add(parForFree);

            using (con)
            {
                try
                {
                    con.Open();
                    rdr = cmd.ExecuteReader(); //utför sql kommandot
                    rowsAffected = rdr.RecordsAffected; //får tillbaka hur många rader som påverkades från databasen
                    while (rdr.Read())
                    {
                        info = "RegNr: " + rdr[0] + ", Parked At Time: " + rdr[1] + ", Retreived At Time: " + rdr[2] + ", Parkedtime: " + rdr[3] + "min , Parkingfee: " + rdr[4] + "kr"; //tar emot information  från databasen till en string
                    }
                }
                catch (Exception x) //fångar möjliga fel
                {
                    throw new Exception(x.Message);
                }
            }

            return rowsAffected;
        }

        public string MoreThan48h() //metod för att hämta fordon som vart parkerade mer än 48h
        {
            string result = "";

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;

            con.ConnectionString = conStr;


            using (con)
            {
                con.Open();
                try
                {
                    cmd.CommandText = "SELECT * FROM v_ParkedMoreThan48h"; //sql kommandot som ska hitta fordonen

                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader(); //utför sql kommandot

                    while (rdr.Read()) //tar emot information  från databasen till en string
                    {
                        result +=  $"RegNr: {rdr[0]}, ParkedTime: {rdr[1]}, ";
                        if(rdr[2].ToString() == "")
                        {
                            result += $"Retreived: Not retreived\n";
                        }
                        else
                        {
                            result += $"Retreived: { rdr[2]}\n";
                        }
                    }
                }
                catch (Exception x) //fångar möjliga fel
                {
                    throw new Exception(x.Message);
                }
            }
            if (result.Length < 1)  //om inga fordon hittades
            {
                result = "The were no vehicles parked for more than 48h";
            }



            return result;
        }

        public string RemoveAllVehicles() //metod för att ta bort alla parkerade fordon från databasen
        {
            string result = "";

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = conStr;


            using (con)
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction(); //startar transaktionen

                try
                {   //sql kommandot som lägger tar bort alla parkerade fordon från databasen
                    cmd.CommandText = "DELETE FROM ParkedVehicles " +
                        "UPDATE ParkingSpace " +
                        "SET Size = 0 ";

                    cmd.Connection = con;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery(); //utför sql kommandot
                    transaction.Commit(); //gick allt utan fel så färdigställs transaktionen
                    result = "All vehicles was removed from the parking lot";
                }
                catch (Exception x) //fångar möjliga fel
                {
                    transaction.Rollback();  //återställer transaktionen
                    result = "Something went wrong";
                    throw new Exception(x.Message);
                }
            }

            return result;
        }

        public string ShowHistory() //metod för att hämta ut de fordon som vart parkerade på parkeringsplatsen
        {
            StringBuilder result = new StringBuilder();

            //sql kommandot för att hämta ut de fordon som vart parkerade på parkeringsplatsen
            string cmdText = "SELECT Parkingspace, RegNr, VehicleType, ParkedTime, RetreiveTime, ParkingFee FROM ParkingLog " +
                             "ORDER BY Parkingspace ASC ";
      

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;

            con.ConnectionString = conStr;
            cmd.CommandText = cmdText;
            cmd.Connection = con;
            using (con)
            {
                try
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();  //utför sql kommandot

                    using (rdr)
                    {
                        while (rdr.Read()) //tar emot information  från databasen till en string
                        {
                            result.Append("ParkingSpace: " + rdr[0]);
                            result.Append(", RegNr: " + rdr[1]);

                            if ((int)rdr[2] == 1)
                            {
                                result.Append(", VehicleType: MC");
                            }else if ((int)rdr[2] == 2)
                            {
                                result.Append(", VehicleType: Car");
                            }
                            result.Append(", ParkedTime: " + rdr[3]);
                            result.Append(", RetreivedTime: " + rdr[4]);
                            result.Append(", ParkingFee: " + rdr[5] + "\n");

                        }
                    }
                }
                catch (Exception x) //fångar möjliga fel
                {
                    throw new Exception(x.Message);
                }
            }

            return result.ToString();

        }

        public string ShowEmptyParkingSpots() //metod för att hämta ut de parkeringsplatser som är tomma
        {
            string result = "";
            int count = 1;

            string cmdText = "SELECT * FROM empty_parking_slots "; //sql kommandot som ska hitta  de parkeringsplatser som är tomma

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;

            con.ConnectionString = conStr;
            cmd.CommandText = cmdText;
            cmd.Connection = con;
            using (con)
            {
                try
                {
                    con.Open();
                    rdr = cmd.ExecuteReader();  //utför sql kommandot

                    using (rdr)
                    {
                        while (rdr.Read()) //tar emot information  från databasen till en string
                        {
                            result += "["+rdr[0]+"],";

                            if(count % 10 == 0)
                            {
                                result += "\n";
                            }
                            count++;
                        }
                    }
                }
                catch (Exception x) //fångar möjliga fel
                {
                    throw new Exception(x.Message);
                }
            }

            if (result.Length < 1) //om inga parkeringsplatser retunerades
                result = "Pauls Pro Parking is full...";

            return result;
        }

        public string ShowIncomePerDay() //metod för att hämta ut inkomst per dag
        {
            string result = "";

            DateTime temp;

            string cmdText = "SELECT * FROM v_ShowIncomePerDay "; //sql kommandot som ska hämta ut inkomst per dag viewn

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = null;

            con.ConnectionString = conStr;
            cmd.CommandText = cmdText;
            cmd.Connection = con;
            using (con)
            {
                try
                {
                    con.Open();
                    rdr = cmd.ExecuteReader(); //utför sql kommandot

                    using (rdr)
                    {
                        while (rdr.Read()) //tar emot information  från databasen till en string
                        {
                            temp = (DateTime)rdr[0];
                            result += temp.ToString("yyyy:MM:dd") + " => " + rdr[1] +"kr\n";
                        }
                    }
                }
                catch (Exception x) //fångar möjliga fel
                {
                    throw new Exception(x.Message);
                }
            }

            if (result.Length < 1) //om ingen inkomst hittades
                result = "There is no income to show";


            return result;

        }

        public string ShowIncomeIntervall(string start, string end) //metod för att hämta inkomst för en specifik dag eller ett intervall
        {
            string result = "";

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            con.ConnectionString = conStr;

            SqlParameter parStartDate = new SqlParameter //skapar in parametrar till sql kommandot med de mottagna värdena
            {
                ParameterName = "@StartDate",
                SqlDbType = System.Data.SqlDbType.Date, //väljer variabel typ
                Value = start, //sätter värdet på parametern
                Direction = System.Data.ParameterDirection.Input //sätter vilket håll parametern ska gå

            };

            SqlParameter parEndDate = new SqlParameter
            {
                ParameterName = "@EndDate",
                SqlDbType = System.Data.SqlDbType.Date,
                Value = end,
                Direction = System.Data.ParameterDirection.Input

            };

            

            cmd.Parameters.Add(parStartDate); //lägger till parametrarna 
            cmd.Parameters.Add(parEndDate);
            cmd.CommandType = System.Data.CommandType.StoredProcedure; //väljer att det ska vara en sp

            SqlDataReader rdr = null;

            using (con)
            {
                con.Open();
                

                try
                {
                    cmd.CommandText = "sp_GetIncomeInterval"; //sql spn som ska hämta informationen

                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader(); //utför sql kommandot

                    while (rdr.Read()) //tar emot information  från databasen till en string
                    {
                        DateTime temp;

                        if (rdr.FieldCount == 2)
                        {
                            temp = (DateTime)rdr[0];
                            result += "Date: "+ temp.ToString("yyyy:MM:dd") + ", Income: " + rdr[1] + "kr\n";
                        }
                        if (rdr.FieldCount == 3)
                        {
                            temp = (DateTime)rdr[0];
                            result +="Date: "+ temp.ToString("yyyy:MM:dd") + ", Income: " + rdr[1] + "kr, Average Income/Day: " + rdr[2] +"kr\n";
                        }
                    }
                }
                catch (Exception x) //fångar möjliga fel
                {
                    result = "";
                    throw new Exception(x.Message);
                }
            }


            return result;
        }

        public string Print() //metod för att visa alla parkeringsplatser och de fordon som är parkerade
        {
            ReadFromDataBase(); //läser in fordonen från databasen

            int counter = 1;
            bool found = false;
            string vehicleType = "";
            int lengt = 0;

            StringBuilder print = new StringBuilder();

            Dictionary<string, int> foundRegNr = new Dictionary<string, int>(); //en dictionary för att hålla koll på vilka fordon som skrivits ut



            print.Append(string.Concat(Enumerable.Repeat("=", 200)));
            print.Append("\n");

            for (int i = 1; i <= 20; i++) //för att kunna skriva ut samma parkeringsplats på två raden
            {
                if (i == 2)
                    counter = 1;
                if (i == 3)
                    counter = 11;
                if (i == 4)
                    counter = 11;
                if (i == 5)
                    counter = 21;
                if (i == 6)
                    counter = 21;
                if (i == 7)
                    counter = 31;
                if (i == 8)
                    counter = 31;
                if (i == 9)
                    counter = 41;
                if (i == 10)
                    counter = 41;
                if (i == 11)
                    counter = 51;
                if (i == 12)
                    counter = 51;
                if (i == 13)
                    counter = 61;
                if (i == 14)
                    counter = 61;
                if (i == 15)
                    counter = 71;
                if (i == 16)
                    counter = 71;
                if (i == 17)
                    counter = 81;
                if (i == 18)
                    counter = 81;
                if (i == 19)
                    counter = 91;
                if (i == 20)
                    counter = 91;

                for (int j = 1; j <= 10; j++)
                {
                    found = false;

                    for (int k = 0; k < vehicles.Count; k++)
                    {
                        if (vehicles[k].ParkingSlot == counter & !foundRegNr.ContainsKey(vehicles[k].RegNr)) //om fordonet står på parkeringsplatsen och det inte redan är utskrivet
                        {
                            if(vehicles[k].VehicleType == 1) //om det är en MC
                            {
                                vehicleType = "MC";
                                lengt = (18 - (2 + vehicles[k].RegNr.ToString().Length)) / 2; //för att kunna centrera utskriften
                            }
                            else if (vehicles[k].VehicleType == 2) //om det är en bil
                            {
                                vehicleType = "Car";
                                lengt = (18 - (3 + vehicles[k].RegNr.ToString().Length)) / 2; //för att kunna centrera utskriften
                            }
                            if(lengt % 2 == 1) //om regnr är ojämt långt
                            {
                                print.Append("|".PadRight(lengt+1) + counter.ToString() + "." + vehicles[k].RegNr + "/" + vehicleType + "|".PadLeft(lengt-1)); //skriver ut fordonet och parkeringsplatsen
                            }
                            else //om regnr är jämt långt
                            {
                                print.Append("|".PadRight(lengt) + counter.ToString() + "." + vehicles[k].RegNr + "/" + vehicleType + "|".PadLeft(lengt)); //skriver ut fordonet och parkeringsplatsen
                            }
                            
                            foundRegNr.Add(vehicles[k].RegNr, 1); //lägger till registreringsnummret i dictionaryn
                            found = true;
                            break;
                        }
                    }
                    if(found == false) //om det inte fanns något fordon på den parkeringsplasen
                    {
                        print.Append("|" + counter.ToString().PadLeft(11).PadRight(18) + "|");
                    }

                    counter++;
                }

                if (i % 2 == 0 & i != 0 & i != 20) //för att skriva ut en separerande linje
                {
                    print.Append("\n");
                    print.Append(string.Concat(Enumerable.Repeat("-", 200)));
                    print.Append("\n");
                }
                else
                {
                    print.Append("\n");
                }
            }

            print.Append(string.Concat(Enumerable.Repeat("=", 200)));
            

            return print.ToString();
        }
    }
}
