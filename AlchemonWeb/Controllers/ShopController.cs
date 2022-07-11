using System;
using Microsoft.AspNetCore.Mvc;
using AlchemonWeb.Services;
namespace AlchemonWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {

        private readonly ILogger<ShopController> _logger;
        private readonly IShopService _shopService;

        public ShopController(ILogger<ShopController> logger, IShopService shopService)
		{
            _logger = logger;
            _shopService = shopService;
		}

        [HttpGet("Test")]
        public string Test()
        {
            return _shopService.Test();
        }
    }
}

