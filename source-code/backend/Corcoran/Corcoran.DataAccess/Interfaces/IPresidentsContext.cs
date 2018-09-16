using System.Collections.Generic;
using Corcoran.Models;

namespace Corcoran.DataAccess.Interfaces
{
    public interface IPresidentsContext
    {
        IEnumerable<PresidentModel> GetAll(string order = "ASC");
    }
}