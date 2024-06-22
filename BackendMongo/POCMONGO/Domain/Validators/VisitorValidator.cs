using POC_Mongo.Src.Domain.Entities;
using POCMONGO.Domain.Entities;

namespace POCMONGO.Domain.Validators
{
    public class VisitorValidator: BaseValidator, IValidator
    {
        public bool IsValid(Entity entity)
        {
            Visitor visitor = entity as Visitor;

            if (visitor == null)
                return setError("The visitor is null");

            if (String.IsNullOrEmpty(visitor.Name))
                setError("The visitors must be valid to be set in a visit: The name must be filled");

            return true;
        }
    }
}
