using System;

namespace Corcoran.Models
{
    public class PresidentModel
    {
        public string Name { get; set; }
        public DateTime BirthDate{ get; set; }
        public string BirthPlace { get; set; }
        public DateTime? DeathDate { get; set; }
        public string DeathPlace { get; set; }
    }
}
