using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalker.API.Models.Domain;
using NZWalker.API.Models.DTO;
using NZWalker.API.Respositories;

namespace NZWalker.API.Controllers
{

    [Route("/api/[Controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;
        public WalksController(IMapper mappper, IWalkRepository walkRepository) {

            _mapper = mappper;
            _walkRepository = walkRepository;
        }
    

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {

            var walkDomainModel = _mapper.Map<Walk>(addWalkRequestDto);

            var createdWalk = await _walkRepository.CreateAsync(walkDomainModel);

            var walkDto = _mapper.Map<WalkDto>(createdWalk);

            // Return 201 Created with a Location header containing the new resource id
            return Created($"/api/Walks/{walkDto.Id}", walkDto);

        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        { 
            var walksDomain = await _walkRepository.GetAllAsync();

            return Ok(_mapper.Map<List<WalkDto>>(walksDomain));

        }
    }

    }
