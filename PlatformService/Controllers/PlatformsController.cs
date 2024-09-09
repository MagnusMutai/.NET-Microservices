using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;

namespace PlatformService.Controllers;

public class PlatformsController : ControllerBase
{
    public PlatformsController(IPlatformRepo repository, IMapper mapper)
    {
        
    }
}