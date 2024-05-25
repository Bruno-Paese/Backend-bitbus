using POC_Mongo.Src.Domain.Entities;
using POCMONGO.Domain.Entities;

namespace POCMONGO.Domain.Validators
{
    public interface IValidator
    {
        public bool IsValid(Entity entity);
    }
}
