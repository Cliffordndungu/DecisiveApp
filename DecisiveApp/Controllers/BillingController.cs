using DecisiveApp.Data.Cart;
using Microsoft.AspNetCore.Mvc;



namespace DecisiveApp.Controllers
{
    public class BillingController : Controller
    {
        private readonly PayPalService _payPalService;

        public BillingController(PayPalService payPalService)
        {
            _payPalService = payPalService;
        }

        public async Task<IActionResult> CreatePlan()
        {
            var response = await _payPalService.CreateBillingPlan();

            if (response.IsSuccessStatusCode)
            {
                // Plan creation successful
                var responseData = await response.Content.ReadAsStringAsync();
                // Parse and process the response data as needed
                // ...
                return Ok("Billing plan created successfully!");
            }
            else
            {
                // Plan creation failed
                var errorData = await response.Content.ReadAsStringAsync();
                // Parse and handle the error data as needed
                // ...
                return BadRequest("Failed to create billing plan: " + errorData);
            }
        }
    }

}
