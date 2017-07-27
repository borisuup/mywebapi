using System.Threading.Tasks;
using MyWebApi.Models;
using MyWebApi.DataProviders;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyWebApi.Controllers.Options;

namespace MyWebApi.Controllers
{
     [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private IOptionsSnapshot<OrdersOptions> _optionsAccessor;
        private MongoOrderDataProvider _repo;

        public OrdersController(IOptionsSnapshot<OrdersOptions> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor;
            _repo = new MongoOrderDataProvider(optionsAccessor.Value.ConnectionString);
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _repo.GetOrders();
        }

        [HttpGet("{id}")]
        public async Task<Order> Get( [FromQuery]string id)
        {
            return await _repo.GetOrder(id);
        }

        [HttpGet("GetOptions")]
        public OrdersOptions GetOptions()
        {
            return _optionsAccessor.Value;
        }

        [HttpPost]
        public async Task<string> Post([FromBody]Order order)
        {
            return await _repo.InsertOrder(order);
        }
    }
}
