namespace Cake.XComponent.Exception
{
    /// <summary>
    /// XComponent Exception
    /// </summary>
    public class XComponentException : System.Exception
    {
        /// <summary>
        /// Constructor of XComponent Exception
        /// </summary>
        /// <param name="message">The exception message</param>
        public XComponentException(string message) : base(message)
        {
        }
    }
}