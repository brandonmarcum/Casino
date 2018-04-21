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
            
            Dictionary<string, int> chips = new Dictionary<string, int>();
            chips["White"] = 65;
            chips["Red"] = 65;
            chips["Blue"] = 65;
            chips["Green"] = 65;
            chips["Black"] = 65;
            chips["Purple"] = 65;
            chips["Orange"] = 65;
            return View(new UserProfileViewModel("Brandon Marcum", 8, 3 , chips, "Russian Roulette"));
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
            Blackjack blackjack = new Blackjack();
            BlackJackViewModel.Blackjack = blackjack;
            Chips chips = new Chips();
            BlackJackViewModel.Chips = chips;

            //BlackJackViewModel model = GameHelper.GetBlackJackViewModel().GetAwaiter().GetResult();
            //User newUser = model.Users[0];
            //User newUser = new User();
            //newUser.Name = "jermine";
            //newUser.UserPocket.AllChips[0].Amount = 237;
            
            BlackJackViewModel.User.UserPocket.AllChips[0].Amount = 237; 
            BlackJackViewModel.User.UserPocket.AllChips[1].Amount = 314;
            BlackJackViewModel.User.UserPocket.AllChips[2].Amount = 5798;
            BlackJackViewModel.User.UserPocket.AllChips[3].Amount = 221;
            BlackJackViewModel.RequestId = "5";
            //model.User = newUser;


            
            //GameHelper.PostBlackjackViewModel(model);
            //Console.WriteLine(model + " " + model.RequestId);

            ViewData["game"] = "bet";

            return View();
        }
        [HttpPost]
        public IActionResult BlackJack(IFormCollection collection, string submitButton)
        {

            ChipHelper ch = new ChipHelper();
            
            foreach(var item in (new Pocket()).AllChips)
            {
                int intThrow;
				if (Int32.TryParse(collection[item.Type], out intThrow))
				{
					BlackJackViewModel.Blackjack.GamePocket.AllChips.Add(new Chips() { Amount = Int32.Parse(collection[item.Type]), Type = item.Type });
				}
            }

            ch.pocketSubtraction(BlackJackViewModel.User.UserPocket, BlackJackViewModel.Blackjack.GamePocket);

            if(submitButton.Equals("bet"))
            {
                foreach(var item in BlackJackViewModel.Blackjack.GamePocket.AllChips)
                {
                    if(item.Amount>0)
                    {
                        BlackJackViewModel.Bet.Add(item.Type, item.Amount); 
                    }
                }
                BlackJackViewModel.User.UserPocket.AllChips[0].Amount = 237;
                BlackJackViewModel.User.UserPocket.AllChips[1].Amount = 314;
                BlackJackViewModel.User.UserPocket.AllChips[2].Amount = 5798;
                BlackJackViewModel.User.UserPocket.AllChips[3].Amount = 221;
            }
            else{
                BlackJackViewModel.Blackjack.playerTotal = HttpContext.Session.Get<int>("playerTotal");
                BlackJackViewModel.Blackjack.dealerTotal = HttpContext.Session.Get<int>("dealerTotal");
                BlackJackViewModel.Bet = HttpContext.Session.Get<IDictionary<string, int>>("bet");

                BlackJackViewModel.User.UserPocket.AllChips = HttpContext.Session.Get<List<Chips>>("chips");
            }


            if(submitButton.Equals("hit"))
            {
                BlackJackViewModel.Blackjack.NextTurn();

                HttpContext.Session.Set<int>("playerTotal", BlackJackViewModel.Blackjack.playerTotal);
                HttpContext.Session.Set<int>("dealerTotal", BlackJackViewModel.Blackjack.dealerTotal);

            }
            if(submitButton.Equals("stand"))
            {
                BlackJackViewModel.Blackjack.PlayerStand();
                BlackJackViewModel.Blackjack.NextTurn();

                HttpContext.Session.Set<int>("playerTotal", BlackJackViewModel.Blackjack.playerTotal);
                HttpContext.Session.Set<int>("dealerTotal", BlackJackViewModel.Blackjack.dealerTotal);
            }
            if(BlackJackViewModel.Blackjack.status.Equals("win"))
            {
                ch.pocketAddition(BlackJackViewModel.User.UserPocket, BlackJackViewModel.Blackjack.GamePocket);
                ch.pocketAddition(BlackJackViewModel.User.UserPocket, BlackJackViewModel.Blackjack.GamePocket);
            }

            ViewData["game"] = BlackJackViewModel.Blackjack.status;
            HttpContext.Session.Set<IDictionary<string, int>>("bet", BlackJackViewModel.Bet);                

            if(submitButton.Equals("play"))
            {
                BlackJackViewModel.Blackjack = new Blackjack();
                HttpContext.Session.Set<int>("playerTotal", BlackJackViewModel.Blackjack.playerTotal);
                HttpContext.Session.Set<int>("dealerTotal", BlackJackViewModel.Blackjack.dealerTotal);
            }

            HttpContext.Session.Set<List<Chips>>("chips", BlackJackViewModel.User.UserPocket.AllChips);

            return View();
        }
        [HttpGet]
        public IActionResult Slots()
        {
            Slots slots = new Slots();
            SlotsViewModel.Slots = slots;
            return View();
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

            //ViewData["userChips"] = newUser.UserPocket.AllChips;

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

            return View();
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

                ViewData["game"] = RPSViewModel.rps.status;
                ViewData["you"] = RPSViewModel.rps.playerChoice;
                ViewData["they"] = RPSViewModel.rps.cpuChoice;
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
            RussianRoulette roulette = new RussianRoulette();
            RRViewModel.rr = roulette;
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
                RussianRoulette roulette = new RussianRoulette();
                RRViewModel.rr = roulette;
                return View(new RRViewModel());
                //ViewData["game"] = "bet";
            }

            TempData.Put("model", model);

            return View(model);
        }
        [HttpGet]
        public IActionResult ChickenFight()
        {
            Fight chickenFight = new Fight();
            CFViewModel.fight = chickenFight;
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
                Fight chickenFight = new Fight();
                CFViewModel.fight = chickenFight;
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
