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

        /// Board

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
                .Include(b => b.Columns)    // Init Lazy Loading of related Table
                .ThenInclude(c => c.Cards)
                .SingleOrDefault(x => x.Id == id);

            model.Id = board.Id;
            model.Title = board.Title;

            foreach (var item in board.Columns)
            {
                var modelColumn = new BoardView.Column();
                modelColumn.Title = item.Title;
                modelColumn.Id = item.Id;
                
                foreach (var card in item.Cards)
                {
                    var modelCard = new BoardView.Card();
                    modelCard.Content = card.Contents;
                    modelCard.Id = card.Id;
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

        /// Cards
        
        public void AddCard(AddCard viewModel)
        {
            var board = dbContext.Boards.Include(b => b.Columns).SingleOrDefault(x => x.Id == viewModel.Id);

            // If there is no Column on the Board, create one
            var firstColumn = board.Columns.FirstOrDefault();
            if (firstColumn == null)
            {                
                firstColumn = new Models.Column { Title = "ToDo" };
                board.Columns.Add(firstColumn);
            }

            firstColumn.Cards.Add(new Models.Card { Contents = viewModel.Contents });

            dbContext.SaveChanges();
        }
    }
}
