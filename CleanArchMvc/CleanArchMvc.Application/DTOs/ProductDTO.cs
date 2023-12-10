using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTOs
{
   public class ProductDTO
    {
        [Required(ErrorMessage = "The name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; private set; }

        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get; private set; }
        
        [Required(ErrorMessage = "The price is Required")]
        [Column(TypeName = "decimal(18,2")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("price")]
        public decimal Price { get; private set; }

        [Required(ErrorMessage = "The Stock is Required")]
        [Range(1, 9999)]
        [DisplayName("Price")]
        public int Stock { get; private set; }

        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string Image { get; private set; }

        // aqui embaixo see chama propriedades de navegação
        public int CategoryId { get; set; }// o produto esta rlacionado com a categoria, aqui é a chave estrangeira

        [DisplayName("Categories")]
        public Category Category { get; set; } 
    }
}
