using POCMONGO.Domain.Entities;

namespace POCMONGO.Controllers.DTO
{
    public class OpinionDTO
    {
        public string Id { get; set; } = "";
        public string VisitId { get; set; } = "";
        public string VisitorId { get; set; } = "";
        public float score { get; set; }
        public string comment { get; set; }
        public string socialMedia { get; set; } = "";

        public async Task<Opinion> obtainData()
        {
            Opinion opinion = new Opinion();
            opinion.Id = Id;
            opinion.score = score;
            opinion.comment = comment;
            opinion.socialMedia = socialMedia;

            opinion.visitor = new Visitor();
            opinion.visitor.Id = VisitorId;
            opinion.visitor.getById();

            opinion.visit = new Visit();
            await opinion.visit.getOne(VisitId);

            return opinion;
        }

        public async Task<OpinionDTO> parseFromOpinion(Opinion opinion)
        {
            Id = opinion.Id;
            score = opinion.score;
            comment = opinion.comment;
            socialMedia = opinion.socialMedia;

            VisitorId = opinion.visitor.Id;

            VisitId = opinion.visit.Id;
            
            return this;
        }
    }
}
