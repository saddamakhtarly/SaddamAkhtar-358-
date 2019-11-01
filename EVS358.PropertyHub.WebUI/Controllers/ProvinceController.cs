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
    public class ProvinceController : Controller
    {
        [HttpGet]
        public IActionResult Manage()
        {
            List<ProvinceModel> schemes = new ProvinceHandler().GetProvinces().ToProvinceList();
            return View(schemes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> CountryList = new List<SelectListItem> { new SelectListItem { Text = "- Country -", Value = "0" } };
            CountryList.AddRange(new CountryHandler().GetCountries().ToSelectListItemList());
            ViewBag.Countries = CountryList;
            return PartialView("~/Views/Province/_Create.cshtml");
        }

     
        [HttpPost]
        public IActionResult Create(ProvinceModel model)
        {
            try
            {
                new ProvinceHandler().AddProvince(model.ToProvinceEntity());
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
            List<SelectListItem> items = new List<SelectListItem> { new SelectListItem { Text = "- Country -", Value = "0" } };
            items.AddRange(new CountryHandler().GetCountries().ToSelectListItemList());
            ViewBag.Countries = items;

            ProvinceModel model = new ProvinceHandler().GetProvinceById(id).ToProvinceModel();
            return PartialView("~/Views/Province/_Update.cshtml", model);
        }

        [HttpPost]
        public IActionResult Update(ProvinceModel model)
        {
            try
            {
                new ProvinceHandler().UpdateProvince(model.ToProvinceEntity(), model.Id);
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
            ProvinceModel model = new ProvinceHandler().GetProvinceById(id).ToProvinceModel();
            return PartialView("~/Views/Province/_Delete.cshtml", model);
        }

        [HttpPost]
        public IActionResult Delete(Province model)
        {
            ProvinceModel entity = null;
            try
            {
                 new ProvinceHandler().DeleteProvince(model);
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