using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Context
{
 public  class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
            
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected internal virtual void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly); //com esse codigo ele vasculha todos mapeamentos e ja acria e adequa a informacao, isso faz com que eu nao tenha q mencionar cada entidade
        }

    }
}
