using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EVS358.PropertyHub.WebUI.Controllers
{
    public class AdvertisementsController : Controller
    {
        public IActionResult manage()
        {
            return View();
        }
    }
}