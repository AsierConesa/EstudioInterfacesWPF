using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeCrewAsier
{
    class Shield
    {
        private int N = 8;
        private int M = 8;
        private Cell[,] map;

        public Shield(int x, int y)
        {
            map = new Cell[x,y];
            startShield();
        }

        public void startShield()
        {
            for (int i = 0; i < map.Length*map.Length; i++)
            {
                int x = i % 3;
                int y =(int) (i / map.Length);
                map[x,y] = new Cell(x, y);
            }
        }

        public Boolean isBroken(Cell cell)
        {
            return (map[cell.getRow(),cell.getColumn()].isBroken());
        }

        public void setBroken(Cell cell)
        {
            map[cell.getRow(),cell.getColumn()].setBroken(true);
        }

        public void setFixed(Cell cell)
        {
            map[cell.getRow(),cell.getColumn()].setBroken(false);
        }

        public Boolean isInside(Cell cell)
        {
            return (cell.getRow() >= 0 && cell.getRow() < N && cell.getColumn() >= 0 && cell.getColumn() < M);
        }

        public Boolean isMovementOK(int i, int j)
        {
            return (i != 0 && j != 0);
        }

        
    }
}
