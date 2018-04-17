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
        public IActionResult Games(string anchor)
        {
            ViewBag.Section = anchor;
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult PlayGame()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UserBet(BlackJackViewModel model)
        {
            return View(model);
        }
        [HttpPost]
        public IActionResult UserBet(ChipHelperViewModel chmodel)
        {
            ViewData["type"] = chmodel.Chips.Type;
            return View();
        }
        [HttpGet]
        public IActionResult BlackJack()
        {
            User newUser = new User();
            newUser.UserPocket.AllChips[2].Amount = 50;

            ViewData["userChips"] = newUser.UserPocket.AllChips;
            ViewData["game"] = "bet";

            BlackJackViewModel model = TempData.Get<BlackJackViewModel>("model");
            return View(new BlackJackViewModel());
        }
        [HttpPost]
        public IActionResult BlackJack(BlackJackViewModel model, string type, string submitButton, int bet)
        {

            //bring user from session
            User newUser = new User();            
            newUser.UserPocket.AllChips[2].Amount = 50;
            ChipHelper ch = new ChipHelper();

            ViewData["userChips"] = newUser.UserPocket.AllChips;

            //ViewData["type"] = chmodel.Chips.Type;
            //ch.betChips(bet);

            try
            {
            model = TempData.Get<BlackJackViewModel>("model");
            string k = model.Blackjack.status;
            }
            catch
            {
                model = new BlackJackViewModel();
                model.Bet = bet; 
                model.Chips.Type = type;
            }


            if(submitButton.Equals("bet"))
            {
                model.Blackjack = new Blackjack();
                model.Bet = bet; 
                model.Chips.Type = type;
            }
            if(submitButton.Equals("hit"))
            {
                model.Blackjack.NextTurn();
            }
            if(submitButton.Equals("stand"))
            {
                model.Blackjack.PlayerStand();
                model.Blackjack.NextTurn();
            }
            if(model.Blackjack.status.Equals("win"))
            {
                ch.AddToPocket(newUser.UserPocket, model.Chips, 2*model.Bet*model.Chips.Value);
            }

            ViewData["bet"] = model.Bet;
            ViewData["type"] = model.Chips.Type;
            ViewData["game"] = model.Blackjack.status;
            ViewData["score"] = model.Blackjack.playerTotal;
            ViewData["dealer"] = model.Blackjack.dealerTotal;

            if(submitButton.Equals("play"))
            {
                ViewData["game"] = "bet";
            }

            System.Console.WriteLine("Model.Chips.Value " + model.Chips.Value);
            ch.RemoveFromPocket(newUser.UserPocket, model.Chips, model.Bet*model.Chips.Value);

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

        [HttpGet]
        public IActionResult RockPaperScissors()
        {
            return View(new RPSViewModel());
        }
        [HttpPost]
        public IActionResult RockPaperScissors(RPSViewModel model, string type, string submitButton, int bet)
        {
            if(submitButton == "rock" || submitButton == "paper" || submitButton == "scissors")
            {
                model.rps.MakeChoice(submitButton);

                ViewData["game"] = model.rps.status;
                ViewData["you"] = model.rps.playerChoice;
                ViewData["they"] = model.rps.cpuChoice;
            }
            if (submitButton.Equals("play"))
            {
                return View(new RPSViewModel());
                //ViewData["game"] = "bet";
            }

            TempData.Put("model", model);

            return View(model);
        }
        [HttpGet]
        public IActionResult RussianRoulette()
        {
            return View(new RPSViewModel());
        }
    }
}
