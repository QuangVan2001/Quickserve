using System.Collections.Generic;
using QuickServe.Domain.Common;

namespace QuickServe.Domain.Categories.Entities
{
    public class Category : AuditableBaseEntity
    {
        public string? Name { get; private set; }
        public Category(){}

        
   
    }
}