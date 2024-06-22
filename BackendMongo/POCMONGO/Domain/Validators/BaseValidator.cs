namespace POCMONGO.Domain.Validators
{
    public class BaseValidator
    {
        protected List<string> errors = new List<string>();

        protected bool setError(string error)
        {
            this.errors.Add(error);
            return false;
        }

        public List<string> getErrors()
        {
            return this.errors;
        }

        protected bool validateDate(string dateString)
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
