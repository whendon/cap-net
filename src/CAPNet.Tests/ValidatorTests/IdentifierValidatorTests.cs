using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using CAPNet.Tests;
using CAPNet.Models;

namespace CAPNet
{
    public class IdentifierValidatorTests
    {
        [Fact]
        public void IdentifierWithValidNameIsValid()
        {
            var alert = new Alert();
            alert.Identifier = "43b080713727";

            var identifierValidator = new IdentifierValidator(alert);
            Assert.True(identifierValidator.IsValid);
            Assert.Equal(0, identifierValidator.Errors.Count());
        }

        [Fact]
        public void IdentifierWithCommaIsInvalid()
        {
            var alert = new Alert();
            alert.Identifier = "43b080713727,";

            var identifierValidator = new IdentifierValidator(alert);
            Assert.False(identifierValidator.IsValid);
            Assert.Equal(1, identifierValidator.Errors.Count());
        }
    }
}
