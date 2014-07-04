using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using CAPNet.Tests;
using CAPNet.Models;

namespace CAPNet.Tests.ValidatorTests
{
    public class MsgTypeRejectionValidatorTests
    {
        [Fact]
        public void MsgTypeWithErrorThatHasExplanationInNoteIsValid()
        {
            var alert = new Alert();
            alert.MessageType = MessageType.Error;
            alert.Note = "DescriptiveError";

            var msgTypeRejectionValidator = new MsgTypeRejectionValidator(alert);
            Assert.True(msgTypeRejectionValidator.IsValid);
        }

        [Fact]
        public void MsgTypeWithErrorThatHasExplanationInNoteNullIsInvalid()
        {
            var alert = new Alert();
            alert.MessageType = MessageType.Error;
            alert.Note = null;

            var msgTypeRejectionValidator = new MsgTypeRejectionValidator(alert);
            Assert.False(msgTypeRejectionValidator.IsValid);
        }

        [Fact]
        public void MsgTypeWithNoErrorThatHasExplanationInNoteIsValid()
        {
            var alert = new Alert();
            alert.MessageType = MessageType.Cancel;
            alert.Note = "Descriptive Explanation";

            var msgTypeRejectionValidator = new MsgTypeRejectionValidator(alert);
            Assert.True(msgTypeRejectionValidator.IsValid);
        }

        [Fact]
        public void MsgTypeWithNoErrorThatHasNotExplanationInNoteIsValid()
        {
            var alert = new Alert();
            alert.MessageType = MessageType.Cancel;
            alert.Note = null;

            var msgTypeRejectionValidator = new MsgTypeRejectionValidator(alert);
            Assert.True(msgTypeRejectionValidator.IsValid);
        }
    }
}
