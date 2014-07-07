using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CAPNet.Models;
using Xunit;

namespace CAPNet.Tests.ValidatorTests
{
    public class InfoValidatorTests
    {
        [Fact]
        public void InfoWithRequiredFieldsIsValid()
        {
            Info info = new Info();
            //Required Fields : Categories,Event,Urgency,Severity,Certainty
            info.Categories.Add(Category.CBRNE);
            info.Event = "Event";
            info.Urgency = Urgency.Expected;
            info.Severity = Severity.Extreme;
            info.Certainty = Certainty.Likely;

            Alert alert = new Alert();
            alert.Info.Add(info);
            var infoValidator = new InfoValidator(alert);
            Assert.True(infoValidator.IsValid);
        }

        [Fact]
        public void InfoWithRequiredFieldsExceptCertaintyIsInvalid()
        {
            Info info = new Info();
            //Required Fields : Categories,Event,Urgency,Severity,Certainty
            info.Categories.Add(Category.CBRNE);
            info.Event = "Event";
            info.Urgency = Urgency.Expected;
            info.Severity = Severity.Extreme;
            //info.Certainty is missing 

            Alert alert = new Alert();
            alert.Info.Add(info);
            var infoValidator = new InfoValidator(alert);
            Assert.False(infoValidator.IsValid);

            var infoErrors = from error in infoValidator.Errors
                             where error.GetType() == typeof(CertaintyRequiredError)
                             select error;
            Assert.NotEmpty(infoErrors);
        }
    }
}
