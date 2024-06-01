
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POCMONGO.Domain.Entities;
using POCMONGO.Domain.Validators;

namespace POCMONGO.Tests.Unit.Validators
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

        [TestMethod]
        public void testIsValidOnNamelessVisitor()
        {
            var visitorValidator = new VisitorValidator();

            Visitor visitor = new Visitor();
            visitor.Name = "";

            Assert.IsFalse(visitorValidator.IsValid(visitor));
        }

        [TestMethod]
        public void testIsValidOnValidVisitor()
        {
            var visitorValidator = new VisitorValidator();

            Visitor visitor = new Visitor();
            visitor.Name = "Josias Rodrigo Pinto";

            Assert.IsTrue(visitorValidator.IsValid(visitor));
        }
    }
}
