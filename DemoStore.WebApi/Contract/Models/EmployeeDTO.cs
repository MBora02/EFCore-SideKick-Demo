using DemoStore.WebApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoStore.WebApi
{
    public partial class EmployeeDTO : IMapFrom<Employee>
    {
        public int EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

        public string? EmployeeSurname { get; set; }

        public decimal? EmployeeSalary { get; set; }

        public string? EmployeeDepartment { get; set; }

        public bool? EmployeeStatus { get; set; }
    }
}
