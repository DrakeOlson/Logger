using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Logger
{
    class Logger
    {
        private FileStream logFile { get; set; }
        public Logger(string fileName)
        {
            try
            {
                logFile = File.Create($"{fileName}.log");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void WriteLine(string line)
        {
            try
            {
                string formattedLine = $"{DateTime.Now} -- {line}\n";
                Byte[] writtenLine = new UTF8Encoding(true).GetBytes($"{formattedLine}\n");
                logFile.Write(writtenLine, 0, writtenLine.Length);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
