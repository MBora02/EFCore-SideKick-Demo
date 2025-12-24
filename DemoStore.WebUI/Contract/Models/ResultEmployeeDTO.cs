using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace DemoStore.WebUI
{
    public class ResultEmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeSurname { get; set; }
        public decimal? EmployeeSalary { get; set; }
        public string? EmployeeDepartment { get; set; }
        public bool? EmployeeStatus { get; set; }
    }
}
