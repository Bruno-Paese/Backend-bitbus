namespace POCMONGO.Controllers.Filter
{
    public class VisitFilter: IFilter
    {
        public string place { get; set; } = "";
        public string responsable { get; set; } = "";
        public string period { get; set; } = "";

        public bool HasFilter()
        {
            return this.period != null || this.place != null || this.responsable != null;
        }
    }
}
