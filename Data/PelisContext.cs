using ApiPeliculasAWS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPeliculasAWS.Data
{
    public class PelisContext : DbContext
    {
        public PelisContext(DbContextOptions<PelisContext> options) : base(options) { }
        public DbSet<Peli> Pelis { get; set; }
    }
}
