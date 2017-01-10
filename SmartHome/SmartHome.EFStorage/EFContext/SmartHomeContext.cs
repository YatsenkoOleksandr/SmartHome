using SmartHome.Entities.Components;
using SmartHome.Entities.Devices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.EFStorage.EFContext
{
    public class SmartHomeContext : DbContext
    {
        private const string CONNECTION_NAME = "SmartHomeContext";

        private const int STRING_SIZE = 255;

        public SmartHomeContext(): 
            base(CONNECTION_NAME)
        {
            Database.SetInitializer(new SmartHomeInitializer());
        }

        public SmartHomeContext(string connectionName): 
            base(GetConnectionString(connectionName))
        {
            Database.SetInitializer(new SmartHomeInitializer());
        }

        private static string GetConnectionString(string connectionName)
        {           
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseDevice>()
                .Property(b => b.Name).IsRequired().HasMaxLength(STRING_SIZE);            

            modelBuilder.Entity<Radio>().ToTable("Radios");
            modelBuilder.Entity<Fridge>().ToTable("Fridges");
            modelBuilder.Entity<TVSet>().ToTable("TVSets");

            modelBuilder.Entity<BaseComponent>()
                .Property(b => b.Name).IsRequired().HasMaxLength(STRING_SIZE);

            modelBuilder.Entity<Mode>()
                .Property(m => m.Name).IsRequired().HasMaxLength(STRING_SIZE);

            modelBuilder.Entity<Channel>().ToTable("Channels");

            modelBuilder.Entity<Regulator>()
                .ToTable("Regulators")
                .Property(r => r.MeasureName).IsRequired().HasMaxLength(STRING_SIZE);

            modelBuilder.Entity<VolumeRegulator>().ToTable("VolumeRegulators");
            modelBuilder.Entity<Switch>().ToTable("Switches");
            modelBuilder.Entity<ChannelRegulator>().ToTable("ChannelRegulators");
            modelBuilder.Entity<ModeRegulator>().ToTable("ModeRegulators");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<BaseComponent> BaseComponents { get; set; }

        public DbSet<Regulator> Regulators { get; set; }

        public DbSet<VolumeRegulator> VolumeRegulators { get; set; }

        public DbSet<Switch> Switches { get; set; }

        public DbSet<ChannelRegulator> ChannelRegulators { get; set; }

        public DbSet<ModeRegulator> ModeRegulators { get; set; }

        public DbSet<BaseDevice> BaseDevices { get; set; }

        public DbSet<Fridge> Fridges { get; set; }

        public DbSet<Radio> Radios { get; set; }

        public DbSet<TVSet> TVSets { get; set; }
    }
}
