using System.Text.RegularExpressions;

namespace POCMONGO.Controllers.Filter
{
    public class DonationFilter: IFilter
    {
        public string DonerName { get; set; } = "";
        public string StartDonationDate { get; set; } = "";
        public string EndDonationDate { get; set; } = "";

        public bool HasFilter()
        {
            return this.DonerName != "" || this.StartDonationDate != "" || this.EndDonationDate != "";
        }
        
        public Regex GetFilterRegex()
        {
            if (!HasFilter())
            {
                return null;
            }

            string searchValue = "";
            if (this.DonerName != "")
            {
                searchValue += "(" + DonerName + ")";
            }
            if (this.StartDonationDate != "")
            {
                searchValue += "(" + StartDonationDate + ")";
                ;
            }
            if (this.EndDonationDate!= "")
            {
                searchValue += "(" + EndDonationDate + ")";
            }

            return new Regex(searchValue, RegexOptions.IgnoreCase);
        }
    }
}
