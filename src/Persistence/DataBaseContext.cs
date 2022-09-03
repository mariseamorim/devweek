using Microsoft.EntityFrameworkCore;
using src.Models;


namespace src.Persitence;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {

    }
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Contrato> Contratos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Pessoa>(e => {
            e.HasKey(p => p.Id);
            e.HasMany(p => p.Contratos).WithOne().HasForeignKey(c=> c.PessoaId);
        });
        builder.Entity<Contrato>(e => {
            e.HasKey(p => p.Id);

        });

    }

}