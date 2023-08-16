
using System;
using Microsoft.AspNetCore.Mvc;

namespace api
{
  [ApiController]
  [Route("api")]
  public class ApiController : ControllerBase
  {
    [HttpGet]
    public Object Get() => new { Name = "Space Shuttle API", Version = 1 };
  }
}
