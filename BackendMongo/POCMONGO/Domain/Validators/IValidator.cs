using POCMONGO.Domain.Entities;

namespace POCMONGO.Domain.Validators
{
    public interface IValidator
    {
        public bool IsValid(Entity entity);
    }
}
