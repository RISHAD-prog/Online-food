using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    internal class FoodCornerEntities : DbContext
    {
        public DbSet<Registration> registrations { get; set; }
        public DbSet<Token> tokens { get; set; }
    }
}
