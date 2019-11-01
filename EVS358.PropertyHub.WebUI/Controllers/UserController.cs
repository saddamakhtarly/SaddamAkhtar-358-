using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EVS358.PropertyHub.WebUI.Models;
using EVS358.UsersMgt;
using EVS358.Handler;
using EVS358.PropertyHub.WebUI.ModelsHelper;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace EVS358.PropertyHub.WebUI.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Manage()
        {
            List<UserModel> users = new UserHandler().GetUsers().ToUserList();
            return View(users);
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> UserCountryList = new List<SelectListItem> { new SelectListItem { Text = "- Country -", Value = "0" } };
            UserCountryList.AddRange(new CountryHandler().GetCountries().ToSelectListItemList());
            ViewBag.Country = UserCountryList;

            List<SelectListItem> UserProvinceList = new List<SelectListItem> { new SelectListItem { Text = "- Province -", Value = "0" } };
            UserProvinceList.AddRange( new ProvinceHandler().GetProvinces().ToSelectListItemList());
            ViewBag.Province = UserProvinceList;
            List<SelectListItem> UserCityList = new List<SelectListItem> { new SelectListItem { Text = "- City -", Value = "0" } };
            UserCityList.AddRange( new CityHandler().GetCitys().ToSelectListItemList() );
            ViewBag.City = UserCityList;

            List<SelectListItem> UserRoleList = new List<SelectListItem> { new SelectListItem { Text = "- Role -", Value = "0" } };
            UserRoleList.AddRange(new UserHandler().GetRole().ToSelectListItemList());
            ViewBag.Role = UserRoleList;



            return PartialView("~/Views/User/_Create.cshtml");
        }
        [HttpPost]
        public IActionResult Create(UserModel model)
        {
            try
            {               
                new UserHandler().AddUser(model.ToUserEntity());
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
            List<SelectListItem> UserCountryList = new List<SelectListItem> { new SelectListItem { Text = "- Country -", Value = "0" } };
            UserCountryList.AddRange(new CountryHandler().GetCountries().ToSelectListItemList());
            ViewBag.Country = UserCountryList;

            List<SelectListItem> UserProvinceList = new List<SelectListItem> { new SelectListItem { Text = "- Province -", Value = "0" } };
            UserProvinceList.AddRange(new ProvinceHandler().GetProvinces().ToSelectListItemList());
            ViewBag.Province = UserProvinceList;
            List<SelectListItem> UserCityList = new List<SelectListItem> { new SelectListItem { Text = "- City -", Value = "0" } };
            UserCityList.AddRange(new CityHandler().GetCitys().ToSelectListItemList());
            ViewBag.City = UserCityList;

            List<SelectListItem> UserRoleList = new List<SelectListItem> { new SelectListItem { Text = "- Role -", Value = "0" } };
            UserRoleList.AddRange(new UserHandler().GetRole().ToSelectListItemList());
            ViewBag.Role = UserRoleList;
            UserModel model = new UserHandler().GetUser(id).ToUserModel();
            return PartialView("~/Views/User/_Update.cshtml", model);
        }
        [HttpPost]
        public IActionResult Update(UserModel model)
        {
            try
            {               
                new UserHandler().UpdateUser(model.ToUserEntity(), model.Id);
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
            UserModel model = new UserHandler().GetUser(id).ToUserModel();
            return PartialView("~/Views/User/_Delete.cshtml", model);
        }
        [HttpPost]
        public IActionResult Delete(User model)
        {
            UserModel entity = null;
            try
            {
                new UserHandler().DeleteUser(model);
                TempData.Set<AlertModel>("Alert", new AlertModel($"{model.Name} is deleted successfully", AlertModel.AlertType.Success));
            }
            catch (Exception ex)
            {
                TempData.Set<AlertModel>("Alert", new AlertModel($"failed to delete {model.Name}", AlertModel.AlertType.Error));
            }
            return RedirectToAction("manage");
        }
        public IActionResult CreateUser()
        {
            return View();
        }





















    }
}