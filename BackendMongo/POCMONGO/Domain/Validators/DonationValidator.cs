using POC_Mongo.Src.Domain.Entities;

namespace POCMONGO.Domain.Validators
{
    public class DonationValidator: BaseValidator, IValidator
    {
        public bool IsValid(Entity donation)
        {
            if (donation == null)
                return setError("Donation is null");

            Donation d = donation as Donation;
            if (d.Ammount <= 0 || d.DonationDate == null || d.DonerName == null)
                return setError("Donation Ammount, Date or Name is invalid");

            return true;
        }
    }
}
