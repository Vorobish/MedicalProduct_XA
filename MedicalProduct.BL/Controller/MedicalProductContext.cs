using MedicalProduct.BL.Model;
using System;
using System.Data.Entity;

namespace MedicalProduct.BL.Controller
{
    public class MedicalProductContext : DbContext
    {
        public MedicalProductContext() : base ("Connection_MedicalProduct") {}
        public DbSet<User> Users { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<IndicationsForUse> IndicationsForUses { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PositionPurchase> PositionPurchases { get; set; }
    }
}
