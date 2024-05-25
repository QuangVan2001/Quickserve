using System;
using System.Collections.Generic;
using QuickServe.Domain.Orders.Entities;

namespace QuickServe.Infrastructure.Identity.Models;

public class Customer : ApplicationUser
{
    public Customer() 
    {
        Orders = new HashSet<Order>();
    }

    public virtual ICollection<Order> Orders { get; set; }
}