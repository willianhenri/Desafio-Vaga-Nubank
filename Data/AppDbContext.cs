using DesafioNubank.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioNubank.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    {    
    }

    public DbSet<ClienteModel> Clientes { get; set; }
    public DbSet<ContatoModel> Contatos { get; set; }
}