using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Casino.Client.Models;
//my change hello
namespace Casino.Client.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult BlackJack()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BlackJack(string value, BlackJackViewModel model)
        {
            if(value.Equals("hit"))
            {
                model.Blackjack.PlayerHit();
                model.Blackjack.DealerHit();
                ViewData["game"] = model.Blackjack.status;
            }
            return View();
        }
    }
}
