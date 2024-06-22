using POC_Mongo.Src.Domain.Entities;
using POCMONGO.Domain.Entities;

namespace POCMONGO.Domain.Validators
{
    public class VisitValidator :BaseValidator,  IValidator
    {
        public bool IsValid(Entity entity)
        {
            Visit visit  = entity as Visit;

            if (visit == null) 
                return setError("The visit is null");

            if (!validateDate(visit.period))
                return setError("The period is not a valid date");

            if (String.IsNullOrEmpty(visit.place))
                return setError("The place must be filled");

            if (String.IsNullOrEmpty(visit.responsable))
                return setError("The responsable must be filled");

            return true;
        }
    }
}
