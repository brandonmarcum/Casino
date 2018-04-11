using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Casino.Client.Models;
using Casino.Library.Games;
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
            TempData.Put("model", new BlackJackViewModel());
            return View();
        }
        [HttpPost]
        public IActionResult BlackJack(BlackJackViewModel model, string submitButton)
        {
            model = TempData.Get<BlackJackViewModel>("model");

            if(submitButton.Equals("hit"))
            {
                model.Blackjack.NextTurn();
                ViewData["game"] = model.Blackjack.status;
                ViewData["score"] = model.Blackjack.playerTotal;
                ViewData["dealer"] = model.Blackjack.dealerTotal;
            }
            if(submitButton.Equals("stand"))
            {
                model.Blackjack.PlayerStand();
                model.Blackjack.NextTurn();
                ViewData["game"] = model.Blackjack.status;
            }
            TempData.Put("model", model);
            return View(model);
        }
    }
}
