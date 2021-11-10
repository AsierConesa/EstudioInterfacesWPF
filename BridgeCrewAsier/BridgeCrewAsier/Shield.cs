using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeCrewAsier
{
    class Shield
    {
        Cell[,] shield;

        public Shield(int row, int col)
        {
            shield = new Cell[row, col];
            for (int i = 1; i <= row * col; i++)
            {
                int x = row % i;
                int y = (int)i / row;
                shield[x, y] = new Cell(x, y);
            }
        }

        public void fixPath(Cell source, Cell target)
        {
            //con calma me lo implementas bro

        }
    }
}
