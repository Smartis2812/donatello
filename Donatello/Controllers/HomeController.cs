using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Donatello.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Donatello.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new BoardList();

            var board = new BoardList.Board();
            board.Title = "Matt's Board";
            model.Boards.Add(board);

            var anotherBoard = new BoardList.Board();
            anotherBoard.Title = "Another Board";
            model.Boards.Add(anotherBoard);            
            return View(model);
        }
    }
}