using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public PlasticController(IUnitOfWork uow,
        IMapper mapper,
        IPhotoService photoService)
        {
            this.photoService = photoService;
            this.uow = uow;
            this.mapper = mapper;
        }

        //property/list/1
        [HttpGet("list/{sellRent}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyList(int sellRent)
        {
            var plastics = await uow.PlasticRepository.GetPropertiesAsync(sellRent);
            var plasticListDTO = mapper.Map<IEnumerable<PlasticListDto>>(properties);
            return Ok(plasticListDTO);
        }

        //property/detail/1
        [HttpGet("detail/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPropertyDetail(int id)
        {
            var plastic = await uow.PlasticRepository.GetPropertyDetailAsync(id);
            var plasticDTO = mapper.Map<PlasticDetailDto>(plastic);
            return Ok(plasticDTO);
        }

        //property/add
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddProperty(PlasticDto plasticDto)
        {
            var plastic = mapper.Map<Plastic>(plasticDto);
            var userId = GetUserId();
            plastic.PostedBy = userId;
            uow.plasticRepository.AddProperty(plastic);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        //property/add/photo/1
        [HttpPost("add/photo/{propId}")]
        [Authorize]
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