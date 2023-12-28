using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeServiceWCF" in both code and config file together.
    public class EmployeeServiceWCF : IEmployeeServiceWCF
    {
        public Employee GetEmployee(int Id)
        {
            Employee employee = new Employee();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand sqlCommand = new SqlCommand("spGetEmployee", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameterId = new SqlParameter("@Id", Id);
                sqlCommand.Parameters.Add(sqlParameterId);
                conn.Open();
                
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    employee.Id = Convert.ToInt32(sqlDataReader["Id"]);
                    employee.Name = sqlDataReader["Name"].ToString();
                    employee.Gender = sqlDataReader["Gender"].ToString();
                    employee.DateOfBirth = Convert.ToDateTime(sqlDataReader["DateOfBirth"]);
                }
            }

            return employee;
        }

        public void SaveEmployee(Employee employee)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand sqlCommand = new SqlCommand("spSaveEmployee", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameterId = new SqlParameter("@Id", employee.Id);
                sqlCommand.Parameters.Add(sqlParameterId);
                SqlParameter sqlParameterName = new SqlParameter("@Name", employee.Name);
                sqlCommand.Parameters.Add(sqlParameterName);
                SqlParameter sqlParameterGender = new SqlParameter("@Gender", employee.Gender);
                sqlCommand.Parameters.Add(sqlParameterGender);
                SqlParameter sqlParameterDateOfBirth = new SqlParameter("@DateOfBirth", employee.DateOfBirth);
                sqlCommand.Parameters.Add(sqlParameterDateOfBirth);

                con.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
