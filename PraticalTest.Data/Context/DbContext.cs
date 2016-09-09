using System.Data.Entity;

namespace PraticalTest.Data.Context
{

    public class PraticalTestDbContext: DbContext
    {
        public PraticalTestDbContext()
            : base("DatabaseConnection")
        {
        }

        public DbSet<CityDataModel> Cities { get; set; }
        public DbSet<ClassificationDataModel> Classifications { get; set; }
        public DbSet<ClientDataModel> Clients { get; set; }
        public DbSet<RegionDataModel> Regions { get; set; }
        public DbSet<UserDataModel> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<PraticalTestDbContext>(null);

            modelBuilder.Configurations.Add(new CityConfig());
            modelBuilder.Configurations.Add(new ClassificationConfig());
            modelBuilder.Configurations.Add(new ClientConfig());
            modelBuilder.Configurations.Add(new RegionConfig());
            modelBuilder.Configurations.Add(new UserConfig());

            base.OnModelCreating(modelBuilder);
        }
    }

}
