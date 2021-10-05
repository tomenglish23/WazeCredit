using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WazeCredit.Models;
using WazeCredit.Utility.AppSettingsClasses;
using WazeCredit.Models.ViewModels;
using WazeCredit.Service;

namespace WazeCredit.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeVM homeVM { get; set; }
        private readonly IMarketForcaster _marketForcaster;
        //private readonly StripeSettings _stripeOptions;    // Moved these inside the Action injection, 
        //private readonly SendGridSettings _sendGridOptions;
        //private readonly TwilioSettings _twillioOptions;
        private readonly WazeForecastSettings _wazeOptions;

        public HomeController(IMarketForcaster marketForcaster,
                              IOptions<WazeForecastSettings> wazeOptions)    // kvp
        {
            homeVM = new HomeVM();
            _marketForcaster = marketForcaster;
            _wazeOptions = wazeOptions.Value;
        }

        public IActionResult Index()
        {
            MarketResult currentMarket = _marketForcaster.GetMarketPrediction();

            switch (currentMarket.MarketCondition)
            {
                case MarketCondition.StableDown:
                    homeVM.MarketForecast = "Market shows signs to go down in a stable state! It is a not a good sign to apply for credit applications! But extra credit is always piece of mind if you have handy when you need it.";
                    break;
                case MarketCondition.StableUp:
                    homeVM.MarketForecast = "Market shows signs to go up in a stable state! It is a great sign to apply for credit applications!";
                    break;
                case MarketCondition.Volatile:
                    homeVM.MarketForecast = "Market shows signs of volatility. In uncertain times, it is good to have credit handy if you need extra funds!";
                    break;
                default:
                    homeVM.MarketForecast = "Apply for a credit card using our application!";
                    break;
            }
            return View(homeVM);
        }

        //public IActionResult AllConfigSettingsBeforeInjectingActions()
        //{
        //    List<string> messages = new List<string>();
        //    messages.Add($"Waze config - Forecast Tracker: " + _wazeOptions.ForecastTrackerEnabled);
        //    messages.Add($"Strip Publishable Key: " + _stripeOptions.PublishableKey);
        //    messages.Add($"Stripe Secret Key: " + _stripeOptions.SecretKey);
        //    messages.Add($"Send Grid Key: " + _sendGridOptions.SendGridKey);
        //    messages.Add($"Twilio Phone: " + _twillioOptions.PhoneNumber);
        //    messages.Add($"Twilio SID: " + _twillioOptions.AccountSid);
        //    messages.Add($"Twilio Token: " + _twillioOptions.AuthToken);
        //    return View(messages);
        //}

        public IActionResult AllConfigSettings(
            [FromServices] IOptions<StripeSettings> stripeOptions,           // kvp
            [FromServices] IOptions<SendGridSettings> sendGridOptions,       // kvp
            [FromServices] IOptions<TwilioSettings> twilioOptions)           // kvp
        {
            List<string> messages = new List<string>();
            messages.Add($"Waze config - Forecast Tracker: " + _wazeOptions.ForecastTrackerEnabled); // From the ctor

            messages.Add($"Stripe Publishable Key: " + stripeOptions.Value.PublishableKey);
            messages.Add($"Stripe Secret Key: "      + stripeOptions.Value.SecretKey);
            messages.Add($"Send Grid Key: "          + sendGridOptions.Value.SendGridKey);
            messages.Add($"Twilio Phone: "           + twilioOptions.Value.PhoneNumber);
            messages.Add($"Twilio SID: "             + twilioOptions.Value.AccountSid);
            messages.Add($"Twilio Token: "           + twilioOptions.Value.AuthToken);
            return View(messages);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
