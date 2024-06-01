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
            {
                return false;
            }

            if (visitor.Name == "")
            {
                setError("The visitors must be valid to be set in a visit: The name must be filled");
                return false;
            }

            return true;
        }
    }
}
