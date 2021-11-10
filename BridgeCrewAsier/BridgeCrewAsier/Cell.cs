using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeCrewAsier
{
    class Cell
    {
        public int x { get; set; }
        public int y { get; set; }
        Boolean broken { get; set; }

        public Cell(int x, int y) {
            this.x = x;
            this.y = y;
            this.broken = false;
        }
        public Boolean equals(Cell c2) {
            if ((this.x == c2.x) && (this.y == c2.y))
                return true;
            else
                return false;
        }
    }
}
