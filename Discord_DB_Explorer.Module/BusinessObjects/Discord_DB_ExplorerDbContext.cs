using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Discord_DB_Explorer.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class Discord_DB_ExplorerContextInitializer : DbContextTypesInfoInitializerBase {
	protected override DbContext CreateDbContext() {
		var optionsBuilder = new DbContextOptionsBuilder<Discord_DB_ExplorerEFCoreDbContext>()
            .UseSqlServer(";")
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new Discord_DB_ExplorerEFCoreDbContext(optionsBuilder.Options);
	}
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class Discord_DB_ExplorerDesignTimeDbContextFactory : IDesignTimeDbContextFactory<Discord_DB_ExplorerEFCoreDbContext> {
    public Discord_DB_ExplorerEFCoreDbContext CreateDbContext(string[] args)
    {
        // Throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
        var optionsBuilder = new DbContextOptionsBuilder<Discord_DB_ExplorerEFCoreDbContext>();
        optionsBuilder.UseSqlServer("Integrated Security=SSPI;Pooling=false;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=SimpleProjectManager");
        // Automatically implements the INotifyPropertyChanged interface in the business objects
        optionsBuilder.UseChangeTrackingProxies();
        optionsBuilder.UseObjectSpaceLinkProxies();
        return new Discord_DB_ExplorerEFCoreDbContext(optionsBuilder.Options);
    }
}
[TypesInfoInitializer(typeof(Discord_DB_ExplorerContextInitializer))]
public class Discord_DB_ExplorerEFCoreDbContext : DbContext {
	public Discord_DB_ExplorerEFCoreDbContext(DbContextOptions<Discord_DB_ExplorerEFCoreDbContext> options) : base(options) {
	}
   
    public DbSet<Kullanici> Kullanicilar { get; set; }
    public DbSet<Sunucu> Sunucular { get; set; }
    public DbSet<Kanal> Kanallar { get; set; }
    public DbSet<Emoji> Emojiler { get; set; }
    public DbSet<Mesaj> Mesajlar { get; set; }
    public DbSet<SunucuUye> SunucuUyeleri { get; set; }
    public DbSet<Rol> Roller { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
        modelBuilder.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
    }
}
