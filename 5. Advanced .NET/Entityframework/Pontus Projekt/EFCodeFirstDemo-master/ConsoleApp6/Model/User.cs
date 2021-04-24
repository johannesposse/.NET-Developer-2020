using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp6
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
