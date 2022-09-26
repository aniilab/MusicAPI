﻿using System;
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
    public class SongsInPlaylistsController : ControllerBase
    {
        private readonly MusicWebAPIContext _context;

        public SongsInPlaylistsController(MusicWebAPIContext context)
        {
            _context = context;
        }

        // GET: api/SongsInPlaylists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongsInPlaylist>>> GetSongsInPlaylist()
        {
            return await _context.SongsInPlaylist.ToListAsync();
        }

        // GET: api/SongsInPlaylists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongsInPlaylist>> GetSongsInPlaylist(int id)
        {
            var songsInPlaylist = await _context.SongsInPlaylist.FindAsync(id);

            if (songsInPlaylist == null)
            {
                return NotFound();
            }

            return songsInPlaylist;
        }

        // PUT: api/SongsInPlaylists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongsInPlaylist(int id, SongsInPlaylist songsInPlaylist)
        {
            if (id != songsInPlaylist.Id)
            {
                return BadRequest();
            }

            _context.Entry(songsInPlaylist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongsInPlaylistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SongsInPlaylists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SongsInPlaylist>> PostSongsInPlaylist(SongsInPlaylist songsInPlaylist)
        {
            _context.SongsInPlaylist.Add(songsInPlaylist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongsInPlaylist", new { id = songsInPlaylist.Id }, songsInPlaylist);
        }

        // DELETE: api/SongsInPlaylists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSongsInPlaylist(int id)
        {
            var songsInPlaylist = await _context.SongsInPlaylist.FindAsync(id);
            if (songsInPlaylist == null)
            {
                return NotFound();
            }

            _context.SongsInPlaylist.Remove(songsInPlaylist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongsInPlaylistExists(int id)
        {
            return _context.SongsInPlaylist.Any(e => e.Id == id);
        }
    }
}
