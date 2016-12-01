using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BlaBlaService.Api.Models;

namespace BlaBlaService.Api.Controllers
{
    [RoutePrefix("api/blabla")]
    public class BlaBlaController : ApiController
    {
        private readonly Models.BlaBlaService _service = new Models.BlaBlaService();

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(BlaBlaResult))]
        public async Task<IHttpActionResult> Get(string text)
        {
            return Ok(await _service.CheckBlaBlaMeterAsync(text));
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(BlaBlaResult))]
        public async Task<IHttpActionResult> Post(string text)
        {
            return Ok(await _service.CheckBlaBlaMeterAsync(text));
        }
    }
}
