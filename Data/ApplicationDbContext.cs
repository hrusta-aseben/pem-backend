namespace hakaton.Data;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext: DbContext
{
    public DbSet<Korisnici> Korisnici { get; set; }
    public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }
    public DbSet<Lekcija> Lekcija { get; set; }
    public DbSet<Predmet> Predmet { get; set; }
    public DbSet<Skola> Skola { get; set; }
    public DbSet<Test> Test { get; set; }
    public DbSet<Pitanje> Pitanje { get; set; }
    public DbSet<Odgovor> Odgovor { get; set; }
    public DbSet<Tip> Tip { get; set; }
    public DbSet<Vizuelni> Vizuelni { get; set; }
    public DbSet<Auditivni> Auditivni { get; set; }

    public ApplicationDbContext(
             DbContextOptions options) : base(options)
    {
    }
}
