using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KTEC.Core.Application.Queries;

namespace KTEC.API.Controllers
{
    public class CameraController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<CameraListVm>> GetAll()
        {
            return Ok(await Mediator.Send(new GetCameraListQuery()));
        }
    }
}
