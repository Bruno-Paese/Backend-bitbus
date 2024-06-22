using POC_Mongo.Src.Domain.Entities;
using POCMONGO.Domain.Entities;

namespace POCMONGO.Domain.Validators
{
    public class OpinionValidator : BaseValidator, IValidator
    {
        public bool IsValid(Entity entity)
        {
            Opinion opinion = entity as Opinion;

            if (opinion == null)
                return setError("The opinion is null");

            if (String.IsNullOrEmpty(opinion.comment))
                return setError("The opinion must have a comment");
                
            if (String.IsNullOrEmpty(opinion.socialMedia))
                return setError("The opinion must have a social media");

            return true;
        }
    }
}
