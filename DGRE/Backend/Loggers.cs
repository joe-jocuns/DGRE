using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DGRE
{
    public class Loggers
    {
        // public List<DateTime> LogInfo { get; private set; } = new List<DateTime>();
        string filePath = @"E:\DGRE\Backend\logs\Logit.txt";


        public Loggers()
        {
            ReadLogToPC();
        }

        public void WriteLog()
        {

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.Flush();

                }

            }
            catch (Exception)
            {
                Console.WriteLine("Loggers not working");
            }

        }

        public List<DateTime> ReadLogToPC()
        {
            List<DateTime> LogInfo = new List<DateTime>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {

                    string lineOfInput = reader.ReadLine();
                    DateTime lineOfInputParsed = DateTime.Parse(lineOfInput);
                    LogInfo.Add(lineOfInputParsed);
                }
            }
            return LogInfo;
        }

    }
}


