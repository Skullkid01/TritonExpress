using TritonExpress.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TritonExpress.Data
{
    public class DataContext :DbContext
    {

        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SKULLKID-AORUS;Initial Catalog=TritonDB; Trusted_Connection=True; TrustServerCertificate=True;");
            }
        }

        public virtual DbSet<Vehicles> Vehicles { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<WayBill> WayBills { get; set; }
    }
}
