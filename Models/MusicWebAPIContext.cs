using Microsoft.EntityFrameworkCore;

namespace MusicWebAPI.Models
{
    public class MusicWebAPIContext : DbContext
    {
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<GenresOfSong> GenresOfSongs { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<SongsInPlaylist> SongsInPlaylist { get; set; }
        public MusicWebAPIContext(DbContextOptions<MusicWebAPIContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
