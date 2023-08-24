using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AppEncuestasAPI.Data;
namespace AppEncuestasAPI.Data;
public class AppEncuestasDbContext : DbContext 
{
    public AppEncuestasDbContext(DbContextOptions<AppEncuestasDbContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .Entity<Encuesta>(
                er =>
                {
                    er.ToTable("Encuestas")
                    // .HasOne(e => e.AtendidoPor)
                    // .WithMany(ee => ee.EncuestasAtendidas)
                    // .HasForeignKey(e => e.EmpleadoEncuestaId);
                    ;
                })
            .Entity<Empleado>(
                er =>
                {
                    er.ToTable("Empleados")
                    ;
                })                
            .Entity<EmpleadoEncuesta>(
                er =>
                {
                    er.ToTable("EmpleadosEncuesta")
                    .Property(ee => ee.Id)
                    .ValueGeneratedNever();
                    // er.HasMany(ee => ee.EncuestasAtendidas)
                    // .WithOne(e => e.AtendidoPor)
                    ;
                })
        ;
    }
    public DbSet<Encuesta> Encuestas {get; set;}
    public DbSet<EmpleadoEncuesta> EmpleadosEncuesta {get; set;}    
    public DbSet<Empleado> Empleados { get; set; }
}