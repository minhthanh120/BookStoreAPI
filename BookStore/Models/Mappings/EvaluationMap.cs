using BookStore.Models.Entities;
using FluentNHibernate.Mapping;

namespace BookStore.Models.Mappings
{
    public class EvaluationMap:ClassMap<Evaluation>
    {
        public EvaluationMap()
        {
            Table("Evaluation");
            Id(x => x.EvalId, "EvalId").GeneratedBy.Identity();
            Map(x=>x.Content, "Content");
            Map(x=>x.UserId, "UserId");
            Map(x=>x.Score, "Score");
            References(x => x.Book, "BookId");
        }
    }
}
