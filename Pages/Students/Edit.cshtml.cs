using easeas.Pages.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace easeas.Pages.Students
{
    public class EditModel : PageModel
    {
        public StudentInfo studentInfo = new StudentInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
            String id = Request.Query["id"];

            try
            {
                String connectionString = "Data Source=localhost\\SQLEXPRESS02;Initial Catalog=dbeas;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM datamahasiswa WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                studentInfo.id = "" + reader.GetInt32(0);
                                studentInfo.name = reader.GetString(1);
                                studentInfo.email = reader.GetString(2);
                                studentInfo.NRP = "" + reader.GetInt32(3);
                                studentInfo.Batch = "" + reader.GetInt32(4);
                                studentInfo.Major = reader.GetString(5);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }

        public void OnPost()
        {
            studentInfo.id = Request.Form["id"];
            studentInfo.name = Request.Form["name"];
            studentInfo.email = Request.Form["email"];
            studentInfo.NRP = Request.Form["NRP"];
            studentInfo.Batch = Request.Form["Batch"];
            studentInfo.Major = Request.Form["Major"];

            if (studentInfo.name.Length == 0 || studentInfo.email.Length == 0 || studentInfo.NRP.Length == 0 || studentInfo.Batch.Length == 0 || studentInfo.Major.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }

            try
            {
                String connectionString = "Data Source=localhost\\SQLEXPRESS02;Initial Catalog=dbeas;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE datamahasiswa SET name=@name, email=@email, NRP=@NRP, Batch=@Batch, Major=@Major WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", studentInfo.name);
                        command.Parameters.AddWithValue("@email", studentInfo.email);
                        command.Parameters.AddWithValue("@NRP", studentInfo.NRP);
                        command.Parameters.AddWithValue("@Batch", studentInfo.Batch);
                        command.Parameters.AddWithValue("@Major", studentInfo.Major);
                        command.Parameters.AddWithValue("@id", studentInfo.id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/Students/Index");
        }
    }
}
