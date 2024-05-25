
using Microsoft.VisualStudio.TestTools.UnitTesting;

using POCMONGO.Domain.Validators;

namespace POCMONGO.Tests.Validators
{
    [TestClass]
    public class VisitorValidatorTest
    {
        [TestMethod]
        public void testIsValidOnNull()
        {
            var visitorValidator = new VisitorValidator();
            Assert.IsFalse(visitorValidator.IsValid(null));
        }
    }
}
