using System;
using System.Collections.Generic;
using Mathml.Operations;

namespace Mathml
{
    /// <summary>
    /// Parse, execute, and print out operations. 
    /// 
    /// Load a list of valid operations from XML. Calculate the results of those operations. 
    /// Print out the information and equation for each of those operations.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Start the application here.
        /// </summary>
        static void Main()
        {
            List<Operation> operations = XmlParser.RetrieveOperations();

            List<string> executionLogs = OperationExecuter.Execute(operations);

            PrintExecutionLogs(executionLogs);

            PauseForAcknowledgement();
        }

        private static void PrintExecutionLogs(List<string> executionLogs)
        {
            foreach (string log in executionLogs)
            {
                Console.WriteLine(log);
            }
        }

        private static void PauseForAcknowledgement()
        {
            ConsoleKeyInfo pressedKey;

            do
            {
                pressedKey = Console.ReadKey();
            } while (pressedKey.Key != ConsoleKey.Enter);
        }
    }
}
