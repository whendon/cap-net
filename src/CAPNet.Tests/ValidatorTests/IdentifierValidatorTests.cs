using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class IdentifierValidatorTests
    {
        [Fact]
        public void IdentifierWithValidNameIsValid()
        {
            var alert = new Alert();
            alert.Identifier = "43b080713727";

            var identifierValidator = new IdentifierRequiredValidator(alert);
            Assert.True(identifierValidator.IsValid);
            Assert.Equal(0, identifierValidator.Errors.Count());
        }

        [Fact]
        public void IdentifierWithCommaIsInvalid()
        {
            var alert = new Alert();
            alert.Identifier = "43b080713727,";

            var identifierValidator = new IdentifierRequiredValidator(alert);
            Assert.False(identifierValidator.IsValid);
            Assert.Equal(1, identifierValidator.Errors.Count());
        }
    }
}
