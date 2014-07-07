using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using CAPNet.Tests;
using CAPNet.Models;

namespace CAPNet
{
    public class SenderValidatorTests
    {
        [Fact]
        public void SenderWithValidNameIsValid()
        {
            var alert = new Alert();
            alert.Sender = "hsas@dhs.gov";

            var senderValidator = new SenderRequiredValidator(alert);
            Assert.True(senderValidator.IsValid);
            Assert.Equal(0, senderValidator.Errors.Count());
        }

        [Fact]
        public void SenderWithCommaIsInvalid()
        {
            var alert = new Alert();
            alert.Sender = "hsas@dhs.gov,";

            var senderValidator = new SenderRequiredValidator(alert);
            Assert.False(senderValidator.IsValid);
            Assert.Equal(1, senderValidator.Errors.Count());
        }
    }
}
