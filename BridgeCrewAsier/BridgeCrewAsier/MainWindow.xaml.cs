using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BridgeCrewAsier
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //crea un Shield (8x8)
            //cada 5 segundos, coje dos casillas aleatorias del shield
            //si al menos uno está roto, F no haces nada
            //si no:
            //80%: ejecuta la funcion del path y arregla casillas
            //20%: se desactivan los dos cuadraos

            int dimension = 8;
            Shield shield = new Shield(dimension, dimension);

            int seconds = 200;
            while (seconds > 0) {
                if (seconds % 5 == 0) {
                    Random randomizator = new Random();
                    int x1 = randomizator.Next(0, dimension - 1);
                    int y1 = randomizator.Next(0, dimension - 1);

                    int x2 = randomizator.Next(0, dimension - 1);
                    int y2 = randomizator.Next(0, dimension - 1);

                    Cell c1 = new Cell(x1, y1);
                    Cell c2 = new Cell(x2, y2);

                    if (!(shield.isBroken(c1) || shield.isBroken(c2))) {
                        //ninguno está roto
                        int percentage = randomizator.Next(1, 100);
                        if (percentage <= 80){
                            //repara
                            Fixer fixer = new Fixer();
                            fixer.fixPath(c1, c2, shield);
                        }
                        else {
                            //rompe
                            shield.setBroken(c1);
                            shield.setBroken(c2);
                        }
                    }
                    //actualiza las casillas del grid real comparando con el shield


                }
                
                System.Threading.Thread.Sleep(1);
                seconds++;
            }
        }
    }
}
