﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IItemCategoryRepository
    {
        Task<IEnumerable<ItemCategory>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<ItemCategory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Insert(ItemCategory itemCategory);
        void Remove(ItemCategory itemCategory);
    }
}
