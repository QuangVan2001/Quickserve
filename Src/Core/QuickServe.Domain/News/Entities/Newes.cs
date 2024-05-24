﻿using QuickServe.Domain.Accounts.Entities;
using QuickServe.Domain.Common;
using System;

namespace QuickServe.Domain.News.Entities
{
    public class Newes : AuditableBaseEntity
    {
        public Guid AccountId { get; set; }
        public string? Description { get; set; }
        public string Image { get; set; } = null!;
        public bool? Status { get; set; }
        public string? Title { get; set; }

        public virtual Account Account { get; set; } = null!;
    }
}