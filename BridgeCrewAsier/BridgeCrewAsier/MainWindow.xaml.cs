using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        }
        int segundos = 0;
        private void btn_init_Click(object sender, RoutedEventArgs e)
        {
            prb_shield.Value = 0;

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync(2500);

        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int max = (int)e.Argument;
            int result = 0;
            for (int i = 0; i < max; i++)
            {
                int progressPercentage = Convert.ToInt32(((double)i / max) * 100);
                if (i % 42 == 0)
                {
                    result++;
                    (sender as BackgroundWorker).ReportProgress(progressPercentage, i);
                }
                else
                    (sender as BackgroundWorker).ReportProgress(progressPercentage);
                System.Threading.Thread.Sleep(1);

            }
            e.Result = result;

            

        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prb_shield.Value = e.ProgressPercentage;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //crea un Shield (8x8)
            //cada 5 segundos, coje dos casillas aleatorias del shield
            //si al menos uno está roto, F no haces nada
            //si no:
            //80%: ejecuta la funcion del path y arregla casillas
            //20%: se desactivan los dos cuadraos

            int dimension = 8;
            Shield shield = new Shield(dimension, dimension);

            Random randomizator = new Random();
            int x1 = randomizator.Next(0, dimension - 1);
            int y1 = randomizator.Next(0, dimension - 1);

            int x2 = randomizator.Next(0, dimension - 1);
            int y2 = randomizator.Next(0, dimension - 1);

            Cell c1 = new Cell(x1, y1);
            Cell c2 = new Cell(x2, y2);

            if (!(shield.isBroken(c1) || shield.isBroken(c2)))
            {
                //ninguno está roto
                int percentage = randomizator.Next(1, 100);
                if (percentage <= 80)
                {
                    //repara
                    Fixer fixer = new Fixer();
                    //no funciona el metodo, hay bucle infinito
                //    fixer.fixPath(c1, c2, shield);
                }
                else
                {
                    //rompe
                    shield.setBroken(c1);
                    shield.setBroken(c2);
                }
            }
            //actualiza las casillas del grid real comparando con el shield
            for (int i = 0; i < dimension * dimension; i++)
            {
                int x = i % dimension;
                int y = (int)(i / dimension);
                String imgName = "img_" + x + y;
                Image img = (Image)FindName(imgName);
                if (shield.isBroken(new Cell(x, y)))
                {
                    //está mal
                    img.Source = new BitmapImage(new Uri(@"/images/broken_shield.png", UriKind.Relative));
                }
                else
                {
                    //está mal
                    img.Source = new BitmapImage(new Uri(@"/images/shield.png", UriKind.Relative));
                }
            }
            segundos += 5;
            if (segundos < 60 * 10) { 
                BackgroundWorker worker1 = new BackgroundWorker();
                worker1.WorkerReportsProgress = true;
                worker1.DoWork += worker_DoWork;
                worker1.ProgressChanged += worker_ProgressChanged;
                worker1.RunWorkerCompleted += worker_RunWorkerCompleted;
                worker1.RunWorkerAsync(2500);
            }
        }

        
    }
}
