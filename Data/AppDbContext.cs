using Microsoft.EntityFrameworkCore;

namespace SepetHesabıDataBase.Data;

public class AppDbContext : DbContext
{
    public DbSet<Urun> Uruns { get; set; }

    public string Dbpath { get; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        Dbpath = System.IO.Path.Join(path, "sepethesabi.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={Dbpath}");
    }


}






