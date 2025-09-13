using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.Service.Interface;

namespace StudentAdminPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService genderService;

        public GenderController(IGenderService genderService)
        {
            this.genderService = genderService;
        }

        [HttpGet("get_all_gender")]
        public async Task<IActionResult> GetAllGenders()
        {
            var genders = await genderService.GetAllAsync();
            return Ok(genders);
        }
    }
}
