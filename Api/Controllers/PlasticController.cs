using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Dtos;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PlasticController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IPhotoService photoService;
        private readonly DataContext dc;

        public PlasticController(IUnitOfWork uow,
        IMapper mapper,
        IPhotoService photoService, DataContext dc)
        {
            this.photoService = photoService;
            this.uow = uow;
            this.mapper = mapper;
            this.dc = dc;
        }

        //plastic/list
        [HttpGet("list")]
        [Authorize]
        public async Task<IActionResult> GetPropertyList()
        {
            var userId = GetUserId();
            var plastics = await uow.PlasticRepository.GetPropertiesAsync(userId);
            var plasticListDTO = mapper.Map<IEnumerable<PlasticListDto>>(plastics);
            return Ok(plasticListDTO);
        }

        //plastic/detail/1
        [HttpGet("detail/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyDetail(int id)
        {
            var plastic = await uow.PlasticRepository.GetPropertyDetailAsync(id);
            var plasticDTO = mapper.Map<PlasticDto>(plastic);
            return Ok(plasticDTO);
        }

        //plastic/add
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddProperty(PlasticDto plasticDto)
        {
            var plastic = mapper.Map<Plastic>(plasticDto);
            var userId = GetUserId();
            plastic.PostedBy = userId;
            plastic.EstPossessionOn = System.DateTime.Now;
            plastic.PostedOn = System.DateTime.Now;
            uow.PlasticRepository.AddProperty(plastic);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        // plastic/trackDay
        [HttpGet("trackDay")]
        [Authorize]
        public IActionResult trackDay()
        {
            var daily_wt = 0;
            DateTime dateStart = DateTime.Now.AddDays(-1);
            DateTime dateNow = DateTime.Now;

            var userId = GetUserId();
            var plastics = from plastic in dc.Plastic
            .Where(p => p.PostedBy == userId)
            .Where(p => (p.EstPossessionOn >= dateStart && p.EstPossessionOn <= dateNow ))
            select new
            {
                quantity = plastic.quantity,
                weight = plastic.wt
            };

            foreach(var plast in plastics)
            {
                daily_wt += plast.quantity * plast.weight;
            }
                        
            return Ok(daily_wt);
        }


        [HttpGet("trackWeek")]
        [Authorize]
        public IActionResult trackWeek()
        {
            var week_wt = 0;
            DateTime dateStart = DateTime.Now.AddDays(-7);
            DateTime dateNow = DateTime.Now;

            var userId = GetUserId();
            var plastics = from plastic in dc.Plastic
            .Where(p => p.PostedBy == userId)
            .Where(p => (p.EstPossessionOn >= dateStart && p.EstPossessionOn <= dateNow))
                           select new
                           {
                               quantity = plastic.quantity,
                               weight = plastic.wt
                           };

            foreach (var plast in plastics)
            {
                week_wt += plast.quantity * plast.weight;
            }

            return Ok(week_wt);
        }


        [HttpGet("trackMonth")]
        [Authorize]
        public IActionResult trackMonth()
        {
            var month_wt = 0;
            DateTime dateStart = DateTime.Now.AddDays(-30);
            DateTime dateNow = DateTime.Now;

            var userId = GetUserId();
            var plastics = from plastic in dc.Plastic
            .Where(p => p.PostedBy == userId)
            .Where(p => (p.EstPossessionOn >= dateStart && p.EstPossessionOn <= dateNow))
                           select new
                           {
                               quantity = plastic.quantity,
                               weight = plastic.wt
                           };

            foreach (var plast in plastics)
            {
                month_wt += plast.quantity * plast.weight;
            }

            return Ok(month_wt);
        }


        //plastic/add/photo/1
        [HttpPost("add/photo/{propId}")]
        [AllowAnonymous]
        public async Task<IActionResult> AddPropertyPhoto(IFormFile file, int propId)
        {
            var result = await photoService.UploadPhotoAsync(file);
            if(result.Error != null) 
                return BadRequest(result.Error.Message);
            
            var plastic = await uow.PlasticRepository.GetPropertyByIdAsync(propId);

            var photo = new Photo
            {
                ImageUrl = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId 
            };
            if(plastic.Photos.Count == 0)
            {
                photo.IsPrimary = true;
            }

            plastic.Photos.Add(photo);
            await uow.SaveAsync();
            return StatusCode(201);
        }




    }
}