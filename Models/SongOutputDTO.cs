using System.ComponentModel.DataAnnotations;

namespace MusicWebAPI.Models
{
    public class SongOutputDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ArtistName { get; set; }

        public int Duration { get; set; }
    }
}