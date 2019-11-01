using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EVS358.PropertyHub.WebUI.Models;
using EVS358.Handler;
using EVS358.PropertyHub.WebUI.ModelsHelper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EVS358.PropertyHub.WebUI.Controllers
{
    public class CitiesController : Controller
    {
        [HttpGet]
        public IActionResult Manage()
        {
            List<CityModel> schemes = new CityHandler().GetCitys().ToCityList();
            return View(schemes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> ProvinceList = new List<SelectListItem> { new SelectListItem { Text = "- Province -", Value = "0" } };
            ProvinceList.AddRange(new ProvinceHandler().GetProvinces().ToSelectListItemList());
            ViewBag.Province = ProvinceList;
            return PartialView("~/Views/Cities/_Create.cshtml");
        }


        [HttpPost]
        public IActionResult Create(CityModel model)
        {
            try
            {
                new CityHandler().AddCity(model.ToCityEntity());
                TempData.Set<AlertModel>("Alert", new AlertModel($"{model.Name} is added successfully", AlertModel.AlertType.Success));
            }
            catch (Exception ex)
            {
                TempData.Set<AlertModel>("Alert", new AlertModel($"failed to add {model.Name}", AlertModel.AlertType.Error));
            }
            return RedirectToAction("manage");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            List<SelectListItem> items = new List<SelectListItem> { new SelectListItem { Text = "- City -", Value = "0" } };
            items.AddRange(new ProvinceHandler().GetProvinces().ToSelectListItemList());
            ViewBag.Province = items;

            CityModel model = new CityHandler().GetCityById(id).ToCityModel();
            return PartialView("~/Views/Cities/_Update.cshtml", model);
        }

        [HttpPost]
        public IActionResult Update(CityModel model)
        {
            try
            {
                new CityHandler().UpdateCity(model.ToCityEntity(), model.Id);
                TempData.Set<AlertModel>("Alert", new AlertModel($"{model.Name} is updated successfully", AlertModel.AlertType.Success));
            }
            catch (Exception ex)
            {
                TempData.Set<AlertModel>("Alert", new AlertModel($"failed to update {model.Name}", AlertModel.AlertType.Error));
            }
            return RedirectToAction("manage");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            CityModel model = new CityHandler().GetCityById(id).ToCityModel();
            return PartialView("~/Views/Cities/_Delete.cshtml", model);
        }

        [HttpPost]
        public IActionResult Delete(City model)
        {
            CityModel entity = null;
            try
            {
                new CityHandler().DeleteCity(model);
                TempData.Set<AlertModel>("Alert", new AlertModel($"{model.Name} is deleted successfully", AlertModel.AlertType.Success));
            }
            catch (Exception ex)
            {
                TempData.Set<AlertModel>("Alert", new AlertModel($"failed to delete {model.Name}", AlertModel.AlertType.Error));
            }
            return RedirectToAction("manage");
        }




    }
}