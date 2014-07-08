using CAPNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class IncidentsValidator : Validator<Alert>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        public IncidentsValidator(Alert alert) : base(alert) { }

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<Error> Errors
        {
            get
            {
                if (!IsValid)
                    yield return new IncidentsError();
            }
        }
        
        /// <summary>
        /// An incident validator is not required . But when it is used , it should respect the rules : 
        ///      1. If it doesn't contain any whitespace , it is valid anyway
        ///      2. If it contains any whitespace , each incident name should be surrounded by double-quotes.
        /// </summary>
        public override bool IsValid
        {
            get
            {
                if (!string.IsNullOrEmpty(Entity.Incidents))
                {
                    if (Entity.Incidents.Contains(" "))
                    {
                        var invalidIncident = from incident in Entity.Incidents.Split(' ')
                                              where (incident[0] != '\"' || incident[incident.Length - 1] != '\"')
                                              select incident;
                        return !invalidIncident.Any();
                    }
                    else return true; // If it doesn't contain any whitespace , it is valid anyway
                }
                else return true; // If it doesn't exist , it is valid anyway
            }
        }
    }
}
