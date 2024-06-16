using Microsoft.VisualStudio.TestTools.UnitTesting;
using POC_Mongo.Src.Domain.Entities;
using POCMONGO.Domain.Validators;

namespace POCMONGO.Tests.Unit.Validators
{
    [TestClass]
    public class DonationValidatorTest
    {
        [TestMethod]
        public void testIsValidOnNull()
        {
            var donationValidator = new DonationValidator();
            Assert.IsFalse(donationValidator.IsValid(null));
        }

        [TestMethod]
        public void testIsValidOnEmpty() { 
            var donationValidator = new DonationValidator();
            Assert.IsFalse(donationValidator.IsValid(new Donation()));
        }

        [TestMethod]
        public void testIsValidOnValidDonation()
        {
            var donationValidator = new DonationValidator();
            Donation d = new Donation();
            d.Ammount = 100;
            d.DonerName = "Gildo";
            d.DonationDate = "08/08/2022";


            Assert.IsTrue(donationValidator.IsValid(d));
        }

        [TestMethod]
        public void testIsValidOnInvalidDonation()
        {
            var donationValidator = new DonationValidator();
            Donation d = new Donation();
            d.Ammount = 100;
            d.DonerName = "Gildo";
            d.DonationDate = null;

            Assert.IsFalse(donationValidator.IsValid(d));

            d = new Donation();
            d.Ammount = 100;
            d.DonerName = null;
            d.DonationDate = "08/08/2022";

            Assert.IsFalse(donationValidator.IsValid(d));

            d = new Donation();
            d.Ammount = 100;
            d.DonerName = "Gildo";
            d.DonationDate = "";

            Assert.IsFalse(donationValidator.IsValid(d));

            d = new Donation();
            d.Ammount = 100;
            d.DonerName = "";
            d.DonationDate = "08/08/2022";

            Assert.IsFalse(donationValidator.IsValid(d));

            d.Ammount = 0;
            d.DonerName = "Gildo";
            d.DonationDate = "08/08/2022";


            Assert.IsFalse(donationValidator.IsValid(d));

            d.Ammount = -100;
            d.DonerName = "Gildo";
            d.DonationDate = "08/08/2022";


            Assert.IsFalse(donationValidator.IsValid(d));
        }
    }
}
