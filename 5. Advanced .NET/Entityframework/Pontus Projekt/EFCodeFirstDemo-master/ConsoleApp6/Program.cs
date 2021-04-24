using System;
using System.Linq;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            NotesDBContext dbContext = new NotesDBContext();
            //User pontus = dbContext.Users.Single(user => user.Username == "pwntus");
            //var anteckning = pontus.Notes.Last();
            //Console.WriteLine($"{pontus.Name} note with title {anteckning.Title} has content {anteckning.Content}" );
            var myNote = dbContext.Notes.First();
            var newTag = new Tag();
            newTag.Name = "TestTag";
            myNote.Tags.Add(newTag); 
            dbContext.SaveChanges();
        }
    }
}
