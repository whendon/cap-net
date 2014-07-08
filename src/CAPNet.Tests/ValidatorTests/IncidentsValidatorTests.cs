using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class IncidentsValidatorTests
    {
        [Fact]
        public void AlertWithIncidentNullIsValid()
        {
            var alert = new Alert();
            alert.Incidents = null;

            var incidentsValidator = new IncidentsValidator(alert);
            Assert.True(incidentsValidator.IsValid);
        }

        [Fact]
        public void AlertWithIncidentAndNoWhitespaceIsValid()
        {
            var alert = new Alert();
            alert.Incidents = "incident1";

            var incidentsValidator = new IncidentsValidator(alert);
            Assert.True(incidentsValidator.IsValid);
        }

        [Fact]
        public void AlertWithMultipleIncidentsAndSurroundedByDoubleQuotesIsValid()
        {
            var alert = new Alert();
            alert.Incidents = "\"incident1\" \"incident2\" \"incident3\"";

            var incidentsValidator = new IncidentsValidator(alert);
            Assert.True(incidentsValidator.IsValid);
        }

        [Fact]
        public void AlertWithMultipleIncidentsAndNotSurroundedByDoubleQuotesIsInvalid()
        {
            var alert = new Alert();
            alert.Incidents = "incident1 inciden2 incident3";

            var incidentsValidator = new IncidentsValidator(alert);
            Assert.False(incidentsValidator.IsValid);
            Assert.Equal(typeof(IncidentsError), incidentsValidator.Errors.ElementAt(0).GetType());
        }
    }
}
