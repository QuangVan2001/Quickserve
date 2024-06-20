﻿using QuickServe.Domain.Orders.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickServe.Domain.Orders.Dtos
{
    public class OrderDto
    {
        public OrderDto(Order order)
        {
            Id = order.Id;
            CustomerId = order.CustomerId;
            TotalPrice = order.TotalPrice;
            Status = order.Status;
            StoreId = order.StoreId;
        }
        public long Id { get; set; }
        public Guid CustomerId { get; set; }
        public double TotalPrice { get; set; }
        public int Status { get; set; }
        public long StoreId { get; set; }
    }
}
