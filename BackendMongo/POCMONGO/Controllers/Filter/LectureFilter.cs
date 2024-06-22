namespace POCMONGO.Controllers.Filter
{
    public class LectureFilter
    {
        public string person { get; set; } = "";
        public string local { get; set; } = "";
        public string datetime { get; set; } = "";
        public string duration { get; set; } = "";
        public string resume { get; set; } = "";
        public string brief { get; set; } = "";

        public bool HasFilter()
        {
            if (person != "" || local != "" || datetime != "" || duration != "" || resume != "" || brief != "")
            {
                return true;
            }
            return false;
        }
    }
}
