using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen.Models
{
    public class ExamenDbContext: DbContext
    {
        public ExamenDbContext(DbContextOptions<ExamenDbContext> option)
            : base(option)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<InspectionPlan> InspectionPlans { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Calibration> Calibrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasKey(person => person.Id);
            modelBuilder.Entity<InspectionPlan>().HasKey(inspectionPlan => inspectionPlan.Id);
            modelBuilder.Entity<Equipment>().HasKey(equipment => equipment.Id);

            modelBuilder.Entity<InspectionPlan>()
                .HasOne(f => f.Person)
                .WithMany(f => f.InspectionPlans)
                .HasForeignKey(person => person.PersonId);

            modelBuilder.Entity<Calibration>()
                .HasKey(sc => new { sc.PersonId, sc.EquipmentId });
        }
    }
}
