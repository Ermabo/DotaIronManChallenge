using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotaIronManChallenge.Models;
using DotaIronManChallenge.Repositories;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace DotaIronManChallenge.Controllers
{
    [Route("api/[controller]")]
    public class HeroController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public HeroController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[action]")]
        public Hero RandomHero()
        {
            var heroRepo = new HeroRepository();
            return heroRepo.GetRandomHero(_hostingEnvironment.ContentRootPath);
        }
    }
}