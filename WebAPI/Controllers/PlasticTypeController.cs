using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    public class PlasticTypeController: BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public PlasticTypeController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        // GET api/furnishingtypes
        [HttpGet ("list")]        
        [AllowAnonymous]
        public async Task<IActionResult> GetPlasticTypes()
        {            
            var plasticTypes = await uow.PlasticTypeRepository.GetPlasticTypesAsync();
            var plasticTypesDto = mapper.Map<IEnumerable<KeyValuePairDto>>(plasticTypes);
            return Ok(plasticTypesDto);
        }

    }
}