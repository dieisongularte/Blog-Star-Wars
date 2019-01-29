using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogStarWars.Data;
using BlogStarWars.Models;
using BlogStarWars.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BlogStarWars.Services
{
    public class PostService
    {
        private readonly BlogStarWarsContext _context;

        public PostService(BlogStarWarsContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(Post obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Post.FindAsync(id);
                _context.Post.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Post obj)
        {
            bool hasAny = await _context.Post.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<List<Post>> FindTakeAsync()
        {
            return await _context.Post.OrderByDescending(x => x.QuantLikes).Take(5).ToListAsync();
        }

        public async Task<Post> FindByIdAsync(int id)
        {
            return await _context.Post.FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<int> TotalLikes()
        {
            int total = await _context.Post.SumAsync(x => x.QuantLikes);
            return total;
        }

        public async Task<int> TotalViews()
        {
            int total = await _context.Post.SumAsync(x => x.QuantViews);
            return total;
        }

    }
}
