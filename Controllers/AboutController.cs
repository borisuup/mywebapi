
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyWebApi.Controllers.Options;

namespace MyWebApi.Controllers
{
     [Route("api/[controller]")]
    public class AboutController : Controller
    {
        IOptionsSnapshot<AboutOptions> _optionsAccessor;
        public AboutController(IOptionsSnapshot<AboutOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor;
        }

        [HttpGet]
        public AboutOptions GetOptions()
        {
            return _optionsAccessor.Value;
        }
    }
}