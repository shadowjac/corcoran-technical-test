using Corcoran.Models;

namespace Corcoran.DataAccess.Infraestructure
{
    internal class CsvConfiguration : CsvHelper.Configuration.ClassMap<PresidentModel>
    {
        public CsvConfiguration()
        {
            Map(m => m.BirthDate).Name("Birthday").Index(1);
            Map(m => m.BirthPlace).Name("Birthplace").Index(2);
            Map(m => m.DeathDate).Name("Death day").Index(3);
            Map(m => m.DeathPlace).Name("Death place").Index(4);
            Map(m => m.Name).Name("President").Index(0);
        }
    }
}
