using QuickServe.Domain.IngredientTypes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Domain.IngredientTypes.Dtos
{
    public class SimpleIngredietTypeRespone
    {
        public SimpleIngredietTypeRespone() { }
        public SimpleIngredietTypeRespone(IngredientType ingredientType)
        {
            Id = ingredientType.Id;
            Name = ingredientType.Name;
            Status = ingredientType.Status;
        }
        public long Id { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; }
    }
}
