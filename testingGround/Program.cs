using System;
using System.Timers;

namespace testingGround
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Input Number");
            string userInput = Console.ReadLine();
            int loop = int.Parse(userInput);

      

            decimal elapsedTicks = userInput;
            decimal seccondsInET = elapsedTicks;
            decimal elapsedSecconds = elapsedTicks % 60;
            decimal minInET = (seccondsInET - elapsedSecconds) / 60;
            decimal elapsedMinute = minInET % 60;
            decimal hrsInET = (minInET - elapsedMinute) / 60;
            decimal elapsedHour = hrsInET % 24;
            decimal daysInET = (hrsInET - elapsedHour) / 24;
            decimal elapsedDay = daysInET % 7;
            decimal weeksInET = (daysInET - elapsedDay) / 7;
            decimal elapsedWeek = weeksInET;
        }
    }
}
