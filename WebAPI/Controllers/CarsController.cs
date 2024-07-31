using Business.Abstract;
using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    //burda api/controllerAdı/api ucu seklinde postmana istek atilir

    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet("getDetail")]
        public IActionResult GetCarDetail()
        {
            var result = _carService.GetCarDetail();
            if (result.Success == true)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }

            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }

            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }

            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getByBrand")]
        public IActionResult GetByBrand(int brandId)
        { 
            var result=_carService.GetByBrandId(brandId);

            if (result.Success)
            {
                return Ok(result);
            }

            else
            {
                return BadRequest(result);
            }


        }
        [HttpGet("getByColor")]
        public IActionResult GetByColor(int colorId)
        {
            var result = _carService.GetByBrandId(colorId);

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
