namespace ConsoleApp6
{
    public class Picture
    {
        public int Id { get; set; }
        public int NoteId { get; set; }
        public virtual Note Note { get; set; }
        public string Url { get; set; }
    }
}