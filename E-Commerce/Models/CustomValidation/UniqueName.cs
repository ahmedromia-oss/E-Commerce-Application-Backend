using E_Commerce.Models.DataBase;
using E_Commerce.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models.CustomValidation
{
    public class UniqueName : ValidationAttribute

    {
        
            
        


        public override bool IsValid(object value)
        {
            return true;
            
        }
    }
}
