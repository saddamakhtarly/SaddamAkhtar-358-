using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EVS358.PropertyHub.WebUI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EVS358;
using EVS358.Handler;
using EVS358.PropertyHub.WebUI.ModelsHelper;

namespace EVS358.PropertyHub.WebUI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<PropertyAdvSummaryModel> m = new PropertyAdvsHandler().GetPropertyAdvs().ToSummaryModelList();
            return View(m);
        }


        [HttpGet]
        public IActionResult Admin()
        {
         
            return View();
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            List<SelectListItem> cities = new List<SelectListItem> { new SelectListItem { Text = "- City -", Value = "0" } };
            //cities.AddRange(new CityHandler().GetCitys.ToSelectListItemList());
            cities.AddRange(new LocationsHandler().GetCities().ToSelectListItemList());
            ViewBag.Cities = cities;

            List<SelectListItem> areaUnits = new List<SelectListItem> { new SelectListItem { Text = "- Unit -", Value = "0" } };
            areaUnits.AddRange(new PropertyAdvsHandler().GetAreaUnits().ToSelectListItemList());
            ViewBag.AreaUnits = areaUnits;

            List<SelectListItem> propertyTypes = new List<SelectListItem> { new SelectListItem { Text = "- Property Type -", Value = "0" } };
            propertyTypes.AddRange(new PropertyTypeHandler().GetPropertyTypes().ToSelectListItemList());
            ViewBag.PropertyTypes = propertyTypes;

            ViewBag.AdvTypes = new PropertyAdvsHandler().GetAdvTypes().ToSelectListItemList();
            ViewBag.PropFeatures = new PropertyAdvsHandler().GetFeatures().ToSelectListItemList();

            CreatePropertyAdvModel obj = new PropertyAdvsHandler().GetPropertyAdv(Id).ToModel();
            ViewBag.Schemes = new PropertyAdvsHandler().GetNeighborhoods().ToSelectListItemList();
            ViewBag.Blocks = new PropertyAdvsHandler().GetNeighborhoods(new Neighborhood { Id = obj.SchemeId }).ToSelectListItemList();

            return PartialView("~/views/Home/_Details.cshtml", obj);
        }

    }
}