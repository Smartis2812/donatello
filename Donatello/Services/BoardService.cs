using Donatello.Infrastructure;
using Donatello.ViewModels;
using Microsoft.EntityFrameworkCore;
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
                model.Boards.Add(new BoardList.Board { Title = board.Title, Id = board.Id });
            }

            return model;
        }

        public BoardView GetBoard(int id)
        {
            var model = new BoardView();

            var board = dbContext.Boards
                .Include(b => b.Columns)    // Init Lazy Loading of Relation
                .ThenInclude(c => c.Cards)
                .SingleOrDefault(x => x.Id == id);

            foreach (var item in board.Columns)
            {
                var modelColumn = new BoardView.Column();
                modelColumn.Title = item.Title;

                foreach (var card in item.Cards)
                {
                    var modelCard = new BoardView.Card();
                    modelCard.Content = card.Contents;
                    modelColumn.Cards.Add(modelCard);
                }

                model.Columns.Add(modelColumn);                    
            }

            return model;
        }

        public void AddBoard(NewBoard viewModel)
        {
            dbContext.Boards.Add(new Models.Board { Title = viewModel.Title });

            dbContext.SaveChanges();
        }
    }
}
