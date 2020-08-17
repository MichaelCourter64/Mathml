using System;
using System.Collections.Generic;

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
        public static void Execute(List<Operation> operations)
        {
            if (operations == null)
            {
                return;
            }

            foreach (Operation operation in operations)
            {
                float resultOfOperation = operation.Execute();

                Console.WriteLine(
                    OUTPUT_FORMAT, 
                    operation.Username, 
                    operation.OperationName, 
                    operation.Value1, 
                    operation.OperationSymbol, 
                    operation.Value2, 
                    resultOfOperation);
            }
        }
    }
}
