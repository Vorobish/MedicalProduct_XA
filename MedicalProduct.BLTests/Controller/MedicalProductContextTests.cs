using MedicalProduct.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalProduct.BLTests.Controller
{
    class MedicalProductContextTests : DbContext
    {
        public MedicalProductContextTests() : base("Connection_MedicalProductTests") { }
        public DbSet<User> UsersTests { get; set; }
        public DbSet<Medicine> MedicinesTests { get; set; }
        public DbSet<Component> ComponentsTests { get; set; }
        public DbSet<IndicationsForUse> IndicationsForUsesTests { get; set; }
        public DbSet<Purchase> PurchasesTests { get; set; }
    }
}
