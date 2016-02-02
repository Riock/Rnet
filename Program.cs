using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Rnet.Classes;

namespace Rnet
{
    class Program
    {        
        /// <summary>
        /// All code in here will be run after the init, but before the main terminal loop. Use for testing save/load/init code
        /// </summary>
        private static void TestCode()
        {
            Load.LoadStorages();
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
            
            ConsoleHelper.ProgressValue = 50;

            AddData.Run();
            ConsoleHelper.ProgressValue = 99;

            ConsoleHelper.ProgressTotal = 0;

            #endregion Initiate program             

            TestCode();
            Controller.ConnectClient();

            ConsoleHelper.Wait("Program terminated, press any key to quit");            
        }         
    }
}
