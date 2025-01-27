﻿using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        //Loosely coupled , esnek bağlantı  , yani sadece imzaya (interface) ye bağlısın böylelikle manager(concrete)
        //değişssede bir sıkıtn oolmaz
        //IoC Container --- Inversion of Control
        private ICarManager _carManager;
        public CarsController(ICarManager carManager)
        {
            _carManager = carManager;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Dependecy chain bağlımlılık zinciri car manager efcardal'a bağımlı
            //CarManager carManager = new CarManager(new EfCarDal());
            var result = _carManager.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult GetById(int id)
        {
            var result = _carManager.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbrand")]
        public IActionResult GetByBrand(int brandId)
        {
            var result = _carManager.GetByBrand(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcolor")]
        public IActionResult GetByColor(int colorId)
        {
            var result = _carManager.GetByColor(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
             
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carManager.Add(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carManager.Delete(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        //[HttpDelete("delete")]
        //public IActionResult Delete(Car car)
        //{
        //    var result = _carManager.Delete(car);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    return BadRequest(result.Message);
        //}

        [HttpPut("update")]
        public IActionResult Update(Car car)
        {
            var result = _carManager.Update(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("details")]
        public IActionResult GetDetails()
        {
            var result = _carManager.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        

        [HttpGet("detailsbyid")]
        public IActionResult GetDetailId(int carId)
        {
            var result = _carManager.GetCarDetailsId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("detailsbybrandid")]
        public IActionResult GetDetailBrandId(int brandId)
        {
            var result = _carManager.GetCarDetailsByBrand(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("detailsbycolorid")]
        public IActionResult GetDetailColorId(int colorId)
        {
            var result = _carManager.GetCarDetailsByColor(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getpricefilter")]
        public IActionResult GetPriceFilter(int min , int max)
        {
            var result = _carManager.GetUnitPriceFilter(min,max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
