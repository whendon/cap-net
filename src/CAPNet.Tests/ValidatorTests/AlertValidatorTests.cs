using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet.Tests.ValidatorTests
{
    public class AlertValidatorTests
    {
        [Fact]
        public void GeneralValidAlert()
        {
            var alert = new Alert();
            alert.Identifier = "KSTO1055887203";
            alert.Sender = "Sender";
            alert.Status = Status.Draft; 
            alert.MessageType = MessageType.Error;
            alert.Note = "DescriptiveError";
            alert.Scope = Scope.Restricted;
            alert.Restriction = "Draft";
            alert.Sent = new System.DateTimeOffset();

            var info = new Info();
            var category = Category.Fire;
            //Category required
            info.Categories.Add(category);
            //Certainty required
            info.Certainty = Certainty.Observed;
            //EventRequired
            info.Event = "ImportantEvent";
            //SeverityRequired
            info.Severity = Severity.Minor;
            //UrgencyRequired
            info.Urgency = Urgency.Future;
            alert.Info.Add(info);

            var alertValidator = new AlertValidator(alert);
            Assert.True(alertValidator.IsValid);
        }
    }
}
