using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rnet.Classes;

namespace Rnet
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Initiate program

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


            AddData.Run();
            ConsoleHelper.ProgressValue = 99;

            ConsoleHelper.ProgressTotal = 0;

            #endregion Initiate program 
            
            Controller.ConnectClient();

            ConsoleHelper.Wait("Program terminated, press any key to quit");
        }
    }
}
