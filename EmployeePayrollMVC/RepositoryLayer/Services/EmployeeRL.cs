using CommonLayer.Employee;
using RepositoryLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmployeeRL : IEmployeeRL
    {
        //string ConnectionStringName = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=employee_payroll_MVC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private readonly IConfiguration Configuration;
        public string ConnectionStringName { get; set; } = "EmployeePayrollMVC";
        public EmployeeRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        //To View all employees details
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> lstemployee = new List<EmployeeModel>();

            string connectionString = Configuration.GetConnectionString(ConnectionStringName);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllEmpForm1", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    EmployeeModel employee = new EmployeeModel();

                    employee.Emp_id = Convert.ToInt32(rdr["Emp_id"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Profile_Image = rdr["Profile_Image"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = rdr["Salary"].ToString();
                    employee.Start_Date = rdr["Start_Date"].ToString();
                    employee.Notes = rdr["Notes"].ToString();

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }

        //To Add new employee record      
        public void AddEmployee(EmployeeModel employee)
        {
            string connectionString = Configuration.GetConnectionString(ConnectionStringName);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddEmpForm1", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Profile_Image", employee.Profile_Image);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@Start_Date", employee.Start_Date);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);
                

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a particluar employee    
        public void UpdateEmployee(EmployeeModel employee)
        {
            string connectionString = Configuration.GetConnectionString(ConnectionStringName);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_Update_EmpForm1", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Emp_id", employee.Emp_id);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Profile_Image", employee.Profile_Image);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@Start_Date", employee.Start_Date);
                cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get the details of a particular employee    
        public EmployeeModel GetEmployeeData(int? id)
        {
            EmployeeModel employee = new EmployeeModel();
            string connectionString = Configuration.GetConnectionString(ConnectionStringName);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Emp_Form1 WHERE Emp_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.Emp_id = Convert.ToInt32(rdr["Emp_id"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Profile_Image = rdr["Profile_Image"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = rdr["Salary"].ToString();
                    employee.Start_Date = rdr["Start_Date"].ToString();
                    employee.Notes = rdr["Notes"].ToString();
                }
            }
            return employee;
        }

        //To Delete the record on a particular employee    
        public void DeleteEmployee(int? id)
        {
            string connectionString = Configuration.GetConnectionString(ConnectionStringName);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteEmpForm1", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Emp_id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    

      
    }
}
