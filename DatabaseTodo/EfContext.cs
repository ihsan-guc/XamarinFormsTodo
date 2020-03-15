using Microsoft.EntityFrameworkCore;
using System;
using XamarinFormsTodo.Model;

namespace DatabaseTodo
{
    public class EfContext : DbContext
    {
        public DbSet<Todo> Todo{ get; set; }
        private readonly string _databasePath;
        public EfContext(string databasePath)
        {
            _databasePath = databasePath;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
