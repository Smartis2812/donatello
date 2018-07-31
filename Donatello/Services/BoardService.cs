using Donatello.Infrastructure;
using Donatello.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donatello.Services
{
    public class BoardService
    {
        private readonly DonatelloContext dbContext;

        public BoardService(DonatelloContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public BoardList ListBoards()
        {
            var model = new BoardList();

            foreach (var board in dbContext.Boards)
            {
                model.Boards.Add(new BoardList.Board { Title = board.Title });
            }

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

        public void AddBoard(NewBoard viewModel)
        {
            dbContext.Boards.Add(new Models.Board { Title = viewModel.Title });

            dbContext.SaveChanges();
        }
    }
}
