using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity// sealed significa que a classe não pode ser herdada
    {
        
        public string  Name{ get; private set; }

        public ICollection<Product> Products { get; set; } // quer dizer que em categoria iraa ter uma coleção de produtos

        public Category(string name)
        {
          
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            ValidateDomain(name);
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
           
        }
        public void Update(string name)
        {
            ValidateDomain(name);
        }
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");
            DomainExceptionValidation.When(name.Length <3, "Invalid name, too short, minimum 3 charecters");
            Name = name;
        }
    }
}
