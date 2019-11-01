using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS358;

using EVS358.PropertyHub.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EVS358.Handler;

using Newtonsoft.Json;

namespace EVS358.PropertyHub.WebUI.Controllers
{
    public class SchemesController : Controller
    {
        [HttpGet]
        public IActionResult Manage()
        {
            //List<Neighborhood> data = new PropertyAdvsHandler().GetNeighborhoods();
            //List<SchemeModel> schemes = ModelsHelper.ToSchemeModelList(data);
            List<SchemeModel> schemes = new PropertyAdvsHandler().GetNeighborhoods().ToSchemeModelList();
            return View(schemes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem> { new SelectListItem { Text = "- City -", Value = "0" } };
            items.AddRange(new LocationsHandler().GetCities().ToSelectListItemList());
            ViewBag.Cities = items;
            return PartialView("~/Views/Schemes/_Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(SchemeModel model)
        {
            try
            {
                new PropertyAdvsHandler().AddNeighborhood(model.ToEntity());
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
            List<SelectListItem> items = new List<SelectListItem> { new SelectListItem { Text = "- City -", Value = "1" } };
            items.AddRange(new LocationsHandler().GetCities().ToSelectListItemList());
            ViewBag.Cities = items;

            SchemeModel model = new PropertyAdvsHandler().GetNeighborhood(id).ToSchemeModel();
            return PartialView("~/Views/Schemes/_Update.cshtml", model);
        }

        [HttpPost]
        public IActionResult Update(SchemeModel model)
        {
            try
            {
                new PropertyAdvsHandler().UpdateNeighborhood(model.Id, model.ToEntity());
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
            SchemeModel model = new PropertyAdvsHandler().GetNeighborhood(id).ToSchemeModel();
            return PartialView("~/Views/Schemes/_Delete.cshtml", model);
        }

        [HttpPost]
        public IActionResult Delete(SchemeModel model)
        {
            Neighborhood entity = null;
            try
            {
                entity = new PropertyAdvsHandler().DeleteNeighborhood(model.Id);
                TempData.Set<AlertModel>("Alert", new AlertModel($"{entity.Name} is deleted successfully", AlertModel.AlertType.Success));
            }
            catch (Exception ex)
            {
                TempData.Set<AlertModel>("Alert", new AlertModel($"failed to delete {entity.Name}", AlertModel.AlertType.Error));
            }
            return RedirectToAction("manage");
        }


       
    }
}