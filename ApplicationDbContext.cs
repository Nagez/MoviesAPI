using Microsoft.EntityFrameworkCore;
using MoviesAPI.Entities;
using System.Diagnostics.CodeAnalysis;

namespace MoviesAPI
{
    public class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options) 
        {
        }
        public DbSet<Genre> Genres { get; set; }
    }
}
