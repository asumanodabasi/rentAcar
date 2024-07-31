using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getCars")]
        public IActionResult GetCars(int brandId)
        {
            var result = _brandService.GetCarsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }

            else
            {
                return BadRequest(result);
            }
        }
    }
}
