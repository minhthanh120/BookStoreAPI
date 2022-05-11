using BookStore.Models.Entities;
using FluentNHibernate.Mapping;

namespace BookStore.Models.Mappings
{
    public class EvaluationMap:ClassMap<Evaluation>
    {
        public EvaluationMap()
        {
            Id(x => x.EvalId);
            Map(x=>x.Content);
            Map(x=>x.UserId);
            Map(x=>x.Score);
            References(x => x.Book);
        }
    }
}
