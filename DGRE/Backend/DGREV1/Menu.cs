using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading;

namespace DGRE
{
    public class Menu
    {

        Loggers LoggersMade = new Loggers();
        CalcTime NewerCalc = new CalcTime();
        int userInput = 0;
        string unfiltered = "";

        public void InvaildInput()
        {
            Console.Clear();
            Console.WriteLine("Invaild Input Try Again");
            Thread.Sleep(1000);
            Console.Clear();
        }


        public void MainMenu()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            do
            {

                Console.Clear();
                Console.WriteLine("Welcome To DGRE");
                NewerCalc.PrintCurrentTime();
                PrintLastInput();
                Console.WriteLine("(1)Take Input\n(2)Show Data\n(3)Exit");
                unfiltered = Console.ReadLine();
                try
                {
                    userInput = int.Parse(unfiltered);
                }
                catch (Exception)
                {

                    InvaildInput();
                    userInput = 0;
                }
                if (userInput != 1 && userInput != 2 && userInput != 3)
                {

                    InvaildInput();


                }
                if (userInput == 1)
                {
                    MainMenuOption1();
                }
                if (userInput == 2)
                {
                    MainMenuOption2();
                }
                if (userInput == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Good Bye Thanks For Using Degree ;)");


                }


            } while (userInput != 3);


        }

        public void MainMenuOption1()
        {
            Console.Clear();
            LoggersMade.WriteLog();
            Console.WriteLine("Input Taken");
            Thread.Sleep(1000);
            Console.Clear();

        }

        public void MainMenuOption2()
        {
            Console.Clear();
            PrintWholeLog();
            Console.WriteLine("\nTime Since Last Input");
            PrintTSLP();
            Console.WriteLine("\nPress Anything To Return To Main Menu");
            Console.ReadKey();
            Console.Clear();

        }

        public void PrintDateTime(DateTime dater)
        {
            Console.WriteLine(dater);
        }

        public void PrintLastInput()
        {
            DateTime printer1;
            List<DateTime> LogForMainMenu = new List<DateTime>();
            LogForMainMenu = LoggersMade.ReadLogToPC();
            printer1 = NewerCalc.LastInput(LogForMainMenu);
            PrintDateTime(printer1);
        }

        public void PrintTSLP()
        {
            List<DateTime> LogForPrintTSLP = new List<DateTime>();
            LogForPrintTSLP = LoggersMade.ReadLogToPC();
            TimeSpan TimeSpanForPrintTSLP;
            TimeSpanForPrintTSLP = NewerCalc.TSLPmethod(LogForPrintTSLP);
            Console.WriteLine(TimeSpanForPrintTSLP);
        }
        public void PrintWholeLog()
        {
            List<DateTime> LogForPrintWholeLog = new List<DateTime>();
            LogForPrintWholeLog = LoggersMade.ReadLogToPC();

            for (int i = 0; i < LogForPrintWholeLog.Count; i++)
            {
                Console.WriteLine($"({i + 1}){LogForPrintWholeLog[i]} ");

            }
            

        }
    }
}
