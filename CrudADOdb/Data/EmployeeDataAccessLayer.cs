using CrudADOdb.Models;
using CrudADOdb.Utilities;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace CrudADOdb.Data
{
    public class EmployeeDataAccessLayer
    {
        string cs = ConnectionString.dbcs;

        public List<Employees> getAllEmployees()
        {
            List<Employees> empList = new List<Employees>();

            using (SqlConnection obj = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", obj);
                cmd.CommandType = CommandType.StoredProcedure;

                obj.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employees emp = new Employees();
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["Name"].ToString() ?? "";
                    emp.Gender = reader["Gender"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["age"]);
                    emp.City = reader["city"].ToString() ?? "";
                    emp.Designation = reader["designation"].ToString()?? "";

                    empList.Add(emp);
                }
            }
            return empList;
        }

        public void addEmployee(Employees emp)
        {
            using (SqlConnection obj = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", obj);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.Parameters.AddWithValue("@designation", emp.Designation);
                cmd.Parameters.AddWithValue("@city", emp.City);

                obj.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
