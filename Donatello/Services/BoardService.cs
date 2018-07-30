using Donatello.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donatello.Services
{
    public class BoardService
    {
        public BoardList ListBoards()
        {
            var model = new BoardList();

            var board = new BoardList.Board();
            board.Title = "Matt's Board";
            model.Boards.Add(board);

            var anotherBoard = new BoardList.Board();
            anotherBoard.Title = "Another Board";
            model.Boards.Add(anotherBoard);
            return model;
        }
    }
}
