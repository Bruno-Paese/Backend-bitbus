namespace POCMONGO.Controllers.Filter
{
    public class LectureFilter
    {
        public string person { get; set; } = "";
        public string local { get; set; } = "";
        public string datetime { get; set; } = "";

        public bool HasFilter()
        {
            if (person != "" || local != "" || datetime != "" )
            {
                return true;
            }
            return false;
        }
    }
}
