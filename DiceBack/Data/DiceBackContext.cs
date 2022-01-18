#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiceBack.Models;

namespace DiceBack.Data
{
    public class DiceBackContext : DbContext
    {
        public DiceBackContext (DbContextOptions<DiceBackContext> options)
            : base(options)
        {
        }

        public DbSet<DiceBack.Models.Effects> Effects { get; set; }
    }
}
