using POC_Mongo.Src.Domain.Entities;
using POCMONGO.Domain.Entities;

namespace POCMONGO.Domain.Validators
{
    public class LectureValidator : BaseValidator,  IValidator
    {
        public bool IsValid(Entity entity)
        {
            Lecture lecture = entity as Lecture;

            if (lecture == null)
                return setError("The lecture is null");

            if (String.IsNullOrEmpty(lecture.person))
                return setError("The lecture must have a person");

            if (String.IsNullOrEmpty(lecture.local))
                return setError("The lecture must have a local");

            if (!validateDate(lecture.datetime))
                return setError("The lecture must have a valid date");

            return true;
        }
    }
}
