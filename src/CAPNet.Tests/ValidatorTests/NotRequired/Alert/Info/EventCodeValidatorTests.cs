using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet.Tests.ValidatorTests
{
    public class EventCodeValidatorTests
    {
        [Fact]
        public void EventCodeWithNullValueAndNullValueNameIsInvalid()
        {
            string value = null;
            string valueName = null;
            var eventCode = new EventCode(value, valueName);

            var eventCodeValidator = new EventCodeValidator(eventCode);
            Assert.False(eventCodeValidator.IsValid);
            Assert.Equal(typeof(EventCodeError), eventCodeValidator.Errors.ElementAt(0).GetType());
        }

        [Fact]
        public void EventCodeWithNullValueAndValueNameIsInvalid()
        {
            string value = null;
            string valueName = "HSAS";
            var eventCode = new EventCode(value, valueName);

            var eventCodeValidator = new EventCodeValidator(eventCode);
            Assert.False(eventCodeValidator.IsValid);
            Assert.Equal(typeof(EventCodeError), eventCodeValidator.Errors.ElementAt(0).GetType());
        }

        [Fact]
        public void EventCodeWithValueAndValueNameIsValid()
        {
            string value = "SVR";
            string valueName = "HSAS";
            var eventCode = new EventCode(value, valueName);

            var eventCodeValidator = new EventCodeValidator(eventCode);
            Assert.True(eventCodeValidator.IsValid);
        }
    }
}
