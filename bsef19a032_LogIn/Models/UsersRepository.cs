using Microsoft.Data.SqlClient;
namespace bsef19a032_LogIn.Models
{
    public class UsersRepository
    {


        public static void AddUser(User u)
        {
            /*******************
             * Takes Users Data
             * Add It in DB
             * **************/
            
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(conString);

            //query
            string query = $"insert into Users(Username,Password)" +
                $" values( @un, @p)";


            SqlParameter p1 = new SqlParameter("un", u.Username);
            SqlParameter p2 = new SqlParameter("p", u.Password);

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            connection.Open();
            int insertedRows = cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static bool checkUser(User u)
        {
            /*******************
                * Takes Users Data
                * Checks If it exisits in DB
                * **************/

            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(conString);

            //query
            string query = $" select * from Users where" +
                           $" Username = @un" +
                           $" And" +
                           $" Password = @p";


            SqlParameter p1 = new SqlParameter("un", u.Username);
            SqlParameter p2 = new SqlParameter("p", u.Password);

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                connection.Close();
                return true;
            }
            
            connection.Close();
            return false;
        }
        public static List<User> GetAllUsers()
        {

            /*********************************
             * Takes Data from DataBase
             * store it in List
             * returns List
             *********************************/


            //creating List of Users
            List<User> users = new List<User>();
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);

            con.Open();
            string query = "Select * from Users";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                User ext = new User();
                
                (ext.Username, ext.Password)
                    =
                (dr[1].ToString(), dr[2].ToString());

                //Adding in List
                users.Add(ext);
            }
            con.Close();
            return users;
        }
    }
}
