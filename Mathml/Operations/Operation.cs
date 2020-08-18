namespace Mathml.Operations
{
    /// <summary>
    /// An operation that uses two values, and info related to that operation.
    /// </summary>
    public abstract class Operation
    {
        /// <summary>
        /// The username of person associated with the operation.
        /// </summary>
        public string Username;

        /// <summary>
        /// The name of the operation.
        /// </summary>
        public string OperationName;

        /// <summary>
        /// Any other info associated with the operation.
        /// </summary>
        public string MiscellaneousInfo;

        /// <summary>
        /// The first value used in the operation.
        /// </summary>
        public int Value1;

        /// <summary>
        /// The second value used in the operation.
        /// </summary>
        public int Value2;

        /// <summary>
        /// The mathematical symbol that represents the operation.
        /// </summary>
        public char OperationSymbol;

        /// <summary>
        /// Execute the operation using the two values to calculate a result.
        /// </summary>
        /// <returns>The result of operating on the two values</returns>
        public abstract float Execute();
    }
}
