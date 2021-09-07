using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DadJokeGenerator.API;
using DadJokeGenerator.Data;

namespace DadJokeGenerator.App
{
    public class JokeManager
    {
        public JokeManager()
        {
            ApiHelper.Init();
        }

        public string Joke { get; set; }

        public async Task<string> GetNewJoke()
        {
            ApiModel api = await ApiProcessor.Load();
            Joke = api.joke;
            return Joke;
        }

        public string UpperCase(string joke)
        {
            return joke.ToUpper();
        }

        public string ExlemationMark(string joke)
        {

            return joke + "!!!";
        }
        public string QuestionMark(string joke)
        {

            return joke + "???";
        }

        public string Rovarspraket(string joke)
        {
            var konsonanter = new char[]
            {
                'b','c','d','f','g','h','j','k','l','m','n','p','q','r','s','t','v','z','x'
            };

            var jokeArr = joke.ToArray();
            var jokeList = jokeArr.ToList();

            for(int i = 0; i < jokeList.Count; i++)
            {
                for (int j = 0; j < konsonanter.Length; j++)
                {
                    if(jokeList[i] == konsonanter[j])
                    {
                        jokeList.Insert(i + 1, 'o');
                        jokeList.Insert(i + 2, jokeList[i]);
                        i += 2;
                        break;
                    }
                }
            }

            return new string(jokeList.ToArray());
        }
    }
}
