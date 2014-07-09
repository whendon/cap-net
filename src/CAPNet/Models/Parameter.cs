namespace CAPNet.Models
{
    /// <summary>
    /// A system-specific additional parameter associated with the alert message 
    /// </summary>
    public class Parameter : NamedValue
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueName"></param>
        /// <param name="value"></param>
        public Parameter(string valueName, string value)
            : base(valueName, value)
        {
        }
    }
}
