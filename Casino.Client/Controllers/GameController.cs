using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Casino.Client.Models;
using Casino.Library.Games;
using Casino.Library.Models;
using Microsoft.AspNetCore.Http;

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
        public IActionResult UserProfile()
        {
            return View(new UserProfileViewModel());
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
            BlackJackViewModel model = new BlackJackViewModel();

            //BlackJackViewModel model = GameHelper.GetBlackJackViewModel().GetAwaiter().GetResult();
            //User newUser = model.Users[0];
            //User newUser = new User();
            //newUser.Name = "jermine";
            //newUser.UserPocket.AllChips[0].Amount = 237;
            model.User.UserPocket.AllChips[0].Amount = 237; 
            model.User.UserPocket.AllChips[1].Amount = 314;
            model.User.UserPocket.AllChips[2].Amount = 5798;
            model.User.UserPocket.AllChips[3].Amount = 221;
            model.RequestId = "5";
            //model.User = newUser;


            
            //GameHelper.PostBlackjackViewModel(model);
            //Console.WriteLine(model + " " + model.RequestId);

            ViewData["game"] = "bet";

            return View(model);
        }
        [HttpPost]
        public IActionResult BlackJack(BlackJackViewModel model, IFormCollection collection, string submitButton)
        {

            //bring user from session

            model = new BlackJackViewModel();

            ChipHelper ch = new ChipHelper();
            
            foreach(var item in (new Pocket()).AllChips)
            {
                int intThrow;
				if (Int32.TryParse(collection[item.Type], out intThrow))
				{
					model.Blackjack.GamePocket.AllChips.Add(new Chips() { Amount = Int32.Parse(collection[item.Type]), Type = item.Type });
				}
            }

            ch.pocketSubtraction(model.User.UserPocket, model.Blackjack.GamePocket);

            if(submitButton.Equals("bet"))
            {
                foreach(var item in model.Blackjack.GamePocket.AllChips)
                {
                    if(item.Amount>0)
                    {
                        model.Bet.Add(item.Type, item.Amount); 
                    }
                }
                model.User.UserPocket.AllChips[0].Amount = 237; 
                model.User.UserPocket.AllChips[1].Amount = 314;
                model.User.UserPocket.AllChips[2].Amount = 5798;
                model.User.UserPocket.AllChips[3].Amount = 221;
            }
            else{
                model.Blackjack.playerTotal = HttpContext.Session.Get<int>("playerTotal");
                model.Blackjack.dealerTotal = HttpContext.Session.Get<int>("dealerTotal");
                model.Bet = HttpContext.Session.Get<IDictionary<string, int>>("bet"); 
                
                model.User.UserPocket.AllChips = HttpContext.Session.Get<List<Chips>>("chips");
            }


            if(submitButton.Equals("hit"))
            {
                model.Blackjack.NextTurn();

                HttpContext.Session.Set<int>("playerTotal", model.Blackjack.playerTotal);
                HttpContext.Session.Set<int>("dealerTotal", model.Blackjack.dealerTotal);

            }
            if(submitButton.Equals("stand"))
            {
                model.Blackjack.PlayerStand();
                model.Blackjack.NextTurn();

                HttpContext.Session.Set<int>("playerTotal", model.Blackjack.playerTotal);
                HttpContext.Session.Set<int>("dealerTotal", model.Blackjack.dealerTotal);
            }
            if(model.Blackjack.status.Equals("win"))
            {
                ch.pocketAddition(model.User.UserPocket, model.Blackjack.GamePocket);
                ch.pocketAddition(model.User.UserPocket, model.Blackjack.GamePocket);
            }

            ViewData["game"] = model.Blackjack.status;
            HttpContext.Session.Set<IDictionary<string, int>>("bet", model.Bet);                

            if(submitButton.Equals("play"))
            {
                model.Blackjack = new Blackjack();
                HttpContext.Session.Set<int>("playerTotal", model.Blackjack.playerTotal);
                HttpContext.Session.Set<int>("dealerTotal", model.Blackjack.dealerTotal);
            }

            HttpContext.Session.Set<List<Chips>>("chips", model.User.UserPocket.AllChips);

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

            //ViewData["userChips"] = newUser.UserPocket.AllChips;

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
        public IActionResult RockPaperScissors(RPSViewModel model, string submitButton)
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
            return View(new RRViewModel());
        }
        [HttpPost]
        public IActionResult RussianRoulette(RRViewModel model, string submitButton)
        {
            if (submitButton == "fire")
            {
                model.rr.NextTurn();
                

                ViewData["game"] = model.rr.status;
                if(model.rr.PlayerGun[model.rr.turn - 1])
                    ViewData["you"] = "BANG!";
                else
                    ViewData["you"] = "*click*";

                if (model.rr.OpponentGun[model.rr.turn - 1])
                    ViewData["they"] = "BANG!";
                else
                    ViewData["they"] = "*click*";

                ViewData["turn"] = model.rr.turn.ToString();
            }
            if (submitButton == "leave")
            {
                model.rr.PlayerLeave();
            }
            if (submitButton.Equals("play"))
            {
                return View(new RRViewModel());
                //ViewData["game"] = "bet";
            }

            TempData.Put("model", model);

            return View(model);
        }
        [HttpGet]
        public IActionResult ChickenFight()
        {
            return View(new CFViewModel());
        }
        [HttpPost]
        public IActionResult ChickenFight(CFViewModel model, string submitButton)
        {
            if (submitButton == "chickenA")
                model.fight.PlaceBetA();
            if (submitButton == "chickenB")
                model.fight.PlaceBetB();
            if (submitButton == "chickenA" || submitButton == "chickenB")
            {
                model.fight.Engage();
            }
            if (submitButton.Equals("play"))
            {
                return View(new CFViewModel());
                //ViewData["game"] = "bet";
            }

            TempData.Put("model", model);

            return View(model);
        }
        [HttpGet]
        public IActionResult Bingo()
        {
            return View(new BingoViewModel());
        }
        [HttpPost]
        public IActionResult Bingo(BingoViewModel model, string submitButton)
        {
            if (submitButton == "start")
            {
                model.bingo.CommenceGame();
            }
            if (submitButton.Equals("play"))
            {
                return View(new BingoViewModel());
                //ViewData["game"] = "bet";
            }

            ViewData["game"] = model.bingo.status;

            TempData.Put("model", model);

            return View(model);
        }
    }
}
