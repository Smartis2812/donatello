using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donatello.ViewModels
{
    public class BoardList
    {
        public class Board
        {
            public string Title { get; set; }
        }
        public List<Board> Boards { get; set; } = new List<Board>();
    }
}
