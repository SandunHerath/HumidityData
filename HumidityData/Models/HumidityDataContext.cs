using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HumidityData.Models
{
    public class HumidityDataContext : DbContext
    {
        public HumidityDataContext()
        {
        }

        public HumidityDataContext(DbContextOptions<HumidityDataContext> options)
            : base(options)
        {
        }
        public virtual DbSet<HumidityData> HumidityData { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}