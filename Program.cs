using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rnet.Classes;
using System.Windows.Forms;
using System.Threading;

namespace Rnet
{
    class Program
    {
        private static void Window()
        {
            Application.Run(new View());
        }

        [STAThread]
        static void Main(string[] args)
        {

            #region Initiate program
            Application.EnableVisualStyles();
            ConsoleHelper.FixEncoding();

            ConsoleHelper.ProgressTotal = 100;
            ConsoleHelper.ProgressTitle = "Loading";

            Storage.NextAvailableID = 0;
            Client.NextAvailableID = 0;

            Controller.DefaultInputColor = ConsoleColor.Blue;
            Controller.DefaultSuccesColor = ConsoleColor.Green;
            Controller.DefaultErrorColor = ConsoleColor.Red;
            Controller.DefaultColor = ConsoleColor.Yellow;
            ConsoleHelper.ProgressValue = 20;

            Thread formThread = new Thread(new ThreadStart(Window));
            formThread.Start();
            while (!formThread.IsAlive) ;
            Thread.Sleep(1);
            ConsoleHelper.ProgressValue = 50;

            AddData.Run();
            ConsoleHelper.ProgressValue = 99;

            ConsoleHelper.ProgressTotal = 0;

            #endregion Initiate program 

            

            Controller.ConnectClient();

            ConsoleHelper.Wait("Program terminated, press any key to quit");            
        }
    }
}
