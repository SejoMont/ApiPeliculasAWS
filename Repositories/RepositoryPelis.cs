using ApiPeliculasAWS.Data;
using ApiPeliculasAWS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPeliculasAWS.Repositories
{
    public class RepositoryPelis
    {
        private PelisContext context;

        public RepositoryPelis(PelisContext context)
        {
            this.context = context;
        }

        public async Task<List<Peli>> GetPelisAsync()
        {
            return await this.context.Pelis.ToListAsync();
        }

        public async Task<List<Peli>> GetPeliculasActores(string actor)
        {
            return await this.context.Pelis
                .Where(p => p.Actores.Contains(actor))
                .ToListAsync();
        }
    }
}
