using Microsoft.VisualStudio.TestTools.UnitTesting;
using POCMONGO.Domain.Entities;
using POCMONGO.Domain.Validators;

namespace POCMONGO.Tests.Unit.Validators
{
    [TestClass]
    public class AcervoValidatorTest
    {

        private AcervoValidator validator;

        public void SetUp()
        {
            validator = new AcervoValidator();
        }

        [TestMethod]
        public void testValidatorOnNull()
        {
            SetUp();
            Assert.IsNotNull(validator);
            Assert.IsFalse(validator.IsValid(null));
        }

        [TestMethod]
        public void testValidatorOnInvalidName()
        {
            SetUp();

            Acervo acervo = new Acervo();
            acervo.name = "";

            Assert.IsNotNull(validator);
            Assert.IsFalse(validator.IsValid(acervo));

            acervo.name = null;
            Assert.IsFalse(validator.IsValid(acervo));
        }

        [TestMethod]
        public void testValidatorOnInvalidClassification()
        {
            SetUp();

            Acervo acervo = new Acervo();
            acervo.classification = 0;

            Assert.IsNotNull(validator);
            Assert.IsFalse(validator.IsValid(acervo));
        }

        [TestMethod]
        public void testValidatorOnValidAcervo()
        {
            SetUp();

            Acervo acervo = new Acervo();
            acervo.name = "Threadripper";
            acervo.classification = 1;

            Assert.IsNotNull(validator);
            Assert.IsTrue(validator.IsValid(acervo));
        }
    }
}
