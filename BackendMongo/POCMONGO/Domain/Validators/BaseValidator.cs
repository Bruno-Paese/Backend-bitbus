namespace POCMONGO.Domain.Validators
{
    public class BaseValidator
    {
        protected List<string> errors = new List<string>();

        protected void setError(string error)
        {
            this.errors.Add(error);
        }

        public List<string> getErrors()
        {
            return this.errors;
        }
    }
}
