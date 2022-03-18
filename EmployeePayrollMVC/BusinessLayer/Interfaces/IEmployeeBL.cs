using CommonLayer.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IEmployeeBL
    {
        void AddEmployee(EmployeeModel employee);
        void UpdateEmployee(EmployeeModel employee);
        EmployeeModel GetEmployeeData(int? id);
        void DeleteEmployee(int? id);
        IEnumerable<EmployeeModel> GetAllEmployees();
    }
}
