namespace POCMONGO.Domain.Validators
{
    public class ItemCategories : BaseValidator
    {
        public static readonly int CPU = 0;
        public static readonly int RAM = 1;
        public static readonly int DISK = 2;
        public static readonly int SERVER = 3;
        public static readonly int BOARDS = 4;
        public static readonly int PHONE = 5;

        public bool IsValid(int itemCategory)
        {
            int[] possibleCategories = [
                CPU, RAM, DISK, SERVER, BOARDS, PHONE
                ];
            if (possibleCategories.Contains(itemCategory))
            {
                return true;
            }

            return false;
        }
    }
}
