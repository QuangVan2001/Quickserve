﻿using QuickServe.Application.DTOs;
using QuickServe.Domain.Stores.Dtos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuickServe.Application.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        void AddStaffToStore(long storeId, Guid employeeId);
        Task<PagenationResponseDto<EmployeeDto>> GetPagedListStaffByStoreIdAsync(long storeId, int pageNumber, int pageSize, string name, CancellationToken cancellationToken);
    }
}
