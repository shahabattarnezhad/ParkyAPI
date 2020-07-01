using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyAPI.Models;
using ParkyAPI.Models.DTOs;
using ParkyAPI.Repository.IRepository;

namespace ParkyAPI.Controllers
{
    [Route("api/v{version:apiVersion}/nationalParks")]
    [ApiVersion("2.0")]
    //[Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "ParkyOpenAPISpecNP")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public class NationalParksV2Controller : Controller
    {
        private INationalParkRepository _npRepo;
        private readonly IMapper _mapper;
        public NationalParksV2Controller(INationalParkRepository npRepo, IMapper mapper)
        {
            _npRepo = npRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list of national parks.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<NationalParkDtos>))]
        public IActionResult GetNationalParks()
        {
            var obj = _npRepo.GetAllNationalParks().FirstOrDefault();

            return Ok(_mapper.Map<NationalParkDtos>(obj));
        }
    }
}
