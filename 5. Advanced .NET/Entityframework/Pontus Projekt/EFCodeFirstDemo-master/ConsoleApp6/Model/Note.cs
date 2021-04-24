
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp6
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual Picture Picture { get; set; }
    }
}