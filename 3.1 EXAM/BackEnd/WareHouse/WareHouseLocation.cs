using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace BackEnd
{
    [Serializable] //för att kunna spara filen med Binary Serialization
    internal class WareHouseLocation : IEnumerable<I3DStorageObject> 

    {
        internal WareHouseLocation() 
        {
            MaxVolume = (Width * Depth) * Height; //räknar ut max volymen
            MaxVolume = MaxVolume / 1000000; //för att få vomlymen i m3
            MaxVolume = Math.Round(MaxVolume,2); //för att få 2 decimal
            CanAddFragile = false; //om den kan lägga till en fragile låda
        }

        internal List<I3DStorageObject> Lshelf = new List<I3DStorageObject>(); //lista som sparar lådorna

        readonly decimal maxWeight = 1000; //max vikten i kg på hyllan
        internal readonly decimal Height = 200; //hyllans höjd i cm
        internal readonly decimal Width = 300; //hyllans bredd i cm
        internal readonly decimal Depth = 200; //hyllans djup i cm
        internal bool ContainsFragile { get; set; } //används för att hålla koll på om hyllan har en fragile låda
        internal decimal CurrentWeigth { get; set; } //hyllans nuvarande vikt
        internal decimal CurrentVolume; //hyllans nuvarande volym
        internal bool isAvailable = false; //om den är tillgänglig för att ta emot en ny låda
        internal decimal MaxVolume {get; set ; } //hyllans maxvolym
        internal decimal MaxWeight { get {return maxWeight; } } //hyllans maxvikt
        internal bool CanAddFragile 
        {
            get {return this.ContainsFragile; }
            set {this.ContainsFragile = value; }
        } //används för att hålla koll på om hyllan har en fragile låda


        internal bool AddNewBox(I3DStorageObject boxes)
        {
            bool weight = false;
            bool volume = false;
            bool MaxLength = false;
            bool valid = false;


            if (CurrentWeigth + boxes.Weight <= MaxWeight) //om lådan inte får hyllans maxvikt att överskridas
            {
                weight = true;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The box is to heavy"); //felmeddelande om hyllans maxvik överskrids
            }

            if (CurrentVolume + boxes.Volume <= MaxVolume) //om lådan inte får hyllans volym att överskridas
            {
                volume = true;
            }
            else
            {
                throw new ArgumentOutOfRangeException("There's not enough room for the box"); //felmeddelande om hyllans volym överskrids
            }

            if (boxes.MaxDimension <= Width ^ boxes.MaxDimension <= Depth ^ boxes.MaxDimension <= Height) //kollar så att lådans längsta sida går in
            {
                MaxLength = true;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The box is too big"); //felmeddelande om lådans längsta sida inte går in
            }

            if (weight == true & volume == true & MaxLength == true) //om lådans vikt och volym inte överskrider hyllans vikt och fylm
            {
                if(Lshelf.Count < 1 & boxes.IsFragile == true) //om lådan är fragile och hyllan är tom och hyllan är tom kan en fragile låda läggas till
                {
                    CanAddFragile = false; //hyllan kan inte ta emot fler fragile lådor
                    ContainsFragile = true;//hyllan innehår en fragile låda
                    valid = true;
                    CurrentVolume += boxes.Volume; //lägger till lådans volym i hyllans nuvarande volym
                    CurrentWeigth += boxes.Weight; //lägger till lådans vikt i hyllans nuvarande vikt
                    Lshelf.Add(boxes); //lägger till lådan i hyllan
                    return valid; //retunerar true
                }
                
                if(ContainsFragile == false & boxes.IsFragile == false) //om lådan inte är fragile och hyllan inte har en fragile låda kan en ej fragile låda läggas till
                {
                    valid = true;
                    CurrentVolume += boxes.Volume; //lägger till lådans volym i hyllans nuvarande volym
                    CurrentWeigth += boxes.Weight; //lägger till lådans vikt i hyllans nuvarande vikt
                    Lshelf.Add(boxes); //lägger till lådan i hyllan
                    return valid; //retunerar true
                }
                else if (boxes.IsFragile == false) //skickar felmeddelande om hyllan redan har en fragile låda och man försöker lägga till en ej fragile låda
                {
                    throw new ArgumentException("You can't add the box as the shelf has a fragile box...");
                }else if (boxes.IsFragile == true) //skickar felmeddelande om hyllan redan har en fragile låda och man försöker lägga till en till fragile låda
                {
                    throw new ArgumentException("You can't add a fragile box here...");
                }
                
            }
            else //felmeddelande om det inte gick
            {
                throw new ArgumentException("Error 404, Santa's Hat is missing");
            }

            return valid; //retunerar false
        } //metod för att lägga till låda i hyllan
        internal bool RemoveBox(I3DStorageObject boxes)
        {
            bool valid = false;
            CurrentVolume += -boxes.Volume; //tar bort lådans volym från hyllans nuvarande volym
            CurrentWeigth += -boxes.Weight; //tar bort lådans vikt från hyllans nuvarande vikt
            if(boxes.IsFragile == true) //om lådan man tar bort är fragile
            {
                CanAddFragile = true; //det går att lägga till en fragile låda igen
                ContainsFragile = false; //hyllan innehåller inte en fragile låda
            }
            Lshelf.Remove(boxes); //tar bort lådan från hyllan
            return valid; //retunerar false
        } //metod för att ta bort låda från hyllan
        internal bool FindBox(int iD, out string result)
        {
            bool found = false;

            foreach(var box in Lshelf) //loopar igenom hyllan
            {
                if(box.ID == iD) //om lådan hittar
                {
                    result = box.ToString(); //retunerar lådans information som en string
                    found = true;
                    return found; //retunerar true
                }
            }
            result = "The box could not be found"; //retunerar en string om lådan inte hittades
            return found; //retunerar false
        } //metod för att hitta låda på hyllan med ID


        public override string ToString()
        {
            
            var a = new StringBuilder(); //skapar en ny stringbuilder

            foreach (var box in Lshelf) //loopar igenom hyllan
            {   //lägger till information om hyllan i stringbuildern
                a.Append($"--[ID: {box.ID}]\t[Description: {box.Description}]  \t[MaxDimension: {box.MaxDimension}]\t[Weight: {box.Weight}kg]\t[Area: {box.Area.ToString("F")}m2]\t[Volume: {box.Volume.ToString("F")}m3]\t[Fragile: {box.IsFragile}]\t[Insurance: {box.InsuranceValue.ToString("C")}]\n");
            }
            return a.ToString(); //retunerar stringbuildern som en string


        } //skriver ut lådans innehåll
        public IEnumerator<I3DStorageObject> GetEnumerator()//metod som gör det möjligt att loopa igenom hyllan
        {
            foreach (var box in Lshelf) //loopar igenom hyllan
            {
                yield return box; //retunerar varje låda i hyllan
            }
        }
        IEnumerator IEnumerable.GetEnumerator() //metod som gör det möjligt att loopa igenom hyllan
        {
            return GetEnumerator();
        }
        internal List<I3DStorageObject> Content() //deepklon metod som retunerar en ny lista med hjälp av memorystream och Binary formatter
        {
            object cloneList = null; //skapar ett nytt object
            using (var ms = new MemoryStream()) //använder sig av memorystream
            {
                var bf = new BinaryFormatter(); //skapar en ny binaryformatter
                bf.Serialize(ms, Lshelf); //serialiserar listan
                ms.Position = 0; //sätter positionen till 0
                cloneList = bf.Deserialize(ms); //klonar listan till den nya listan
            }
            return (List<I3DStorageObject>)cloneList; //retunerar den nya listan castad som en lista av I3DStorageObject
        }
    }
    
}
