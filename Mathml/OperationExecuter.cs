using System;
using System.Collections.Generic;
using Mathml.Operations;

namespace Mathml
{
    /// <summary>
    /// Execute operations and print out the results. 
    /// 
    /// The person, operation name, and equation are printed as well.
    /// </summary>
    public class OperationExecuter
    {
        private const string OUTPUT_FORMAT = "{0} - {1} - {2} {3} {4} = {5}";

        /// <summary>
        /// Execute operations and print out the results.
        /// 
        /// The person, operation name, and equation are printed as well.
        /// </summary>
        /// <param name="operations">The operations to execute and print the results of</param>
        public static List<string> Execute(List<Operation> operations)
        {
            List<string> executionLogs = new List<string>();

            if (operations == null)
            {
                return null;
            }

            foreach (Operation operation in operations)
            {
                float resultOfOperation = operation.Execute();
                string currentExecutionLog = string.Format(
                    OUTPUT_FORMAT,
                    operation.Username,
                    operation.OperationName,
                    operation.Value1,
                    operation.OperationSymbol,
                    operation.Value2,
                    resultOfOperation);

                executionLogs.Add(currentExecutionLog);
            }

            return executionLogs;
        }
    }
}
