using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Övningar_Pontus
{
    class Program
    {
        static void Main(string[] args)
        {
            var länder = new List<Länder>
            {
                new Länder { Namn = "Sverige", Huvudstad="Stockholm",Folkmängd = 10.07, area = 450295 },
                new Länder { Namn = "Norge", Huvudstad="Oslo",Folkmängd = 5.27, area = 323802 },
                new Länder { Namn = "Island", Huvudstad="Reykavik",Folkmängd = 0.33, area = 102775 },
                new Länder { Namn = "Danmark", Huvudstad="Köpenhamn",Folkmängd = 5.75, area = 42931 },
                new Länder { Namn = "Finland", Huvudstad="Helsinki",Folkmängd = 5.51, area = 338424 },
                new Länder { Namn = "Belgien", Huvudstad="Bryssel",Folkmängd = 11.30, area = 30528 },
                new Länder { Namn = "Tyskland", Huvudstad="Berlin",Folkmängd = 82.18, area = 357168 },
                new Länder { Namn = "Frankrike", Huvudstad="Paris",Folkmängd = 66.99, area = 640679 },
                new Länder { Namn = "Storbritannien", Huvudstad="London",Folkmängd = 60.80, area = 209331 },
                new Länder { Namn = "Niue", Huvudstad="Alofi",Folkmängd = 0.0016, area = 261 },
                new Länder { Namn = "Mongoliet", Huvudstad="Kuala Lumpur",Folkmängd = 3.08, area = 1566000 },
                new Länder { Namn = "Polen", Huvudstad="Warsawa",Folkmängd = 38.63, area = 312679 },
                new Länder { Namn = "Spanien", Huvudstad="Madrid",Folkmängd = 46.5, area = 505990 },
                new Länder { Namn = "Portugal", Huvudstad="Lissabon",Folkmängd = 10.31, area = 92212 },
                new Länder { Namn = "Italien", Huvudstad="Rom",Folkmängd = 60.59, area = 301338 },
                new Länder { Namn = "Grekland", Huvudstad="Aten",Folkmängd = 11.18, area = 131957 },
                new Länder { Namn = "Luxemburg", Huvudstad="Luxemburg",Folkmängd = 0.58, area = 2586 },
                new Länder { Namn = "Liechtenstein", Huvudstad="Vaduz",Folkmängd = 0.038, area = 160 }
            };


            // 2 Skriv ut namnet på det första och det sista landet i listan på konsolen
            //Console.WriteLine(länder.First().Namn);
            //Console.WriteLine(länder.Last().Namn);



            //3 Skriv ut namnen på alla länder i listan, sorterade i bokstavsordning.
            //var sorteradeLänder = länder.OrderBy(x => x.Namn);

            //foreach (var s in sorteradeLänder)
            //{
            //    Console.WriteLine(s.Namn);
            //}



            //4 Skriv ut namnen på alla länder i listan, sorterade efter befolkning, med den högsta befolkningen först.
            //var sorteradeEfterBefolkning = länder.OrderByDescending(x => x.Folkmängd);

            //foreach (var s in sorteradeEfterBefolkning)
            //{
            //    Console.WriteLine($"{s.Namn,-20} {s.Folkmängd}");
            //}


            //5 Skriv ut vilken den största befolkningsmängden är.
            //var mestFolk = länder.OrderByDescending(x => x.Folkmängd).First();

            //Console.WriteLine($"{mestFolk.Namn,-20} {mestFolk.Folkmängd}");


            //6 Skriv ut genomsnittsarean och hur många länder som har en mindre area än genomsnittet.
            //var snittArea = länder.Sum(x => x.area / länder.Count);
            //var antalLänder = länder.Where(x => x.area < snittArea);

            //Console.WriteLine(snittArea);
            //foreach (var a in antalLänder)
            //{
            //    Console.WriteLine($"{a.Namn,-20}{a.area}");
            //}


            //7 Skriv ut namnen på alla länder som har en befolkning som är mindre än 5 miljoner.
            //var mindreÄnFem = länder.Where(x => x.Folkmängd < 5.0d);

            //foreach (var m in mindreÄnFem)
            //{
            //    Console.WriteLine($"{m.Namn,-20}{m.Folkmängd}");
            //}


            //8 Använd tre queries för att skriva ut hur många länder som har en area över 10 000, över 100 000 och över 1 000 000 respektive.
            //var ett = länder.Where(x => x.area > 10000 && x.area < 100000);
            //var två = länder.Where(x => x.area > 100000 && x.area < 1000000);
            //var tre = länder.Where(x => x.area > 1000000);

            //Console.WriteLine("Länder över 10 000\n");
            //foreach (var e in ett)
            //{
            //    Console.WriteLine($"{e.Namn,-20}{e.area}");
            //}
            //Console.WriteLine("\nLänder över 100 000");
            //foreach (var e in två)
            //{
            //    Console.WriteLine($"{e.Namn,-20}{e.area}");
            //}
            //Console.WriteLine("\nLänder över 1 000 000");
            //foreach (var e in tre)
            //{
            //    Console.WriteLine($"{e.Namn,-20}{e.area}");
            //}



            //9 Skriv ut namn och huvudstad för alla länder vars huvudstad börjar på samma bokstav som landets namn.
            //var namn = länder.Where(x => x.Namn.StartsWith(x.Huvudstad[0]));

            //foreach (var n in namn)
            //{
            //    Console.WriteLine($"{n.Namn,-20}{n.Huvudstad}");
            //}



            //10 Skriv ut alla land vars namn är längre än namnet på deras huvudstad.
            //var namn = länder.Where(x => x.Namn.Length > x.Huvudstad.Length);

            //foreach (var n in namn)
            //{
            //    Console.WriteLine($"{n.Namn,-20}{n.Huvudstad}");
            //}



            //11 Skriv ut de fem första länderna som har minst folkmängd.
            //var liteFolk = länder.OrderBy(x => x.Folkmängd).Take(5);

            //foreach (var l in liteFolk)
            //{
            //    Console.WriteLine($"{l.Namn,-20}{l.Folkmängd}");
            //}



            //12  Skriv ut de tre första länderna som har minst folkmängd och över 7 miljoner. Exempelvis kommer Norge inte med för det har bara 5 miljoner, men Sverige har 10 miljoner så det kommer med.
            //var land = länder.Where(x => x.Folkmängd > 7.0d).OrderBy(x => x.Folkmängd).Take(3);

            //foreach (var l in land)
            //{
            //    Console.WriteLine($"{l.Namn,-20}{l.Folkmängd}");
            //}



            //13 Skriv ut namnen på upp till tre länder som har en area på minst 500 000 km2, sorterade fallande efter namn.
            //var land = länder.Where(x => x.area > 500000).OrderByDescending(x => x.Namn).Take(3);

            //foreach (var l in land)
            //{
            //    Console.WriteLine($"{l.Namn,-20}{l.area}");
            //}


            //14 Skriv ut hur många länder det finns som börjar på varje bokstav som finns i listan.
            //Exempelvis så finns det två länder vars namn börjar på S, ett som börjar på D och två som börjar på F
            //var namn = länder.GroupBy(x => x.Namn[0]);

            //foreach (var n in namn)
            //{
            //    Console.WriteLine($"{n.Key,-3}=>{n.Count(),3}");
            //}

            //15 Skriv ut hur många länder det finns som har en befolkning på X miljoner och deras namn. Sortera dem i bokstavsordning på namnet.
            //Befolkningsmängden ska avrundas nedåt till ett heltal
            //Utskriften ska se ut ungefär så här:
            //Länder med 0 miljoner invånare:
            //-Island
            //- Niue
            //Länder med 3 miljoner invånare:
            //-Mongoliet
            //var namn = länder.GroupBy(x => Math.Floor(x.Folkmängd / 1.0) * 1.0);

            //var namn = länder.OrderBy(x => x.Namn).GroupBy(x => Math.Floor(x.Folkmängd), x => x.Namn);

            //foreach (var antalMiljoner in namn)
            //{
            //    Console.WriteLine("\nLänder med " + antalMiljoner.Key + " miljoner invånare");

            //    foreach (var land in antalMiljoner)
            //    {
            //        Console.WriteLine("* "+land);
            //    }
            //}


            //16a Skriv ut namnet och befolkningsmängden för alla länder, men räkna om befolkningsmängden till faktiska tal.
            //Alltså ska till exempel 1.5 miljoner skrivas ut som 1500000.
            //foreach (var land in länder)
            //{
            //    Console.WriteLine($"{land.Namn,-20}{Math.Round(land.Folkmängd*1000000,0)}");
            //}

            //16b  Skriv ut namnet på alla länder och hur trångbodda de är. Trångboddheten räknar du ut genom att ta befolkningsmängden delat med arean.
            //Räkna om befolkningsmängden till faktiska tal som i 16a först.

            //var land = länder.Select(x => { x.Folkmängd = Math.Round(x.Folkmängd * 1000000,0); return x; });

            //foreach (var l in land)
            //{
            //    Console.WriteLine($"{l.Namn,-20}{l.Folkmängd,-20} {l.area,-20} {Math.Round(l.Folkmängd/l.area,2)}");
            //}


            //17 Skriv ut namnet på alla länder, sorterat fallande efter deras huvudstäders namn baklänges.
            //Till exempel kommer Tyskland före Niue, eftersom Alofi → ifola kommer före Berlin → 
            //var land = länder.OrderBy(x => x.Huvudstad[x.Huvudstad.Length-1]);

            //foreach (var l in land)
            //{
            //    Console.WriteLine($"{l.Namn,-20}{l.Huvudstad}");
            //}

            //18 Skriv ut hur stor befolkning de 6 minsta länderna har tillsammans. Skriv också ut hur stor befolkning de 3 största länderna har tillsammans.
            //var land = länder.OrderBy(x => x.Folkmängd).Take(6).Sum(x => Math.Round(x.Folkmängd,2));
            //var lan = länder.OrderByDescending(x => x.Folkmängd).Take(3).Sum(x => Math.Round(x.Folkmängd, 1));

            //Console.WriteLine("De 6 minsta länderna har " + land + " milj invånare tillsammans");
            //Console.WriteLine("De 3 största länderna har " + lan + " milj invånare tillsammans");


            //19 Skriv ut hur stor befolkning alla länder vars namn är 7 tecken långt har tillsammans.
            //var land = länder.Where(x => x.Namn.Length == 7).Sum(x => Math.Round(x.Folkmängd, 2));
            //Console.WriteLine(land);


            //20 Gör en extension method till IEnumerable som heter Random. Den skall välja ut ett slumpmässigt element ur samlingen och returnera det.

            //var land = länder.Random();

            //Console.WriteLine(land);


            //21 Gör en extension method till IEnumerable som heter Shuffle. Den skall ändra samlingens ordning till en ny slumpartad ordning.
            var land = länder.Shuffle();
            int i = 0;
            int j = 0;

            foreach (var l in länder)
            {
                i++;
                Console.WriteLine(l.Namn);
            }

            Console.WriteLine();

            foreach (var l in land)
            {
                j++;
                Console.WriteLine(l.Namn);
            }

            Console.WriteLine(i);
            Console.WriteLine(j);


            //22 Med dina nya extension methods. Gör ett konsolprogram som skriver ut 3 stycken slumpmässiga länder med minst 10 miljoner invånare.
            //Dom måste vara unika ifrån varandra. Ett land får inte skrivas ut mer än en gång.




        }
    }
}
