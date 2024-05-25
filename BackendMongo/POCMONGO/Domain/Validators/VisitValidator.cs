using POC_Mongo.Src.Domain.Entities;
using POCMONGO.Domain.Entities;

namespace POCMONGO.Domain.Validators
{
    public class VisitValidator : IValidator
    {
        public bool IsValid(Entity entity)
        {
            Visit visit  = entity as Visit;

            if (visit == null) {
                return false;
            }

            if (!validateDate(visit.period))
            {
                return false;
            }

            return true;
        }

        private bool validateDate(string dateString)
        {
            try
            {
                DateTime.Parse(dateString);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
