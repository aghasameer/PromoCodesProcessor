using System.Data;
using System.Net;
using PromoCodesProcessor.Models;

namespace PromoCodesProcessor.Services
{
    public class ProductsService
    {

        private readonly DbConnection _dbcon;
        public ProductsService(DbConnection connection)
        {
            _dbcon = connection;
        }

        public Response GetProducts()
        {
            var res = new Response();
            try
            {
                DataTable data = _dbcon.ExecuteQuery("GetProducts", []);

                var products = new List<Products_Data>();

                foreach (DataRow row in data.Rows)
                {

                    products.Add(new Products_Data
                    {
                        Id = Convert.ToInt32(row["product_id"]),
                        Name = row["product_name"].ToString()!,
                        CategoryId = Convert.ToInt32(row["category_id"]),
                        CategoryName = row["category_name"].ToString()!,
                        Price = Convert.ToDecimal(row["product_price"])!
                    });
                }
                
                res.result = products;
            }
            catch (Exception ex)
            {
                res.statuscode = HttpStatusCode.InternalServerError;
                res.message = ex.Message;
            }
            return res;
        }


        public Response GetCategories()
        {
            var res = new Response();
            try
            {
                DataTable data = _dbcon.ExecuteQuery("GetCategories", []);

                var products = new List<Promo_Categories_Data>();

                foreach (DataRow row in data.Rows)
                {

                    products.Add(new Promo_Categories_Data
                    {
                        category_id = Convert.ToInt32(row["category_id"]),
                        category_name = row["category_name"].ToString()!,
                    });
                }

                res.result = products;
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
