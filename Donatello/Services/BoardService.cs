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

        public BoardView GetBoard()
        {
            var model = new BoardView();
            var column = new BoardView.Column { Title = "ToDo" };

            var card = new BoardView.Card
            {
                Content = "Here's a card"
            };

            var card2 = new BoardView.Card
            {
                Content = "Here's another card"
            };

            column.Cards.Add(card);
            column.Cards.Add(card2);

            model.Columns.Add(column);
            return model;
        }
    }
}
