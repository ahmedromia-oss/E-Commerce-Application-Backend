using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models.Categories
{
    public class UpdateCategory
    {
        public int Id { get; set; }
        
        [StringLength(30)]
        public string Name { get; set; }
        
        [StringLength(300)]
        public string Describtion { get; set; }
    }
}
