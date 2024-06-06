using QuickServe.Domain.Accounts.Dtos;
using System.Collections.Generic;

namespace QuickServe.Domain.Stores.Dtos
{
    public class StoreEmployeeDto
    {
        public List<EmployeeDto> Employees { get; set; }
    }

    public class EmployeeDto : AccountDto
    {
        
    }
}
