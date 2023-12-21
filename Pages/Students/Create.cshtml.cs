using easeas.Pages.Clients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Net.Security;

namespace easeas.Pages.Students
{
    public class CreateModel : PageModel
    {
        public StudentInfo studentInfo = new StudentInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost() 
        {
            studentInfo.name = Request.Form["name"];
            studentInfo.email = Request.Form["email"];
            studentInfo.NRP = Request.Form["NRP"];
            studentInfo.Batch = Request.Form["Batch"];
            studentInfo.Major = Request.Form["Major"];

            if ( studentInfo.name.Length == 0 || studentInfo.email.Length == 0 || studentInfo.NRP.Length == 0 || studentInfo.Batch.Length == 0 || studentInfo.Major.Length == 0)
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
                    String sql = "INSERT INTO datamahasiswa" + 
                        "(name,email,NRP,Batch,Major) VALUES " +
                        "(@name,@email,@NRP,@Batch,@Major);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", studentInfo.name);
                        command.Parameters.AddWithValue("@email", studentInfo.email);
                        command.Parameters.AddWithValue("@NRP", studentInfo.NRP);
                        command.Parameters.AddWithValue("@Batch", studentInfo.Batch);
                        command.Parameters.AddWithValue("@Major", studentInfo.Major);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            studentInfo.name = "";
            studentInfo.email = "";
            studentInfo.NRP = "";
            studentInfo.Batch = "";
            studentInfo.Major = "";
            successMessage = "New Student Added correctly";

            Response.Redirect("/Students/Index");

        }

    }
}
