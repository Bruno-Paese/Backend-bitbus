namespace POCMONGO.Controllers.Filter
{
    public class AcervoFilter : IFilter
    {
        public string code { get; set; } = "";
        public string classification { get; set; } = "";
        public string year { get; set; } = "";
        public string category { get; set; } = "";
        public string manufacturer { get; set; } = "";
        public string storagePlace { get; set; } = "";


        public bool HasFilter()
        {
            if (code != "" || classification != "" || year != "" || category != "" || manufacturer!= "" || storagePlace != "")
            {
                return true;
            }
            return false;
        }
    }
}
