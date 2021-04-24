using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning
{
    class Kortlek
    {
        readonly int maxCard = 52;
        int currentCards { get; set; }

        List<Kort> kortlek = new List<Kort>();

        public void AddCard(Kort kort, int num)
        {
            bool found = false;
            if (currentCards < maxCard)
            {
                for (int i = 0; i < currentCards; i++)
                {
                    if (kort == kortlek[i])
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    if (num < currentCards)
                    {
                        kortlek.Insert(num, kort);
                        currentCards++;
                    }
                    else
                    {
                        Console.WriteLine("Det gick inte");
                    } 
                }
            }
            else
            {
                Console.WriteLine("kortleken är full, skål");
            }
        }
        public void Initialize()
        {
            currentCards = maxCard;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 52 / 4; j++)
                {
                    Kort nyttKort = new Kort(j, i);
                    kortlek.Add(nyttKort);
                }
            }
        }
        public void StörstKort()
        {
            Kort temp = kortlek[0];
            Kort temp2 = kortlek[1];
            if (Convert.ToInt32(temp.valör) > Convert.ToInt32(temp2.valör))
                Console.WriteLine("störts första\n" + temp + temp2);
            else
                Console.WriteLine("störts första\n" + temp2 + temp);
        }
        public Kortlek BlandaNy()
        {
            Random r = new Random();
            Kortlek nyKortlek = new Kortlek();
            for (int i = 0; i < currentCards - 1; i++)
            {
                int ran = r.Next(0, kortlek.Count);
                nyKortlek.kortlek.Add(kortlek[ran]);
                kortlek.RemoveAt(ran);
            }
            return nyKortlek;
        }
        public Kort RemoveFirstCard()
        {
           

            if (currentCards > 1)
            {
                Kort temp = kortlek[0];
                Console.WriteLine("Nu spelades " + kortlek[0]);
                kortlek.RemoveAt(0);

                currentCards--;
                return temp;
            }
            return null;

        }
        public Kort RemoveLastCard()
        {
            if (currentCards > 1)
            {
                Kort temp = kortlek[currentCards - 1];
                Console.WriteLine("Nu spelades " + kortlek[currentCards - 1]);
                kortlek.RemoveAt(currentCards - 1);
                currentCards--;
                return temp;
            }
            return null;
        }
        public Kort RemoveByChoise(int num)
        {
            if(num < currentCards)
            {
                Kort temp = kortlek[num - 1];
                Console.WriteLine("Nu spelades " + kortlek[num - 1]);
                kortlek.RemoveAt(num - 1);
                currentCards--;
                return temp;
            }
            return null;
        }
        public void Empty()
        {
            kortlek.Clear();
            currentCards = 0;
        }
        public override string ToString()
        {
            var k = new StringBuilder();
            foreach (var kort in kortlek)
                k.Append(kort);
            return k.ToString();
        }
        public Kort this[int index]
        {
            get { return kortlek[index]; }
            set { kortlek[index] = value; }
        }
    }
}
