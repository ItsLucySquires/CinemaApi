using CinemaApi.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace CinemaApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class FilmController : ControllerBase
    {
        [HttpGet(Name = "GetFilms")]
        public IEnumerable<Film> Get()
        {
            return new List<Film>();
        }
    }
}
