using easeas.Pages.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace easeas.Pages.Class
{
    public class IndexModel : PageModel
    {
        public List<ClassInfo> listClass = new List<ClassInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=localhost\\SQLEXPRESS02;Initial Catalog=dbeas;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM data_kelas";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClassInfo classInfo = new ClassInfo();
                                classInfo.id = "" + reader.GetInt32(0);
                                classInfo.name = reader.GetString(1);
                                classInfo.hari = reader.GetString(2);
                                classInfo.jam = reader.GetString(3);
                                classInfo.ruangan = reader.GetString(4);
                                classInfo.semester = "" + reader.GetInt32(5);
                                classInfo.tahunAjaran = reader.GetString(6);

                                listClass.Add(classInfo);
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

        public class ClassInfo
        {
            public String id;
            public String name;
            public String hari;
            public String jam;
            public String ruangan;
            public String semester;
            public String tahunAjaran;
        }
    }
}
