using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using CAPNet.Tests;
using CAPNet.Models;

namespace CAPNet
{
    public class AddressesRequiredWhenScopeValidatorTests
    {
        [Fact]
        public void AlertWithAddressAndNoScopeIsValid()
        {
            var alert = new Alert();
            alert.Addresses = "list1 list2 list3";

            var addressesRequiredWhenScopeValidator = new AddressesRequiredWhenScopeValidator(alert);
            Assert.True(addressesRequiredWhenScopeValidator.IsValid);
        }

        [Fact]
        public void AlertWithAddressesAndScopePrivateIsValid()
        {
            var alert = new Alert();
            alert.Addresses = "list1 list2 list3";
            alert.Scope = Scope.Private;

            var addressesRequiredWhenScopeValidator = new AddressesRequiredWhenScopeValidator(alert);
            Assert.True(addressesRequiredWhenScopeValidator.IsValid);
        }

        [Fact]
        public void AlertWithAddressesAndScopeNoPrivateIsValid()
        {
            var alert = new Alert();
            alert.Addresses = "list1 list2 list3";
            alert.Scope = Scope.Public;

            var addressesRequiredWhenScopeValidator = new AddressesRequiredWhenScopeValidator(alert);
            Assert.True(addressesRequiredWhenScopeValidator.IsValid);
        }

        [Fact]
        public void AlertWithEmptyAddressesAndScopePrivateIsInvalid()
        {
            var alert = new Alert();
            alert.Addresses = string.Empty;
            alert.Scope = Scope.Private;

            var addressesRequiredWhenScopeValidator = new AddressesRequiredWhenScopeValidator(alert);
            Assert.False(addressesRequiredWhenScopeValidator.IsValid);
        }
    }
}
