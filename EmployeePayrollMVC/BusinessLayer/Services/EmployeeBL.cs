using BusinessLayer.Interfaces;
using CommonLayer.Employee;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmployeeBL : IEmployeeBL
    {
        IEmployeeRL employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }
        public void AddEmployee(EmployeeModel employee)
        {
            try
            {
                employeeRL.AddEmployee(employee);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void UpdateEmployee(EmployeeModel employee)
        {
            try
            {
                employeeRL.UpdateEmployee(employee);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //EmployeeModel GetEmployeeData(int? id)
        //{
        //    try
        //    {
        //        employeeRL.GetEmployeeData(id);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        public void DeleteEmployee(int? id)
        {
            try
            {
                employeeRL.DeleteEmployee(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        EmployeeModel IEmployeeBL.GetEmployeeData(int? id)
        {
            try
            {
                return employeeRL.GetEmployeeData(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                return employeeRL.GetAllEmployees();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

}
