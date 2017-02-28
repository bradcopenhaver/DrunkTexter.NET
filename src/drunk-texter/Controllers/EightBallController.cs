using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace drunk_texter.Controllers
{
    public class EightBallController : Controller
    {
        public Dictionary<string, string> Responses = new Dictionary<string, string>
        {
            ["Maybe."] = "neutral",
            ["I don't know."] = "neutral",
            ["Can you repeat the question?"] = "neutral",
            ["Why are you asking me?"] = "neutral",
            ["Yes."] = "positive",
            ["Probably."] = "positive",
            ["Definitely."] = "positive",
            ["Absolutely."] = "positive",
            ["No."] = "negative",
            ["Absolutely not."] = "negative",
            ["Of course not."] = "negative",
            ["You don't want to know."] = "negative"
    };

        public IActionResult Index(string id)
        {
            int answerIndex = new Random().Next(0, Responses.Count);
            Dictionary<string, string> response = new Dictionary<string, string>
            {
                ["question"] = id + "?",
                ["answer"] = Responses.Keys.ToList()[answerIndex],
                ["answerType"] = Responses[Responses.Keys.ToList()[answerIndex]],
                ["responseDate"] = (DateTime.Now).ToString()
            };
            return Json(response);           
        }
    }
}
