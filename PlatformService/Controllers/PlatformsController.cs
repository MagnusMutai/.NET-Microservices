using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepo repository;
    private readonly IMapper mapper;

    public PlatformsController(IPlatformRepo repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        Console.WriteLine("--> Getting Platforms...");
        var platformItem = repository.GetAllPlatforms();
        
        return Ok(mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
    }

    [HttpGet("{id}", Name = "GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        Console.WriteLine("--> Getting Platform...");
        var platformItem = repository.GetPlatformById(id);
        if(platformItem != null)
        {
            return Ok(mapper.Map<PlatformReadDto>(platformItem));
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public ActionResult<PlatformReadDto> CreatePlatform(PlartformCreateDto platformCreateDto)
    {
        Console.WriteLine("--> Creating a platform...");
        var platformModel = mapper.Map<Platform>(platformCreateDto);
        repository.CreatePlatform(platformModel);
        repository.SaveChanges();

        var platformReadDto = mapper.Map<PlatformReadDto>(platformModel);
        return CreatedAtRoute(nameof(GetPlatformById), new {Id = platformReadDto.Id}, platformReadDto);
    }

}