using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace BackEnd
{
    [Serializable] //för att kunna spara med Binary Serialization
    public class WareHouse
    {
        private decimal MaxWeight = 175000; //Maxvikt för warehouse
        private decimal CurrentWeight; //Nuvarande vikt för warehouse
        private decimal Floor1Weight; //Nuvarande vikt för våning 1
        private decimal Floor2Weight; //Nuvarande vikt för våning 2
        private decimal Floor3Weight; //Nuvarande vikt för våning 3
        private decimal[] stackWeight = new decimal[100]; //Sparar vikten för vånings "stackarna"

        WareHouseLocation[,] wareHouseLocation = new WareHouseLocation[3, 100]; //2D array som inehåller listor av hyllornas innehåll
        Dictionary<int, int> iDDic = new Dictionary<int, int>(); //sparar de olika unika ID numrerna

        public WareHouse() //konstruktor för WareHouse som skapar tomma WareHouseLocations i 2D arrayen när den WareHouse instansieras
        {
            for (int i = 0; i < wareHouseLocation.GetLength(0); i++)
            {
                for (int j = 0; j < wareHouseLocation.GetLength(1); j++)
                {
                    var temp = new WareHouseLocation();
                    wareHouseLocation[i, j] = temp;
                }
            }
        }

        //-----Add new Boxes-----
        public bool AddNewCubeBox(int iD, uint weight, bool isFragile,int insurance, decimal side, int floor, int row, out string result)
        {
            bool valid = false;
            
            if (!iDDic.ContainsKey(iD))  //kollar så att det id man skickar in inte redans finns i lagret
            {
                bool wareHouseWeight = false;
                bool floorWeight = false;
                

                BoxCreator boxCreator = new CubeBoxCreator(iD, weight, isFragile, insurance, side); //skapar en ny låda med in parametrarna
                I3DStorageObject boxes = boxCreator.CreateBox();
                

                Weight(); //kallar på weight metoden för att få viktinformation
                if (CurrentWeight + boxes.Weight <= MaxWeight) //kollar så att lådan inte får totalviken på warehouse att överskridas
                {
                    wareHouseWeight = true;
                    if (stackWeight[row] + boxes.Weight <= 2000) //kollar så att lådan inte får vånings "stacken" att överskridas
                    {
                        floorWeight = true;
                    }
                }
                
                if(wareHouseWeight == true & floorWeight == true) //om lådan inte överskrider nån vikt
                {
      
                    valid = wareHouseLocation[floor, row].AddNewBox(boxes); //lådan läggs till i arrayens lista och får tillbaka en bool om det gick eller inte
   
                    if (valid == true) //om det gick sparas lådans ID i dictionaryn
                    {
                        iDDic.Add(boxes.ID, 1);
                    }
                    result = wareHouseLocation[floor, row].ToString(); //en string retuneras med information om lådan
                }
                else //om lådan överskrider nån vikt, skickas ett felmeddelande
                {
                    throw new ArgumentException("The floor stack or the warehouse is full");
                }
            }
            else //om IDt redan används skickas ett felmeddelande
            {
                throw new ArgumentException("The Product ID is allready in use");
            }

            Weight(); //vikten för warehouse uppdateras
            return valid; //boolen retuneras
        } //Lägger till ny CubeBox på vald plats
        public bool AddNewCubeoidBox(int iD, uint weight, bool isFragile, int insurance, decimal xSide, decimal ySide, decimal zSide, int floor, int row, out string result)
        {
            bool valid = false;

            if (!iDDic.ContainsKey(iD)) //kollar så att det id man skickar in inte redans finns i lagret
            {
                bool wareHouseWeight = false;
                bool floorWeight = false;


                BoxCreator boxCreator = new CubeoidBoxCreator(iD, weight, isFragile, insurance, xSide,ySide,zSide); //skapar en ny låda med in parametrarna
                I3DStorageObject boxes = boxCreator.CreateBox(); 


                Weight(); //kallar på weight metoden för att få viktinformation
                if (CurrentWeight + boxes.Weight <= MaxWeight) //kollar så att lådan inte får totalviken på warehouse att överskridas
                {
                    wareHouseWeight = true;
                    if (stackWeight[row] + boxes.Weight <= 2000) //kollar så att lådan inte får vånings "stacken" att överskridas
                    {
                        floorWeight = true;
                    }
                }
             
                if (wareHouseWeight == true & floorWeight == true) //om lådan inte överskrider nån vikt
                {
  
                    valid = wareHouseLocation[floor, row].AddNewBox(boxes); //lådan läggs till i arrayens lista och får tillbaka en bool om det gick eller inte

                    if (valid == true) //om det gick sparas lådans ID i dictionaryn
                    {
                        iDDic.Add(boxes.ID, 1);
                    }
                    result = wareHouseLocation[floor, row].ToString(); //en string retuneras med information om lådan
                }
                else //om lådan överskrider nån vikt, skickas ett felmeddelande
                {
                    throw new ArgumentException("The floor or the warehouse is full");
                }
            }
            else //om IDt redan används skickas ett felmeddelande
            {
                throw new ArgumentException("The Product ID is allready in use");
            }

            Weight();
            return valid;
        } //Lägger till ny CubeoidBox på vald plats
        public bool AddNewSphereBox(int iD, uint weight, bool isFragile, int insurance, decimal radius, int floor, int row, out string result)
        {
            bool valid = false;

            if (!iDDic.ContainsKey(iD)) //kollar så att det id man skickar in inte redans finns i lagret
            {
                bool wareHouseWeight = false;
                bool floorWeight = false;


                BoxCreator boxCreator = new SphereBoxCreator(iD, weight, isFragile, insurance, radius); //skapar en ny låda med in parametrarna
                I3DStorageObject boxes = boxCreator.CreateBox();


                Weight(); //kallar på weight metoden för att få viktinformation
                if (CurrentWeight + boxes.Weight <= MaxWeight) //kollar så att lådan inte får totalviken på warehouse att överskridas
                {
                    wareHouseWeight = true;
                    if (stackWeight[row] + boxes.Weight <= 2000) //kollar så att lådan inte får vånings "stacken" att överskridas
                    {
                        floorWeight = true;
                    }
                }
       
                if (wareHouseWeight == true & floorWeight == true) //om lådan inte överskrider nån vikt
                {
   
                    valid = wareHouseLocation[floor, row].AddNewBox(boxes); //lådan läggs till i arrayens lista och får tillbaka en bool om det gick eller inte

                    if (valid == true) //om det gick sparas lådans ID i dictionaryn
                    {
                        iDDic.Add(boxes.ID, 1);
                    }
                    result = wareHouseLocation[floor, row].ToString(); //en string retuneras med information om lådan
                }
                else //om lådan överskrider nån vikt, skickas ett felmeddelande
                {
                    throw new ArgumentException("The floor or the warehouse is full");
                }
            }
            else //om IDt redan används skickas ett felmeddelande
            {
                throw new ArgumentException("The Product ID is allready in use");
            }

            Weight();
            return valid;
        } //Lägger till ny SphereBox på vald plats
        public bool AddNewBlobBox(int iD, uint weight, int insurance, decimal side, int floor, int row, out string result)
        {
            bool valid = false;

            if (!iDDic.ContainsKey(iD)) //kollar så att det id man skickar in inte redans finns i lagret
            {
                bool wareHouseWeight = false;
                bool floorWeight = false;


                BoxCreator boxCreator = new BlobBoxCreator(iD, weight, insurance, side); //skapar en ny låda med in parametrarna
                I3DStorageObject boxes = boxCreator.CreateBox();


                Weight(); //kallar på weight metoden för att få viktinformation
                if (CurrentWeight + boxes.Weight <= MaxWeight) //kollar så att lådan inte får totalviken på warehouse att överskridas
                {
                    wareHouseWeight = true;
                    if (stackWeight[row] + boxes.Weight <= 2000) //kollar så att lådan inte får vånings "stacken" att överskridas
                    {
                        floorWeight = true;
                    }
                }
             
                if (wareHouseWeight == true & floorWeight == true) //om lådan inte överskrider nån vikt
                {

                    valid = wareHouseLocation[floor, row].AddNewBox(boxes); //lådan läggs till i arrayens lista och får tillbaka en bool om det gick eller inte

                    if (valid == true) //om det gick sparas lådans ID i dictionaryn
                    {
                        iDDic.Add(boxes.ID, 1);
                    }
                    result = wareHouseLocation[floor, row].ToString(); //en string retuneras med information om lådan
                }
                else //om lådan överskrider nån vikt, skickas ett felmeddelande
                {
                    throw new ArgumentException("The floor or the warehouse is full");
                }
            }
            else //om IDt redan används skickas ett felmeddelande
            {
                throw new ArgumentException("The Product ID is allready in use");
            }

            Weight();
            return valid;
        } //Lägger till ny BlobBox på vald plats


        //-----Auto Add new Boxes-----
        public bool AutoAddNewCubeBox(int iD, uint weight, bool isFragile, int insurance, decimal side, out string result)
        {
            bool valid = false;
            
            BoxCreator boxCreator = null; //skapar en ny låda med in parametrarna
            boxCreator = new CubeBoxCreator(iD, weight, isFragile, insurance, side); 
            I3DStorageObject boxes = boxCreator.CreateBox();
            Weight();
            for (int i = 0; i < wareHouseLocation.GetLength(0); i++)
            {
                for(int j = 0; j < wareHouseLocation.GetLength(1); j++)
                {
                    if (!iDDic.ContainsKey(iD)) //kollar så att det id man skickar in inte redans finns i lagret
                    {
                        if((wareHouseLocation[i,j].CurrentWeigth + weight <= wareHouseLocation[i, j].MaxWeight) & (stackWeight[j] + boxes.Weight <= 2000)) //Kollar så att lådan int får totalvikten eller vånings "stacken" att överskridas"
                        {
                            if(wareHouseLocation[i,j].CurrentVolume + boxes.Volume <= wareHouseLocation[i, j].MaxVolume) //kollar så att lådans volym får plats på hyllan
                            {
                                if(boxes.MaxDimension <= wareHouseLocation[i,j].Width ^ boxes.MaxDimension <= wareHouseLocation[i, j].Depth ^ boxes.MaxDimension <= wareHouseLocation[i, j].Height) //kollar så att lådans största sida får plats på hyllan
                                {

                                    if (boxes.IsFragile == false & wareHouseLocation[i,j].ContainsFragile == false) //om lådan inte är fragile och det inte redan finns en fragile låda på hyllan
                                    {
                                        wareHouseLocation[i, j].AddNewBox(boxes); //lådan läggs till i hyllan (listan)
                                        iDDic.Add(iD, 1); //lådans ID sparas i dictionaryn
                                        result = $"{boxes.ID} was added on floor {i+1}, shelf {j + 1}"; //en string skickas tillbaka med information om vart den lagrades
                                        return valid; //retunerar true om det gick
                                    }
                                    if(boxes.IsFragile == true & wareHouseLocation[i,j].Lshelf.Count < 1 & wareHouseLocation[i, j].ContainsFragile == false) //om lådan är fragile och hyllan är tom och hyllan inte redan har en fragile
                                    {
                                        wareHouseLocation[i, j].AddNewBox(boxes); //lådan läggs till i hyllan (listan)
                                        iDDic.Add(iD, 1); //lådans ID sparas i dictionaryn
                                        result = $"{boxes.ID} was added on floor {i+1}, shelf {j + 1}"; //en string skickas tillbaka med information om vart den lagrades
                                        return valid; //retunerar true om det gick
                                    }
                                }
                            }
                        }
                    }
                }
            }
            result = "The box could not be added to Santa's WorkShop"; //om det inte gick att lägga till lådan retuneras denna string
            return valid; //retunerar false om det inte gick
        } //Lägger till en ny CubeBox på första lediga plats enligt satta regler
        public bool AutoAddNewCubeoidBox(int iD, uint weight, bool isFragile, int insurance, decimal xSide, decimal ySide, decimal zSide, out string result)
        {
            bool valid = false;
            
            BoxCreator boxCreator = null; //skapar en ny låda med in parametrarna
            boxCreator = new CubeoidBoxCreator(iD, weight, isFragile, insurance, xSide,ySide,zSide);
            I3DStorageObject boxes = boxCreator.CreateBox();
            Weight();
            for (int i = 0; i < wareHouseLocation.GetLength(0); i++)
            {
                for(int j = 0; j < wareHouseLocation.GetLength(1); j++)
                {
                    if (!iDDic.ContainsKey(iD)) //kollar så att det id man skickar in inte redans finns i lagret
                    {
                        if ((wareHouseLocation[i, j].CurrentWeigth + weight <= wareHouseLocation[i, j].MaxWeight) & (stackWeight[j] + boxes.Weight <= 2000)) //Kollar så att lådan int får totalvikten eller vånings "stacken" att överskridas"
                        {
                            if(wareHouseLocation[i,j].CurrentVolume + boxes.Volume <= wareHouseLocation[i, j].MaxVolume) //kollar så att lådans volym får plats på hyllan
                            {
                                if(boxes.MaxDimension <= wareHouseLocation[i,j].Width ^ boxes.MaxDimension <= wareHouseLocation[i, j].Depth ^ boxes.MaxDimension <= wareHouseLocation[i, j].Height) //kollar så att lådans största sida får plats på hyllan
                                {

                                    if (boxes.IsFragile == false & wareHouseLocation[i,j].ContainsFragile == false) //om lådan inte är fragile och det inte redan finns en fragile låda på hyllan
                                    {
                                        wareHouseLocation[i, j].AddNewBox(boxes); //lådan läggs till i hyllan (listan)
                                        iDDic.Add(iD, 1); //lådans ID sparas i dictionaryn
                                        result = $"{boxes.ID} was added on floor {+1}, shelf {j + 1}"; //en string skickas tillbaka med information om vart den lagrades
                                        return valid; //retunerar true om det gick
                                    }
                                    if(boxes.IsFragile == true & wareHouseLocation[i,j].Lshelf.Count < 1 & wareHouseLocation[i, j].ContainsFragile == false) //om lådan är fragile och hyllan är tom och hyllan inte redan har en fragile
                                    {
                                        wareHouseLocation[i, j].AddNewBox(boxes); //lådan läggs till i hyllan (listan)
                                        iDDic.Add(iD, 1); //lådans ID sparas i dictionaryn
                                        result = $"{boxes.ID} was added on floor {+1}, shelf {j + 1}"; //en string skickas tillbaka med information om vart den lagrades
                                        return valid; //retunerar true om det gick
                                    }
                                }
                            }
                        }
                    }
                }
            }
            result = "The box could not be added to Santa's WorkShop"; //om det inte gick att lägga till lådan retuneras denna string
            return valid; //retunerar false om det inte gick
        } //Lägger till en ny Cubeoid på första lediga plats enligt satta regler
        public bool AutoAddNewSphereBox(int iD, uint weight, bool isFragile, int insurance, decimal radius, out string result)
        {
            bool valid = false;

            BoxCreator boxCreator = null; //skapar en ny låda med in parametrarna
            boxCreator = new SphereBoxCreator(iD, weight, isFragile, insurance, radius);
            I3DStorageObject boxes = boxCreator.CreateBox();
            Weight();

            for (int i = 0; i < wareHouseLocation.GetLength(0); i++)
            {
                for (int j = 0; j < wareHouseLocation.GetLength(1); j++)
                {
                    if (!iDDic.ContainsKey(iD)) //kollar så att det id man skickar in inte redans finns i lagret
                    {
                        if ((wareHouseLocation[i, j].CurrentWeigth + weight <= wareHouseLocation[i, j].MaxWeight) & (stackWeight[j] + boxes.Weight <= 2000)) //Kollar så att lådan int får totalvikten eller vånings "stacken" att överskridas"
                        {
                            if (wareHouseLocation[i, j].CurrentVolume + boxes.Volume <= wareHouseLocation[i, j].MaxVolume) //kollar så att lådans volym får plats på hyllan
                            {
                                if (boxes.MaxDimension <= wareHouseLocation[i, j].Width ^ boxes.MaxDimension <= wareHouseLocation[i, j].Depth ^ boxes.MaxDimension <= wareHouseLocation[i, j].Height) //kollar så att lådans största sida får plats på hyllan
                                {

                                    if (boxes.IsFragile == false & wareHouseLocation[i, j].ContainsFragile == false) //om lådan inte är fragile och det inte redan finns en fragile låda på hyllan
                                    {
                                        wareHouseLocation[i, j].AddNewBox(boxes); //lådan läggs till i hyllan (listan)
                                        iDDic.Add(iD, 1); //lådans ID sparas i dictionaryn
                                        result = $"{boxes.ID} was added on floor {+1}, shelf {j + 1}";  //en string skickas tillbaka med information om vart den lagrades
                                        return valid; //retunerar true om det gick
                                    }
                                    if (boxes.IsFragile == true & wareHouseLocation[i, j].Lshelf.Count < 1 & wareHouseLocation[i, j].ContainsFragile == false) //om lådan är fragile och hyllan är tom och hyllan inte redan har en fragile
                                    {
                                        wareHouseLocation[i, j].AddNewBox(boxes); //lådan läggs till i hyllan (listan)
                                        iDDic.Add(iD, 1); //lådans ID sparas i dictionaryn
                                        result = $"{boxes.ID} was added on floor {+1}, shelf {j + 1}";  //en string skickas tillbaka med information om vart den lagrades
                                        return valid; //retunerar true om det gick
                                    }
                                }
                            }
                        }
                    }
                }
            }
            result = "The box could not be added to Santa's WorkShop"; //om det inte gick att lägga till lådan retuneras denna string
            return valid; //retunerar false om det inte gick
        } //Lägger till en ny Spherebox på första lediga plats enligt satta regler
        public bool AutoAddNewBlobBox(int iD, uint weight, int insurance, decimal side, out string result)
        {
            bool valid = false;
            Weight();
            BoxCreator boxCreator = null;
            boxCreator = new BlobBoxCreator(iD, weight, insurance, side);
            I3DStorageObject boxes = boxCreator.CreateBox();

            for (int i = 0; i < wareHouseLocation.GetLength(0); i++)
            {
                for (int j = 0; j < wareHouseLocation.GetLength(1); j++)
                {
                    if (!iDDic.ContainsKey(iD)) //kollar så att det id man skickar in inte redans finns i lagret
                    {
                        if ((wareHouseLocation[i, j].CurrentWeigth + weight <= wareHouseLocation[i, j].MaxWeight) & (stackWeight[j] + boxes.Weight <= 2000)) //Kollar så att lådan int får totalvikten eller vånings "stacken" att överskridas"
                        {
                            if (wareHouseLocation[i, j].CurrentVolume + boxes.Volume <= wareHouseLocation[i, j].MaxVolume) //kollar så att lådans volym får plats på hyllan
                            {
                                if (boxes.MaxDimension <= wareHouseLocation[i, j].Width ^ boxes.MaxDimension <= wareHouseLocation[i, j].Depth ^ boxes.MaxDimension <= wareHouseLocation[i, j].Height) //kollar så att lådans största sida får plats på hyllan
                                {

                                    if (boxes.IsFragile == false & wareHouseLocation[i, j].ContainsFragile == false) //om lådan inte är fragile och det inte redan finns en fragile låda på hyllan
                                    {
                                        wareHouseLocation[i, j].AddNewBox(boxes); //lådan läggs till i hyllan (listan)
                                        iDDic.Add(iD, 1); //lådans ID sparas i dictionaryn
                                        result = $"{boxes.ID} was added on floor {+1}, shelf {j + 1}"; //en string skickas tillbaka med information om vart den lagrades
                                        return valid; //retunerar true om det gick
                                    }
                                    if (boxes.IsFragile == true & wareHouseLocation[i, j].Lshelf.Count < 1 & wareHouseLocation[i, j].ContainsFragile == false) //om lådan är fragile och hyllan är tom och hyllan inte redan har en fragile
                                    {
                                        wareHouseLocation[i, j].AddNewBox(boxes); //lådan läggs till i hyllan (listan)
                                        iDDic.Add(iD, 1); //lådans ID sparas i dictionaryn
                                        result = $"{boxes.ID} was added on floor {+1}, shelf {j + 1}"; //en string skickas tillbaka med information om vart den lagrades
                                        return valid;  //retunerar true om det gick
                                    }
                                }
                            }
                        }
                    }
                }
            }
            result = "The box could not be added to Santa's WorkShop"; //om det inte gick att lägga till lådan retuneras denna string
            return valid;  //retunerar false om det inte gick
        } //Lägger till en ny BlobBox på första lediga plats enligt satta regler

        //-----Misc box actions-----
        public bool RetreiveBox(int iD, out I3DStorageObject outBox, out string result)
        {

            bool found = false;
            for (int i = 0; i < wareHouseLocation.GetLength(0); i++)
            {
                for (int j = 0; j < wareHouseLocation.GetLength(1); j++)
                {
                    foreach(var box in wareHouseLocation[i, j].Lshelf) //kollar igenom alla hyllor i WareHouse
                    {
                        if(box.ID == iD) //om lådans ID hittas
                        {
                            result = $"The box was found on floor {i + 1}, shelf {j + 1}.\nAnd is now removed from Santa's Workshop\n"; //en string retuneras med att lådan togs bort
                            outBox = box; //den hittade lådan sparas i ett nytt object
                            wareHouseLocation[i, j].RemoveBox(box); //skickar den nya lådan till RemoveBox Metoden i WareHouseLocation
                            iDDic.Remove(box.ID); //Tar bort lådans ID från dictionaryn

                            found = true;
                            Weight(); //vikten uppdateras
                            return found; //retunerar true
                        }
                    }
                }
            }
            Weight(); //vikten uppdateras
            result = "There was no match"; //string retuneras om det inte gick
            outBox = null; //temp lådan blir null
            return found; //retunerar false
        } //hämtar ut en låda med ID
        public bool MoveBox (int iD, int floor, int shelf, out string result)
        {
            bool found = false;
            for (int i = 0; i < wareHouseLocation.GetLength(0); i++)
            {
                for (int j = 0; j < wareHouseLocation.GetLength(1); j++)
                {

                    foreach (var box in wareHouseLocation[i,j].Lshelf) //loopar igenom alla hyllor i WareHouse
                    {
                        if(box.ID == iD) //om lådans ID hittas
                        {
                            I3DStorageObject temp = box; //en temp låda

                            Weight(); //uppdaterar vikten för WareHouse
                            
                            if (stackWeight[shelf] + box.Weight > 2000) //kollar så att lådan inte får vånings "stacken" att överskridas
                            {
                                throw new ArgumentException("The box could not be moved here as the floor would brake..."); //skickar felmeddelande om vikten överskrids
                            }
                            
                            found = wareHouseLocation[floor, shelf].AddNewBox(temp); //försöker lägger till lådan på den nya platesn
                                if (found == true) //om det gick
                                {
                                    wareHouseLocation[i, j].RemoveBox(temp); //tar bort lådan från den gamla platsen
                                   
                                    result = $"The box was found on floor {i + 1}, shelf {j + 1}!\nAnd was moved to floor {floor + 1}, shelf {shelf + 1}\nID: {temp.ID}, {temp.Description}"; //retunerar en string med information om förflyttningen
                                    Weight(); //uppdaterar WareHouse vikten
                                    return found; //retunerar true
                                }
                                else //om det inte gick att flytta lådan
                                {
                                    Weight(); //uppdaterar WareHouse vikten
                                    result = $"The Box could not be moved to that location"; //retunerar en string om att det inte gick att flytta lådan
                                }
                        }
                    }                      
                }
            }
            Weight(); //uppdaterar viken
            result = "There was no match"; //om lådan inte kunde hittas
            return found; //retunerar false
        } //Flyttar en låda med hjälp av ID till en ny position i WareHouse
        public bool FindBox(int iD, out string result)
        {
            bool found = false;
            for (int i = 0; i < wareHouseLocation.GetLength(0); i++)
            {
                for (int j = 0; j < wareHouseLocation.GetLength(1); j++)
                {
                    foreach (var box in wareHouseLocation[i, j].Lshelf) //loopar igenom alla hyllor i WareHouse
                    {
                        if (box.ID == iD) //om lådans ID hittas
                        {
                            
                            result = $"The box was found on floor {i + 1}, shelf {j + 1}.\n"; //retunerar en string med information om lådan
                            result += $"--ID: {box.ID}, Description: {box.Description}, Weight: {box.Weight}kg, Area: {box.Area}cm2, Volume: {box.Volume}cm3, Fragile: {box.IsFragile}, Insurance: {box.InsuranceValue.ToString("C")}\n";
                            found = true; 
                            return found; //retunerar true
                        }
                    }
                }
            }
            Weight(); //uppdaterar WareHouse vikten
            result = "There was no match"; //retunerar string om lådan inte hittades
            return found; //retunerar false
        } //Hittar en låda med ID
        public bool ChangeInsurance(int id, int value)
        {
            bool valid = false;
            for (int i = 0; i < wareHouseLocation.GetLength(0); i++)
            {
                for (int j = 0; j < wareHouseLocation.GetLength(1); j++)
                {
                    foreach (var box in wareHouseLocation[i, j].Lshelf) //loop som kollar alla hyllor
                    {
                        if (box.ID == id) //om lådans ID hittas
                        {
                            box.InsuranceValue = value; //lådans Insurance value uppdateras med inparametern
                            valid = true;
                            return valid; //retunerar true
                        }
                    }
                }
            }

            return valid; //retunerar false
        } //Byter Insurance value med hjälp av ID


        //-----Misc-----
        public string Weight()
        {
            Floor1Weight = 0;
            Floor2Weight = 0;
            Floor3Weight = 0;
            
            for (int i = 0; i < stackWeight.Length; i++) //nollställer vånings "stackernas" vikt
            {
                stackWeight[i] = 0;
            }

            for (int i = 0; i < wareHouseLocation.GetLength(1); i++)
            {
                for (int j = 0; j < wareHouseLocation.GetLength(0); j++)
                {
                    stackWeight[i] += wareHouseLocation[j, i].CurrentWeigth; //räknar ihop vånings "stackarnas" vikt
                }
            }

            for(int i = 0; i < wareHouseLocation.GetLength(0); i++)
            {
                for(int j = 0; j < wareHouseLocation.GetLength(1); j++)
                {
                    if(i == 0)
                    {
                        Floor1Weight += wareHouseLocation[i, j].CurrentWeigth; //räknar ut våning 1s vikt
                    }
                    if (i == 1)
                    {
                        Floor2Weight += wareHouseLocation[i, j].CurrentWeigth; //räknar ut våning 2s vikt
                    }
                    if (i == 2)
                    {
                        Floor3Weight += wareHouseLocation[i, j].CurrentWeigth; //räknar ut våning 3s vikt
                    }
                }
            }
            CurrentWeight = Floor1Weight + Floor2Weight + Floor3Weight; //warehouse nuvarande totalvikt
            string output = $"Floor 1: {(Floor1Weight)}/100000 kg, Floor 2: {(Floor2Weight)}/100000 kg, Floor 3: {(Floor3Weight)}/100000 kg, Total: {(CurrentWeight)}/175000 kg"; //string om warehouse vikt information
            return output; //retunerar string om warehouse vikt information
        } //metod för att räkna vikt i warehouse
        public string Print()
        {
            var a = new StringBuilder();
            a.Append("\n\n");


            for(int i = 0; i < wareHouseLocation.GetLength(0); i++)
            {
                a.Append("\n------------------------------------------------------------------Floor " + (i + 1) + "------------------------------------------------------------------\n"); //skriver ut vilken våning
                for (int j = 0; j < wareHouseLocation.GetLength(1); j++)
                {
                    if(wareHouseLocation[i,j].Lshelf.Count > 0)
                    {
                        a.Append($"\n\n________________________________________Shelf {(j + 1)} | [Weight: {wareHouseLocation[i,j].CurrentWeigth}/{wareHouseLocation[i,j].MaxWeight} kg]\t [Volume: {(wareHouseLocation[i,j].CurrentVolume).ToString("F")}/{(wareHouseLocation[i,j].MaxVolume).ToString("F")} m3]________________________________________\n\n"); //skriver ut vilken hyllplats
                        foreach (var box in wareHouseLocation[i, j].Lshelf)
                        {
                            a.Append("ID: " + box.ID.ToString().PadRight(5, ' '));
                            a.Append("Description: " + box.Description.ToString().PadRight(15, ' '));
                            a.Append("MaxDimention: " + box.MaxDimension.ToString().PadRight(5, ' '));
                            a.Append("Weight: " + box.Weight.ToString().PadRight(5, ' '));
                            a.Append("Area: " + box.Area.ToString().PadRight(5, ' '));
                            a.Append("Volume: " + box.Volume.ToString().PadRight(5, ' '));
                            a.Append("Is Fragile: " + box.IsFragile.ToString().PadRight(5, ' '));
                            a.Append("Insurance: " + box.InsuranceValue.ToString().PadRight(5, ' '));


                            //a.Append($"--[ID: {box.ID}]  \t[Description: {box.Description}]  \t[MaxDimension: {box.MaxDimension} cm]  \t[Weight: {box.Weight} kg]  \t[Area: {box.Area.ToString("F")} m2]  \t[Volume: {box.Volume.ToString("F")} m3]  \t[Fragile: {box.IsFragile}]  \t[Insurance: {box.InsuranceValue.ToString("C")}]\n"); //skriver ut information om lådan
                        }
                    }
                    
                }
                a.Append("\n\n");
            }
            return a.ToString(); //retunerar stringbuilder som en string
        } //metod för att skriva ut information om warehouse
        public List<I3DStorageObject> this[int index, int index2] //index som retunerar en klon av en specifik lagerplats
        {
            get => Clone(index, index2); //retunerar en klon på specifik lagerplats med hälp av inparametrarna
        }

        public List<I3DStorageObject> Clone(int i, int j) //metod som får en klon av specifik lagerplatsen och retunerar den
        {
            List<I3DStorageObject> clone = wareHouseLocation[i, j].Content(); //skapar en ny lista som är en klon av specifik lagerplats lista
            return clone;
        }
    }
}
