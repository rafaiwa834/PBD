using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBD_Projekt
{
    class PBDDbContext: DbContext
    {
        private string _connectionString = @"Server=RafalPC\WINCCPLUSMIG2014;Database=PBD-Projekt;Trusted_Connection=True;";
        public DbSet<DataModel> Values { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
