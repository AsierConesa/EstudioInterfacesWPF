using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeCrewAsier
{
    class Cell
    {
        private int row;
        private int column;
        private Boolean broken;

        public Cell()
        {
        }

        public Cell(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public int getRow()
        {
            return row;
        }

        public void setRow(int row)
        {
            this.row = row;
        }

        public int getColumn()
        {
            return column;
        }

        public void setColumn(int column)
        {
            this.column = column;
        }

        public Boolean isBroken()
        {
            return broken;
        }

        public void setBroken(Boolean broken)
        {
            this.broken = broken;
        }

        public int Distance(Cell cell)
        {
            return Math.Max(Math.Abs(this.getRow() - cell.getRow()), Math.Abs(this.getColumn() - cell.getColumn()));
        }

    public String toString()
        {
            return "(" + row + "," + column + ")";
        }


    public int hashCode()
        {
            int hash = 5;
            return hash;
        }

    public Boolean equals(Cell other)
        {
            
            if (this.row != other.row)
            {
                return false;
            }
            if (this.column != other.column)
            {
                return false;
            }
            return true;
        }
    }
}
