using System;
using System.ComponentModel.DataAnnotations;
using QuickServe.Domain.Stores.Entities;

namespace QuickServe.Domain.Stores.Dtos
{
    public class StoreDto
    {
        public StoreDto()
        {
        }

        public StoreDto(Store store)
        {
            Id = store.Id;
            Name = store.Name;
            Address = store.Address;
            Created = store.Created;
            CreatedBy = store.CreatedBy;
           

        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Created { get; set; }
      

    }
}