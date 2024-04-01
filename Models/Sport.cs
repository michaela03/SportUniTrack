namespace SportUniTrack.Models
{
    public class Sport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Rules { get; set; } // Правила за игра

        public string ImageUrl { get; set; } // URL на снимка
    }
}
