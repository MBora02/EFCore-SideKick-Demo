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
    public class EmployeeService : EntityServiceBase<EmployeeDTO,Employee, int>, IEmployeeService
    {
        private readonly ICurrentUser _currentUser;

        public EmployeeService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUser currentUser)
            : base(unitOfWork, mapper)
        {
            _currentUser = currentUser;
        }
    }
}
