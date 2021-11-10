using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeCrewAsier
{
    class Fixer
    {

        public void fixPath(Cell source, Cell target, Shield board)
        {
            Cell aux = null;
            while (!(source.equals(target)))
            {
                Random randomizator = new Random();
                int i = randomizator.Next(-1, 1); //coger numero aleatorio del -1 al 1 (i)


                int j = randomizator.Next(-1, 1); //coger numero aleatorio del -1 al 1 (j)


                aux = new Cell(source.getRow() + i, source.getColumn() + j);
                if (board.isInside(aux))
                {
                    if (aux.Distance(target) < source.Distance(target))
                    {
                        source = aux;
                        board.setFixed(source);
                    }
                }
            }
        }
    }
}
