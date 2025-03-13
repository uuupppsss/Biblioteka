using Microsoft.EntityFrameworkCore;
namespace BibliotekaAPI.Model
{
    public class NotFakeDB:DbContext
    {
        private readonly string _filename;
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        private static NotFakeDB instance;
        public static NotFakeDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NotFakeDB("BooksDB");
                }
                return instance;
            }
        }

        public NotFakeDB(string filename)
        {
            _filename = filename;
        }

        private async void LoadData()
        {
            Books.Add(new Book { IsPopular = true, Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Description = "Роман о любви, вере и мистике." });
            Books.Add(new Book { IsPopular = true, Title = "1984", Author = "Джордж Оруэлл", Description = "Антиутопия о тоталитарном обществе." });
            Books.Add(new Book { IsPopular = false, Title = "Убийство в Восточном экспрессе", Author = "Агата Кристи", Description = "Детективная история о загадочном убийстве." });
            Books.Add(new Book() { IsPopular = false, Title = "Я Умный", Author = "Самый умный" });
            Users.Add(new User() { Username = "admin", Password = "1234" });

            await SaveChangesAsync();
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
