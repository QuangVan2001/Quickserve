using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace QuickServe.Domain.Accounts.Entities
{
    public class Account :  IdentityUser<Guid>
    {
        public Account()
        {
            Created = DateTime.Now;
        }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        
    
        
       
     
        
    }
}