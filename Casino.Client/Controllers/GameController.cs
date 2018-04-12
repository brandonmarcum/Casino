using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Casino.Client.Models;
using Casino.Library.Games;
using Casino.Library.Models;

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
            return View(new BlackJackViewModel());
        }
        [HttpPost]
        public IActionResult BlackJack(BlackJackViewModel model, string submitButton)
        {
            User newUser = new User();
            

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
                ViewData["score"] = model.Blackjack.playerTotal;
                ViewData["dealer"] = model.Blackjack.dealerTotal;
            }
            if(submitButton.Equals("play"))
            {
                model.Blackjack = new Blackjack();
            }
            TempData.Put("model", model);

            return View(model);
        }
        [HttpGet]
        public IActionResult Slots()
        {
            return View(new SlotsViewModel());
        }
        [HttpPost]
        public IActionResult Slots(SlotsViewModel model, string submitButton)
        {
            try
            {
            model = TempData.Get<SlotsViewModel>("slots");
            string k = model.Slots.status;
            }
            catch
            {
                model = new SlotsViewModel();
            }

            ViewData["left"] = model.Slots.left;
            ViewData["middle"] = model.Slots.middle;
            ViewData["right"] = model.Slots.right;

            if(submitButton.Equals("run"))
            {
                model.Slots.SetSlots();
            }
            if(submitButton.Equals("stop"))
            {
                model.Slots.StopPlaying();
            }
            ViewData["status"] = model.Slots.status;

            TempData.Put("slots", model);

            return View(model);
        }
    }
}
