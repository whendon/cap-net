using CAPNet.Models;
using Xunit;

namespace CAPNet
{
    public class MultipleAddressesValidatorTests
    {
        [Fact]
        public void AddressesThatContainsWhitespaceAndStartAndEndWithDoubleQuotesIsValid()
        {
            var alert = new Alert();
            alert.Addresses = "\"list1 list1\"";

            var multipleAddressesValidator = new MultipleAddressesValidator(alert);
            Assert.True(multipleAddressesValidator.IsValid);
        }

        [Fact]
        public void AddressesThatContainsWhitespaceAndDontStartAndEndWithDoubleQuotesIsInvalid()
        {
            var alert = new Alert();
            alert.Addresses = "list1 list2";

            var multipleAddressesValidator = new MultipleAddressesValidator(alert);
            Assert.False(multipleAddressesValidator.IsValid);
        }

        [Fact]
        public void AddressesThatContainsWhiteSpaceAndStartWithDoubleQuotesButDontEndWithDoubleQuotesIsInvalid()
        {
            var alert = new Alert();
            alert.Addresses = "\"list1 list2";

            var multipleAddressesValidator = new MultipleAddressesValidator(alert);
            Assert.False(multipleAddressesValidator.IsValid);
        }

        [Fact]
        public void AddressesThatDoesNotContainWhiteSpaceOrAnyQuotesIsValid()
        {
            var alert = new Alert();
            alert.Addresses = "list1";

            var multipleAddressesValidator = new MultipleAddressesValidator(alert);
            Assert.True(multipleAddressesValidator.IsValid);
        }

        [Fact]
        public void AddressesThatDoesNotContainWhiteSpaceAndStartsAndEndsWithDoubleQuotesIsValid()
        {
            var alert = new Alert();
            alert.Addresses = "\"list1\"";

            var multipleAddressesValidator = new MultipleAddressesValidator(alert);
            Assert.True(multipleAddressesValidator.IsValid);
        }
    }
}
