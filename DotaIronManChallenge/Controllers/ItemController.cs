using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotaIronManChallenge.Models;
using DotaIronManChallenge.Repositories;
using Microsoft.AspNetCore.Hosting;

namespace DotaIronManChallenge.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ItemController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
            public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public IEnumerable<Item> ItemBuild()
        {
            var itemRepo = new ItemRepository();
            return itemRepo.GetItemBuild(_hostingEnvironment.ContentRootPath);
        }
    }
}