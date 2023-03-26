using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace DGRE
{
    public class Menu
    {
        DegreeObject DGREobject = new DegreeObject();
        SQL sqler = new SQL();
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
                //PrintLastInput();
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

                    MainMenuOption1Beta();
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



        public int UserInputMethodForProjectID(string raw)
        {
            int userInput = 0;

            do
            {
                try
                {
                    userInput = int.Parse(raw);
                }
                catch (Exception)
                {
                    Console.WriteLine("Project ID must be greater than 0");
                    userInput = 0;
                }
            }
            while (userInput <= 0);
            return userInput;
        }

        public void MainMenuOption1Beta()
        {
          
            Console.Clear();
            Console.WriteLine("Input Project Id");
            AddDateTimeToSqlAsDegreeObject(UserInputMethodForProjectID(Console.ReadLine()));
            Console.WriteLine("Input Taken");
            Thread.Sleep(1000);
            Console.Clear();

        }


        public void AddDateTimeToSqlAsDegreeObject(int projectid)
        {
        
            DegreeObject objecter = new DegreeObject();
            objecter = DGREobject.DegreeObjectmaker(DateTime.Now, projectid);
            sqler.WriteToSql(objecter);
            //LoggersMade.WriteLog();

        }

        public void MainMenuOption2()
        {
            List<DegreeObject> lister = new List<DegreeObject>();
            string userInputProject_id = "";
            int userInputProject_idFiltered = 0;
            Console.Clear();
            Console.WriteLine("Input project id");
            // put this in a try
            userInputProject_id = Console.ReadLine();
            userInputProject_idFiltered = int.Parse(userInputProject_id);
            //lister = sqler.ReadFromSQl(userInputProject_idFiltered);

            foreach (DegreeObject item in lister)
            {
                Console.WriteLine(item);
            }

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
