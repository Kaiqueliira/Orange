namespace Orange.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public String Link { get; set; }
        public String Author { get; set; }
        public Trail? Trail { get; set; }
    }
}
