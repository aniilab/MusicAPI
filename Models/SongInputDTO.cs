namespace MusicWebAPI.Models
{
    public class SongInputDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ArtistId { get; set; }

        public int Duration { get; set; }
    }
}
