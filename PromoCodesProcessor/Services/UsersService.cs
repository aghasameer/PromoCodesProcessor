using PromoCodesProcessor.Models;
using System.Data;
using System.Net;
using static PromoCodesProcessor.Models.Users;

namespace PromoCodesProcessor.Services
{
    public class UsersService
    {

        private readonly DbConnection _dbcon;
        public UsersService(DbConnection connection)
        {
            _dbcon = connection;
        }

        public Response GetUsers()
        {
            var res = new Response();
            try
            {
                DataTable data = _dbcon.ExecuteQuery("GetUsers", []);

                var users = new List<Users_Data>();

                foreach (DataRow row in data.Rows)
                {

                    users.Add(new Users_Data
                    {
                        user_id = Convert.ToInt32(row["user_id"]),
                        user_name = row["user_name"].ToString()!
                    });
                }

                res.result = users;
            }
            catch (Exception ex)
            {
                res.statuscode = HttpStatusCode.InternalServerError;
                res.message = ex.Message;
            }
            return res;
        }
    }
}
