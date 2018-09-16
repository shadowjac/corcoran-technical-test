using Corcoran.DataAccess.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace Corcoran.WebApi.Controllers
{
    [RoutePrefix("api/presidents")]
    public class PresidentsController : ApiController
    {
        public IPresidentsContext PresidentsContext { get; set; }

        [Route("")]
        public async Task<IHttpActionResult> Get(string order = "ASC")
        {
            var presidents = PresidentsContext.GetAll(order);
            return Ok(presidents);
        }
    }
}
