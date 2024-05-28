﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using QuickServe.Domain.Orders.Entities;


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
        
        public virtual ICollection<Order> Orders { get; set; }
    }
}