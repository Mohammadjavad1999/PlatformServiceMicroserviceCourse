using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;

namespace PlatformService.Controllers
{
    [ApiController]
    //[Produces(System.Net.Mime.MediaTypeNames.Json)]
    [Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(PlatformService.Data.IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<System.Collections.Generic.IEnumerable<PlatformService.Models.Platform>> GetPlatforms()
        {
            var Platforms = _repository.GetAll();
            return Ok(_mapper.Map<System.Collections.Generic.IEnumerable<Models.Platform>>(Platforms));
        }
        [HttpGet("{Id}", Name = "GetPlatformById")]
        public ActionResult<PlatformService.Models.Platform> GetPlatformById(int Id)
        {
            var Platform = _repository.GetPlatformById(Id);
            if (Platform != null)
            {
                return Ok(_mapper.Map<PlatformService.DTOs.PlatformReadDto>(Platform));

            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<PlatformService.DTOs.PlatformReadDto> CreatePlatform(PlatformService.DTOs.PlatformCreateDto platform)
        {
            if (platform == null)
            {
                return NotFound();
            }
            var PlatformModel = _mapper.Map<PlatformService.Models.Platform>(platform);
            _repository.CreatePlatform(PlatformModel);
            _repository.SaveChange();
            var PlatformReadDto = _mapper.Map<PlatformService.DTOs.PlatformReadDto>(PlatformModel);
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = PlatformReadDto.Id}, PlatformReadDto );

        }

    }
}