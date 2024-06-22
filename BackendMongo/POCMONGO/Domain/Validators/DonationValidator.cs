using POC_Mongo.Src.Domain.Entities;

namespace POCMONGO.Domain.Validators
{
    public class DonationValidator: BaseValidator, IValidator
    {
        public bool IsValid(Entity donation)
        {
            if (donation == null)
            {
                return false;
            }

            Donation d = donation as Donation;
            if (d.Ammount == null || d.DonationDate == null || d.DonerName == null)
            {
                return false ;
            }
            if (d.Ammount <= 0|| d.DonationDate == "" || d.DonerName == "")
            {
                return false;
            }

            return true;
        }
    }
}
