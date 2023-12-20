using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PromoCodesProcessor.Models;
using System.Data;
using Microsoft.Extensions.Configuration;


namespace PromoCodesProcessor
{
    public class DbConnection : DbContext
    {

        private readonly IConfiguration _configuration;
        private string? _connectionString = string.Empty;
        public DbConnection(DbContextOptions<DbConnection> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("AzureSQL");
        }

        // Models For Promo Codes 
        public DbSet<Promo_Codes> Promo_Codes { get; set; }
        public DbSet<Promo_Users> Promo_Users { get; set; }
        public DbSet<Promo_Product_Categories> Promo_Product_Categories { get; set; }
        public DbSet<Promo_Redeems> Redeems { get; set; }

        // Models For Other Entitites
        public DbSet<Product_Categories> Product_Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }        

        // Overrides upon migrating tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adding index on Promo Codes table to make sure the same promo code name cannot be duplicated.
            modelBuilder.Entity<Promo_Codes>().HasIndex(p => new { p.Name }).IsUnique();
            base.OnModelCreating(modelBuilder);
        }


        public DataTable ExecuteQuery(string Spname, SqlParameter[] arrayparams)
        {
            

            DataTable dt999 = new DataTable();
            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = Spname;
                    cmd.CommandTimeout = 7200;
                    if (arrayparams != null)
                    {
                        
                        foreach (SqlParameter param in arrayparams)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt999);
                    }
                    cnn.Close();
                    cnn.Dispose();
                    return dt999;

                }
            }

        }

    }

}
