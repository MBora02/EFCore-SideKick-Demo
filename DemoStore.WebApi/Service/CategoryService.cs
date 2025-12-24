using AutoMapper;
using DemoStore.WebApi;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DemoStore.WebApi
{
    public class CategoryService : EntityServiceBase<CategoryDTO,Category, int>, ICategoryService
    {
        private readonly ICurrentUser _currentUser;

        public CategoryService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUser currentUser)
            : base(unitOfWork, mapper)
        {
            _currentUser = currentUser;
        }
    }
}
