using Hackathon.DAL.Models;
using HackathonDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace HackathonDAL
{
    public class ContextMssql : DbContext, IDisposable
    {
        public ContextMssql(DbContextOptions<ContextMssql> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Games> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}