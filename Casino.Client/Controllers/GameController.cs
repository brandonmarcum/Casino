using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Casino.Client.Models;
using Casino.Library.Games;
using Casino.Library.Models;
using Casino.Library.Games.ChickenFight;
using Casino.Library.Games.Bingo;

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
            Dictionary<string, int> chips = new Dictionary<string, int>();
            chips["White"] = 50;
            chips["Red"] = 50;
            chips["Blue"] = 50;
            chips["Green"] = 50;
            chips["Black"] = 50;
            chips["Purple"] = 50;
            chips["Orange"] = 50;

            return View(
                new UserProfileViewModel(
                    "Brandon Marcum",
                    8,
                    3,
                    chips,
                    "Russian Roulette"
                )
            );
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

            Blackjack blackjack = new Blackjack();
            BlackJackViewModel.Blackjack = blackjack;
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
            string k = BlackJackViewModel.Blackjack.status;
            }
            catch
            {
                model = new BlackJackViewModel();
                model.Bet = bet; 
                model.Chips.Type = type;
            }


            if(submitButton.Equals("bet"))
            {
                BlackJackViewModel.Blackjack = new Blackjack();
                model.Bet = bet; 
                model.Chips.Type = type;
            }
            if(submitButton.Equals("hit"))
            {
                BlackJackViewModel.Blackjack.NextTurn();
            }
            if(submitButton.Equals("stand"))
            {
                BlackJackViewModel.Blackjack.PlayerStand();
                BlackJackViewModel.Blackjack.NextTurn();
            }
            if(BlackJackViewModel.Blackjack.status.Equals("win"))
            {
                ch.AddToPocket(newUser.UserPocket, model.Chips, 2*model.Bet*model.Chips.Value);
            }

            ViewData["bet"] = model.Bet;
            ViewData["type"] = model.Chips.Type;
            ViewData["game"] = BlackJackViewModel.Blackjack.status;
            ViewData["score"] = BlackJackViewModel.Blackjack.playerTotal;
            ViewData["dealer"] = BlackJackViewModel.Blackjack.dealerTotal;

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
            Slots slots = new Slots();
            SlotsViewModel.Slots = slots;
            return View(new SlotsViewModel());
        }
        [HttpPost]
        public IActionResult Slots(SlotsViewModel model, string submitButton)
        {
            try
            {
            model = TempData.Get<SlotsViewModel>("slots");
            string k = SlotsViewModel.Slots.status;
            }
            catch
            {
                model = new SlotsViewModel();
            }

            ViewData["left"] = SlotsViewModel.Slots.left;
            ViewData["middle"] = SlotsViewModel.Slots.middle;
            ViewData["right"] = SlotsViewModel.Slots.right;

            if(submitButton.Equals("run"))
            {
                SlotsViewModel.Slots.SetSlots();
            }
            if(submitButton.Equals("stop"))
            {
                SlotsViewModel.Slots.StopPlaying();
            }
            ViewData["status"] = SlotsViewModel.Slots.status;

            TempData.Put("slots", model);

            return View(model);
        }

        [HttpGet]
        public IActionResult RockPaperScissors()
        {
            RockPaperScissors rps = new RockPaperScissors();
            RPSViewModel.rps = rps;
            return View(new RPSViewModel());
        }
        [HttpPost]
        public IActionResult RockPaperScissors(RPSViewModel model, string submitButton)
        {
            if(submitButton == "rock" || submitButton == "paper" || submitButton == "scissors")
            {
                RPSViewModel.rps.MakeChoice(submitButton);
                
            }
            if (submitButton.Equals("play"))
            {
                RockPaperScissors rps = new RockPaperScissors();
                RPSViewModel.rps = rps;
                return View(new RPSViewModel());
                //ViewData["game"] = "bet";
            }

            TempData.Put("model", model);

            return View(model);
        }
        [HttpGet]
        public IActionResult RussianRoulette()
        {
            RussianRoulette rr = new RussianRoulette();
            RRViewModel.rr = rr;
            return View(new RRViewModel());
        }
        [HttpPost]
        public IActionResult RussianRoulette(RRViewModel model, string submitButton)
        {
            if (submitButton == "fire")
            {
                RRViewModel.rr.NextTurn();
                

                ViewData["game"] = RRViewModel.rr.status;
                if(RRViewModel.rr.PlayerGun[RRViewModel.rr.turn - 1])
                    ViewData["you"] = "BANG!";
                else
                    ViewData["you"] = "*click*";

                if (RRViewModel.rr.OpponentGun[RRViewModel.rr.turn - 1])
                    ViewData["they"] = "BANG!";
                else
                    ViewData["they"] = "*click*";

                ViewData["turn"] = RRViewModel.rr.turn.ToString();
            }
            if (submitButton == "leave")
            {
                RRViewModel.rr.PlayerLeave();
            }
            if (submitButton.Equals("play"))
            {
                RussianRoulette rr = new RussianRoulette();
                RRViewModel.rr = rr;
                return View(new RRViewModel());
                //ViewData["game"] = "bet";
            }

            TempData.Put("model", model);

            return View(model);
        }
        [HttpGet]
        public IActionResult ChickenFight()
        {
            Fight fight = new Fight();
            CFViewModel.fight = fight;
            return View(new CFViewModel());
        }
        [HttpPost]
        public IActionResult ChickenFight(CFViewModel model, string submitButton)
        {
            if (submitButton == "chickenA")
                CFViewModel.fight.PlaceBetA();
            if (submitButton == "chickenB")
                CFViewModel.fight.PlaceBetB();
            if (submitButton == "chickenA" || submitButton == "chickenB")
            {
                CFViewModel.fight.Engage();
            }
            if (submitButton.Equals("play"))
            {
                Fight fight = new Fight();
                CFViewModel.fight = fight;
                return View(new CFViewModel());
                //ViewData["game"] = "bet";
            }

            TempData.Put("model", model);

            return View(model);
        }
        [HttpGet]
        public IActionResult Bingo()
        {
            Bingo bingo = new Bingo();
            BingoViewModel.bingo = bingo;
            return View(new BingoViewModel());
        }
        [HttpPost]
        public IActionResult Bingo(BingoViewModel model, string submitButton)
        {
            if (submitButton == "start")
            {
                BingoViewModel.bingo.CommenceGame();
            }
            if (submitButton.Equals("play"))
            {
                Bingo bingo = new Bingo();
                BingoViewModel.bingo = bingo;
                return View(new BingoViewModel());
                //ViewData["game"] = "bet";
            }

            ViewData["game"] = BingoViewModel.bingo.status;

            TempData.Put("model", model);

            return View(model);
        }
    }
}
