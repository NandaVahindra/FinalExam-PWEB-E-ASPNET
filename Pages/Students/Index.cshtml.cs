using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace easeas.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<StudentInfo> listStudents = new List<StudentInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=localhost\\SQLEXPRESS02;Initial Catalog=dbeas;Integrated Security=True";
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM datamahasiswa";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentInfo studentInfo = new StudentInfo();
                                studentInfo.id = "" + reader.GetInt32(0);
                                studentInfo.name = reader.GetString(1);
                                studentInfo.email = reader.GetString(2);
                                studentInfo.NRP = "" + reader.GetInt32(3);
                                studentInfo.Batch = "" + reader.GetInt32(4);
                                studentInfo.Major = reader.GetString(5);

                                listStudents.Add(studentInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
                throw;
            }
        }
    }

    public class StudentInfo
    {
        public String id;
        public String name;
        public String email;
        public String NRP;
        public String Batch;
        public String Major;
    }
}
