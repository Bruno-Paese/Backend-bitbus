using POC_Mongo.Src.Domain.Entities;
using POCMONGO.Domain.Entities;

namespace POCMONGO.Domain.Validators
{
    public class VisitorValidator: IValidator
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
                return false;
            }

            return true;
        }
    }
}
