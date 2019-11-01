using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EVS358.PropertyHub.WebUI.Models;
using EVS358.PropertyHub.WebUI.ModelsHelper;
using EVS358.Handler;

namespace EVS358.PropertyHub.WebUI.Controllers
{
    public class CountryController : Controller
    {
        [HttpGet]
        public IActionResult Manage()
        {
            List<CountryModel> countrylist = new List<CountryModel>();
            countrylist = new CountryHandler().GetCountries().ToCountryList();
            return View(countrylist);
        }


        [HttpGet]
        public IActionResult Create()
        {

            return PartialView("~/Views/Country/_Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(CountryModel model)
        {
            try
            {
                new CountryHandler().AddCountry(model.ToCountryEntity());
                TempData.Set<AlertModel>("Alert", new AlertModel($"{model.Name} is added successfully", AlertModel.AlertType.Success));
            }
            catch (Exception)
            {
                TempData.Set<AlertModel>("Alert", new AlertModel($"failed to add {model.Name}", AlertModel.AlertType.Error));
                
            }
      
            return RedirectToAction("Manage");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            CountryModel model = new CountryHandler().GetCountryById(id).ToCountryModel();
            return PartialView("~/Views/Country/_Update.cshtml", model);
        }

        [HttpPost]
        public IActionResult Update(CountryModel model)
        {
            try
            {
                new CountryHandler().UpdateCountry(model.ToCountryEntity(), 0);
                TempData.Set<AlertModel>("Alert", new AlertModel($"{model.Name} is Updated successfully", AlertModel.AlertType.Success));
            }
            catch (Exception)
            {

                TempData.Set<AlertModel>("Alert", new AlertModel($"failed to Update {model.Name}", AlertModel.AlertType.Error));
            }
        
            return RedirectToAction("Manage");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            CountryModel model = new CountryHandler().GetCountryById(id).ToCountryModel();
            return PartialView("~/Views/Country/_Delete.cshtml", model);
        }

        [HttpPost]
        public IActionResult Delete(CountryModel model)
        {
            try
            {
                new CountryHandler().DeleteCountry(model.ToCountryEntity(), 0);
                TempData.Set<AlertModel>("Alert", new AlertModel($"{model.Name} is deleted successfully", AlertModel.AlertType.Success));
            }
            catch (Exception)
            {

                TempData.Set<AlertModel>("Alert", new AlertModel($"failed to delete {model.Name}", AlertModel.AlertType.Error));
            }
          
            return RedirectToAction("Manage");
        }

    }
}