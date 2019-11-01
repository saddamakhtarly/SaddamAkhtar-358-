using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS358.PropertyHub.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EVS358.Handler;

namespace EVS358.PropertyHub.WebUI.Controllers
{
    public class PropertyTypesController : Controller
    {
        [HttpGet]
        public IActionResult Manage()
        {

            List<PropertyTypesModel> propertytypelist = new PropertyTypeHandler().GetPropertyTypes().ToPropertyTypesList();

            return View(propertytypelist);
        }

        [HttpGet]
        public IActionResult Create()
        {
          
            return PartialView("~/Views/Propertytypes/_Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(PropertyTypesModel model)
        {
            new PropertyTypeHandler().AddPropertyTypr(model.ToPropertyTypeEntity());
            return  RedirectToAction("Manage");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            PropertyTypesModel model = new PropertyTypeHandler().GetPropertyType(id).ToPropertyTypesModel();
            return PartialView("~/Views/Propertytypes/_Update.cshtml",model);
        }

        [HttpPost]
        public IActionResult Update(PropertyTypesModel model)
        {
            new PropertyTypeHandler().UpdatePropertyTypr(model.ToPropertyTypeEntity());
            return RedirectToAction("Manage");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            PropertyTypesModel model = new PropertyTypeHandler().GetPropertyType(id).ToPropertyTypesModel();
            return PartialView("~/Views/Propertytypes/_Delete.cshtml", model);
        }

        [HttpPost]
        public IActionResult Delete(PropertyTypesModel model)
        {
            new PropertyTypeHandler().DeletePropertyTypr(model.ToPropertyTypeEntity());
            return RedirectToAction("Manage");
        }

    }
}