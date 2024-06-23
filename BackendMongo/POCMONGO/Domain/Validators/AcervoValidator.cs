using POC_Mongo.Src.Domain.Entities;
using POCMONGO.Domain.Entities;

namespace POCMONGO.Domain.Validators
{
    public class AcervoValidator :BaseValidator, IValidator
    {
        public bool IsValid(Entity entity)
        {
            Acervo acervo = entity as Acervo;

            if (acervo == null)
                return setError("The acervo is null");

            if (String.IsNullOrEmpty(acervo.name))
                return setError("The acervo must have a name");

            if (acervo.category == 0)
                return setError("The acervo must have a classification");

            return true;
        }
    }
}
