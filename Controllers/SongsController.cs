using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicWebAPI.Models;

namespace MusicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly MusicWebAPIContext _context;

        public SongsController(MusicWebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongOutputDTO>>> GetSongs()
        {
            var list = await _context.Songs.ToListAsync();
            var result = new List<SongOutputDTO>();
            foreach (var song in list)
            {
                SongOutputDTO output = new SongOutputDTO()
                {
                    Name = song.Name,
                    ArtistName = _context.Artists.FirstOrDefault(a => a.Id == song.ArtistId).Name,
                    Duration = song.Duration,
                    Id = song.Id
                };
                result.Add(output);

            }
            return result;
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSong(int id)
        {
            var song = await _context.Songs.FindAsync(id);

            if (song == null)
            {
                return NotFound();
            }
            SongOutputDTO result = new SongOutputDTO()
            {
                Name = song.Name,
                ArtistName = _context.Artists.FirstOrDefault(a => a.Id == song.ArtistId).Name,
                Duration = song.Duration,
                Id = song.Id
            };

            return Ok(result);
        }



        // PUT: api/Songs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, SongInputDTO songIn)
        {
            songIn.Id = id;
            Song song = await _context.Songs.FindAsync(id);
            song.Name = songIn.Name;
            song.ArtistId=songIn.ArtistId;
            song.Duration = songIn.Duration;

            _context.Entry(song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return RedirectToAction("GetSong", new { id = song.Id });
        }

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostSong(SongInputDTO songDTO)
        {
            Song song = new Song()
            {
                Name = songDTO.Name,
                Duration = songDTO.Duration,
                ArtistId = songDTO.ArtistId
            };
            song.Artist = _context.Artists.FirstOrDefault(a => a.Id == songDTO.ArtistId);
            _context.Songs.Add(song);

            await _context.SaveChangesAsync();


            return RedirectToAction("GetSong", new { id = song.Id });
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.Id == id);
        }
    }
}
