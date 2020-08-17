using Mathml.Operations;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Mathml
{
    /// <summary>
    /// Helper for parsing operations from a predetermined XML file.
    /// </summary>
    public class XmlParser
    {
        private const string INPUT_FILE = "Data/math.xml";

        private const string DESCRIPTION_NAME = "Description";
        private const char DESCRIPTION_DIVIDER = ';';

        private const string VALUE1_NAME = "Value1";
        private const string VALUE2_NAME = "Value2";

        private const short USERNAME = 0;
        private const short OPERATION_NAME = 1;
        private const short MISCELLANEOUS = 2;

        private enum OperationName
        {
            Add,
            Subtract,
            Multiply,
            Divide
        }
        private const char ADDITION_SYMBOL = '+';
        private const char SUBTRACTION_SYMBOL = '-';
        private const char MULTIPLACATION_SYMBOL = '*';
        private const char DIVISION_SYMBOL = '/';

        /// <summary>
        /// Parses operations from a predertmined XML file. Operations with bad values will be skipped.
        /// </summary>
        /// <returns>The successfully parsed operations</returns>
        public static List<Operation> RetrieveOperations()
        {
            XDocument doc = XDocument.Load(INPUT_FILE);
            List<Operation> parsedOperations = new List<Operation>();

            foreach (XElement xmlOperation in doc.Root.Elements())
            {
                Operation parsedOperation = ParseXmlOperation(xmlOperation);
                
                if (parsedOperation != null)
                {
                    parsedOperations.Add(parsedOperation);
                }
            }

            return parsedOperations;
        }

        private static Operation ParseXmlOperation(XElement xmlOperation)
        {
            // Description
            XElement descriptionElement = xmlOperation.Element(DESCRIPTION_NAME);
            string[] parsedDescription = descriptionElement.Value.Split(DESCRIPTION_DIVIDER);

            // Values
            XElement value1Element = xmlOperation.Element(VALUE1_NAME);
            XElement value2Element = xmlOperation.Element(VALUE2_NAME);
            bool value1WasConverted = int.TryParse(value1Element.Value, out int value1);
            bool value2WasConverted = int.TryParse(value2Element.Value, out int value2);

            // Operation type
            bool operationTypeWasParsed = Enum.TryParse(xmlOperation.Name.LocalName, out OperationName kindOfOperation);
            Operation parsedOperation;

            // If either value isn't an integer, then skip it:
            if (!value1WasConverted || !value2WasConverted)
            {
                return null;
            }

            // If the operation wasn't recognized, then skip it:
            if (!operationTypeWasParsed)
            {
                return null;
            }

            switch (kindOfOperation)
            {
                case OperationName.Add:
                    parsedOperation = new Addition();
                    AssignOperationValues(parsedOperation, parsedDescription, value1, value2);
                    parsedOperation.OperationSymbol = ADDITION_SYMBOL;
                    return parsedOperation;
                case OperationName.Subtract:
                    parsedOperation = new Subtraction();
                    AssignOperationValues(parsedOperation, parsedDescription, value1, value2);
                    parsedOperation.OperationSymbol = SUBTRACTION_SYMBOL;
                    return parsedOperation;
                case OperationName.Multiply:
                    parsedOperation = new Multiplication();
                    AssignOperationValues(parsedOperation, parsedDescription, value1, value2);
                    parsedOperation.OperationSymbol = MULTIPLACATION_SYMBOL;
                    return parsedOperation;
                case OperationName.Divide:
                    parsedOperation = new Division();
                    AssignOperationValues(parsedOperation, parsedDescription, value1, value2);
                    parsedOperation.OperationSymbol = DIVISION_SYMBOL;
                    return parsedOperation;
                default:
                    return null;
            }
        }

        private static void AssignOperationValues(Operation operation, string[] parsedDescription, int value1, int value2)
        {
            operation.Username = parsedDescription[USERNAME];
            operation.OperationName = parsedDescription[OPERATION_NAME];
            operation.MiscellaneousInfo = parsedDescription[MISCELLANEOUS];
            operation.Value1 = value1;
            operation.Value2 = value2;
        }
    }
}
