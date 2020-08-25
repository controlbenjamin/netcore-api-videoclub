using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoClubWebApi.Models
{
    public class VideoClubDbContext : DbContext
    {
        //lo que configuramos en startup debe entrar en el parametro del constructor por defecto
        public VideoClubDbContext(DbContextOptions options) : base(options)
        {
        }


        //Mapear las tablas como objetos
        public DbSet<Cliente> Clientes { get; set; }



    }
}
