using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet.Tests.ValidatorTests
{
    public class AlertValidatorTests
    {
        [Fact]
        public void ValidAlert()
        {
            var alert = new Alert();
            alert.Identifier = "KSTO1055887203";
            alert.Sender = "Sender";
            alert.Status = Status.Draft;
            alert.MessageType = MessageType.Alert;
            alert.Scope = Scope.Restricted;
            alert.Restriction = "Draft";
 
            var alertValidator = new AlertValidator(alert);
            Assert.True(alertValidator.IsValid);
        }
    }
}
