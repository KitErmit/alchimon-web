using System;
using Microsoft.AspNetCore.Mvc;
using AlchemonWeb.Services;
using AlchemonWeb.Models;
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

        [HttpGet("NewAl")]
        public Alchemon BuyNew()
        {
            return _shopService.BuyAnimal();
        }

        [HttpGet("Test")]
        public HashSet<Alchemon> Test()
        {
            return _shopService.Test();
        }

        [HttpGet("Karman")]
        public string GetKarman()
        {
            return _shopService.GetKarman();
        }

        [HttpPut("Hibrid")]
        public string GetHibrid(int leftAlNum, int rightAlNum)
        {
            return _shopService.GetHibrit(leftAlNum, rightAlNum);
        }
    }
}

