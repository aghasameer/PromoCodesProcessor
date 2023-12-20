using Newtonsoft.Json;
using PromoCodesProcessor.Models;
using System.Data;
using System.Net;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PromoCodesProcessor.Services
{
    public class Promo_CodesService
    {

        private readonly DbConnection _dbcon;
        public Promo_CodesService(DbConnection connection)
        {
            _dbcon = connection;
        }

        public Response GetPromos()
        {
            var res = new Response();
            try
            {
                DataTable data = _dbcon.ExecuteQuery("GetPromos", []);
                string json = data.Rows[0]["promos"].ToString()!;

                var promos = new List<Promos_Data>();

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                if (!string.IsNullOrEmpty(json))
                {
                    promos = JsonConvert.DeserializeObject<List<Promos_Data>>(json, settings);
                }


                res.result = promos;


            }
            catch (Exception)
            {
                res.statuscode = HttpStatusCode.InternalServerError;
                res.message = "Something went wrong.";
            }

            return res;
        }

        public Response GetPromo(int Id)
        {

            var res = new Response();
            try
            {
                DataTable data = _dbcon.ExecuteQuery("GetPromo", new SqlParameter[]
                {
                    new SqlParameter("@promoId", Id)
                });
                string json = data.Rows[0]["promo"].ToString()!;

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                var promos = JsonConvert.DeserializeObject<Promos_Data>(json, settings);

                if (promos == null)
                {
                    res.statuscode = HttpStatusCode.NotFound;
                    res.message = res.statuscode.ToString();
                }

                res.result = promos;

            }
            catch (Exception)
            {
                res.statuscode = HttpStatusCode.InternalServerError;
                res.message = "Something went wrong.";
            }

            return res;

        }

        public Response CreatePromo(CreatePromo promo)
        {

            var res = new Response();
            try
            {

                var json = JsonConvert.SerializeObject(promo);

                DataTable data = _dbcon.ExecuteQuery("CreatePromo", new SqlParameter[]
                {
                    new SqlParameter("@jsonData", json)
                });

                string result = data.Rows[0]["done"].ToString()!;

                res.statuscode = HttpStatusCode.Created;
                res.result = result;

            }
            catch (Exception ex)
            {
                res.statuscode = HttpStatusCode.InternalServerError;
                res.message = "Something went wrong.";

                if (ex.Message.Contains("duplicate"))
                {
                    res.statuscode = HttpStatusCode.BadRequest;
                    res.message = "Duplicate promo codes not allowed.";
                }
                
                
            }

            return res;

        }

        public Response UpdatePromo(UpdatePromo promo)
        {

            var res = new Response();
            try
            {

                int promoId = Convert.ToInt32(promo.id);

                Response findPromo = GetPromo(promoId);

                if (findPromo.result == null)
                {
                    throw new Exception("not_found");
                }

                var json = JsonConvert.SerializeObject(promo);

                DataTable data = _dbcon.ExecuteQuery("UpdatePromo", new SqlParameter[]
                {
                    new SqlParameter("@jsonData", json)
                });

                string result = data.Rows[0]["done"].ToString()!;

                res.statuscode = HttpStatusCode.OK;
                res.result = result;

            }
            catch (Exception ex)
            {
                res.statuscode = HttpStatusCode.InternalServerError;
                res.message = "Something went wrong.";

                if (ex.Message.Contains("duplicate"))
                {
                    res.statuscode = HttpStatusCode.BadRequest;
                    res.message = "Duplicate promo codes not allowed.";
                }

                if (ex.Message.Contains("not_found"))
                {
                    res.statuscode = HttpStatusCode.NotFound;
                    res.message = "Promo code not found.";
                }

            }

            return res;

        }

        public Response DeletePromo(int Id)
        {

            var res = new Response();
            try
            {

                Response findPromo = GetPromo(Id);

                if (findPromo.result == null)
                {
                    throw new Exception("not_found");
                }


                DataTable data = _dbcon.ExecuteQuery("DeletePromo", new SqlParameter[]
                {
                    new SqlParameter("@promoId", Id)
                });

                string result = data.Rows[0]["done"].ToString()!;

                res.statuscode = HttpStatusCode.OK;
                res.result = result;

            }
            catch (Exception ex)
            {
                res.statuscode = HttpStatusCode.InternalServerError;
                res.message = "Something went wrong.";

                if (ex.Message.Contains("duplicate"))
                {
                    res.statuscode = HttpStatusCode.BadRequest;
                    res.message = "Duplicate promo codes not allowed.";
                }

                if (ex.Message.Contains("not_found"))
                {
                    res.statuscode = HttpStatusCode.NotFound;
                    res.message = "Promo code not found.";
                }

            }

            return res;

        }

        public Response RedeemCode(CheckRedeem redeem)
        {

            var res = new Response();
            try
            {

                
                DataTable data = _dbcon.ExecuteQuery("RedeemPromo", new SqlParameter[]
                {
                    new SqlParameter("@promo_code", redeem.promo_code),
                    new SqlParameter("@user_id", redeem.user_id)
                });

                string json = data.Rows[0]["redeem_data"].ToString()!;

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                var promos = JsonConvert.DeserializeObject<RedeemPromoData>(json, settings);

                if (promos == null)
                {
                    res.statuscode = HttpStatusCode.NotFound;
                    res.message = res.statuscode.ToString();
                }

                res.result = promos;

            }
            catch (Exception ex)
            {
                res.statuscode = HttpStatusCode.InternalServerError;
                res.message = "Something went wrong.";

                if (ex.Message.Contains("invalid_code"))
                {
                    res.statuscode = HttpStatusCode.BadRequest;
                    res.message = "The promo code is incorrect.";
                }

                if (ex.Message.Contains("already_redeemed"))
                {
                    res.statuscode = HttpStatusCode.NotFound;
                    res.message = "The promo discount has already been redeemed.";
                }

                if (ex.Message.Contains("user_not_allowed"))
                {
                    res.statuscode = HttpStatusCode.NotFound;
                    res.message = "The promo cannot be redeemed by this user.";
                }

            }

            return res;

        }

        public Response PurchasePromo(PurchasePromo purchase)
        {

            var res = new Response();
            try
            {


                DataTable data = _dbcon.ExecuteQuery("CompletePurchase", new SqlParameter[]
                {
                    new SqlParameter("@promo_id", purchase.promo_id),
                    new SqlParameter("@user_id", purchase.user_id)
                });

                string result = data.Rows[0]["done"].ToString()!;

                res.statuscode = HttpStatusCode.OK;
                res.result = result;

            }
            catch (Exception ex)
            {
                res.statuscode = HttpStatusCode.InternalServerError;
                res.message = "Something went wrong.";

                if (ex.Message.Contains("invalid_code"))
                {
                    res.statuscode = HttpStatusCode.BadRequest;
                    res.message = "The promo code is incorrect.";
                }

                if (ex.Message.Contains("already_redeemed"))
                {
                    res.statuscode = HttpStatusCode.NotFound;
                    res.message = "The promo discount has already been redeemed.";
                }

            }

            return res;

        }

    }
}
