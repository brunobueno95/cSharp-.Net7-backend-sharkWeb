namespace WebApp_shark.Models
{
    public class Shark
    {
        public Guid? Id { get; set; } = null;
        public string CommonName { get; set; }

        public string Specie { get; set; }

        public string Family { get; set; }

        public string Size { get; set; }

        public List<string> Countries { get; set; } = new List<string>();

        public string Depth { get; set; }

        public string Info { get; set; }
    }
}
