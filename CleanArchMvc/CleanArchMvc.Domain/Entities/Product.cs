using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
      
        public string Name{ get; private set; }
        public string Description{ get; private set; }
        public decimal Price { get; private  set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        
        // aqui embaixo see chama propriedades de navegação
        public int CategoryId { get; set; }// o produto esta rlacionado com a categoria, aqui é a chave estrangeira

        public Category Category { get; set; } //o tipo que essa tabela vai se relacionar que é com category
        //validações 
        private void ValidateDomain(string name, string description, decimal price, int stock, string image) {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 charecters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description.Description  is required");
            DomainExceptionValidation.When(name.Length < 5, "Invalid description, too short, minimum 5 charecters");
            DomainExceptionValidation.When(price < 0, "Invalid price value");
            DomainExceptionValidation.When(stock < 0, "Invalid stock value");
            DomainExceptionValidation.When(image?.Length >250, "Invalid image name, too short, minimum 290 charecters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }
        public void Update(int id, string name, string description, decimal price, int stock, string image, int cateroryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = cateroryId; // valor da chavee estrangeira 
        }
    }
}
