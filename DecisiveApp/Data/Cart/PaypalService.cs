using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;



namespace DecisiveApp.Data.Cart
{
    public class PayPalService
    {
        private readonly IConfiguration _configuration;

        public PayPalService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<HttpResponseMessage> CreateBillingPlan()
        {
            var httpClient = new HttpClient();

            var requestUri = "https://api.sandbox.paypal.com/v1/billing/plans";
            var requestContent = new StringContent(JsonConvert.SerializeObject(new
            {
                product_id = "1", // Replace with your product ID
                name = "Cloudbackup Essentials",
                description = "Your Plan Description",
                status = "ACTIVE",
                billing_cycles = new[]
                {
                new
                {
                    frequency = new
                    {
                        interval_unit = "MONTH",
                        interval_count = 1
                    },
                    tenure_type = "REGULAR",
                    sequence = 1,
                    total_cycles = 12 // Set the number of billing cycles
                }
            },
                payment_preferences = new
                {
                    auto_bill_outstanding = true,
                    setup_fee = new
                    {
                        value = "0.00",
                        currency_code = "USD" // Set the desired setup fee amount
                    }
                }
            }), Encoding.UTF8, "application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer access_token$sandbox$56qr9vgqbf7dx9xk$c58eb8b428bb136a5e67726864d68d3c"); // Replace with your PayPal access token

            var response = await client.PostAsync(requestUri, requestContent);
            return response;
        }
    }

}
