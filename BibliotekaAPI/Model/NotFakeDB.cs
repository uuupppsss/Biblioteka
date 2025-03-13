using Microsoft.EntityFrameworkCore;
namespace BibliotekaAPI.Model
{
    public class NotFakeDB:DbContext
    {
        private readonly string _filename;
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        public NotFakeDB(string filename)
        {
            _filename = filename;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Database");
            Directory.CreateDirectory(sqlitePath);
            var filename = Path.Combine(sqlitePath, _filename);
            if (!File.Exists(filename))
                File.Create(filename);
            optionsBuilder.UseSqlite($"Data Source={filename}");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
