using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ulubione.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ulubione.Data
{
    public class PrzepisyContext : IdentityDbContext
    {
        public PrzepisyContext(DbContextOptions<PrzepisyContext> options)
            : base(options)
        {
        }
        public DbSet<Przepis> Przepis { get; set; }
    }
}
