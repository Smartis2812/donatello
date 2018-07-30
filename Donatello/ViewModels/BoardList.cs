﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donatello.ViewModels
{
    public class BoardList
    {
        public List<Board> Boards { get; set; } = new List<Board>();        // Nested Classes        public class Board
        {
            public string Title { get; set; }
        }
    }
}
