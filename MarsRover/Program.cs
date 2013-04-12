using System;
using System.IO;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var text = File.ReadAllText("input.txt");
                var marsRoverProcessor = new MarsRoverProcessor();
                var result = marsRoverProcessor.Process(text);
                File.WriteAllText("output.txt", result);
            }
            catch (Exception ex)
            {
                File.WriteAllText("output.txt", string.Format("Message:{0}{1}Stack Trace:{2}",ex.Message,Environment.NewLine,ex.StackTrace));
                throw;
            }
        }
    }
}
