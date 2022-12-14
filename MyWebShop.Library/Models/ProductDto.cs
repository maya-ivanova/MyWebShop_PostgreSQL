using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebShop.Library.Models
{
    public class ProductDto
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Description { get; set; } = null!; 
        public string Filename { get; set; } = null!;
        public int Height { get; set; }
        public int Width { get; set; }
        public decimal Price { get; set; }

        public int Rating { get; set; }
   
    }
    }
