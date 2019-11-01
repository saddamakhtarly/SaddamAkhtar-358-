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
using EVS358.Handler;
using EVS358.PropertyHub.WebUI.ModelsHelper;

using Microsoft.EntityFrameworkCore;

namespace EVS358.PropertyHub.WebUI.Controllers
{
    public class PropertyAdvsController : Controller
    {
        private IHostingEnvironment hostingEnv;

        public PropertyAdvsController(IHostingEnvironment env)
        {
            hostingEnv = env;
        }
        [HttpGet]
        public IActionResult Manage()
        {
            List<PropertyAdvSummaryModel> modelsList = new PropertyAdvsHandler().GetPropertyAdvs().ToSummaryModelList();
            return View(modelsList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> cities = new List<SelectListItem> { new SelectListItem { Text = "- City -", Value = "0" } };
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
            return PartialView("~/views/propertyadvs/_Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(CreatePropertyAdvModel model)
        {
            PropertyAdv entity = model.ToEntity();
            string temp = Request.Form["features"];
            if (!string.IsNullOrWhiteSpace(temp))
            {
                foreach (var fId in temp.Split(','))
                {
                    entity.Features.Add(new PropertyAdvsFeatures { Advertisement = entity, Feature = new PropertyFeature { Id = Convert.ToInt32(fId) } });
                }
            }

            int counter = 0;
            foreach (IFormFile file in Request.Form.Files)
            {
                if (file.Length > 0)
                {
                    string ext = file.FileName.Substring(file.FileName.LastIndexOf("."));
                    string fileName= $"{DateTime.Now.Ticks}_{++counter}{ext}";
                    string url = $"~/images/p_advs/{fileName}";
                    string path= hostingEnv.WebRootPath + $@"\images\p_advs\{fileName}";
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
                    {
                        file.CopyTo(fs);
                    }
                    entity.Images.Add(new PropertyImage { Priority = counter, ImageUrl = url,DateCreated = DateTime.Now });
                }
            }           
            new PropertyAdvsHandler().AddPropertyAdv(entity);            
            return RedirectToAction("manage");
        }


        [HttpGet]
        public IActionResult SchemesDDL(int id)
        {
            DDLModel m = new DDLModel();
            m.PropertyToBind = "SchemeId";
            m.GlyphIcon = "glyphicon-map-marker";
            m.Items = new PropertyAdvsHandler().GetNeighborhoods(new City { Id = id }).ToSelectListItemList();
            return PartialView("~/Views/Shared/_DDLView.cshtml", m);
        }

        [HttpGet]
        public IActionResult BlocksDDL(int id)
        {
            DDLModel m = new DDLModel();
            m.PropertyToBind = "BlockId";
            m.GlyphIcon = "glyphicon-map-marker";
            m.Items = new PropertyAdvsHandler().GetNeighborhoods(new Neighborhood { Id = id }).ToSelectListItemList();
            return PartialView("~/Views/Shared/_DDLView.cshtml", m);
        }


        [HttpGet]
        public IActionResult Update(int Id)
        {
            List<SelectListItem> cities = new List<SelectListItem> { new SelectListItem { Text = "- City -", Value = "0" } };
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
            ViewBag.Schemes = new PropertyAdvsHandler().GetNeighborhoods( ).ToSelectListItemList();
            ViewBag.Blocks= new PropertyAdvsHandler().GetNeighborhoods(new Neighborhood {Id=obj.SchemeId}).ToSelectListItemList();
        
            return PartialView("~/views/propertyadvs/_Update.cshtml",obj);
        }

        [HttpPost]
        public IActionResult Update(CreatePropertyAdvModel model)
        {
            PropertyHubContext db = new PropertyHubContext();
            PropertyAdv entity = model.ToEntity();
            string temp = Request.Form["features"];
            if (!string.IsNullOrWhiteSpace(temp))
            {
                foreach (var fId in temp.Split(','))
                {
                    entity.Features.Add(new PropertyAdvsFeatures { Advertisement = entity, Feature = new PropertyFeature { Id = Convert.ToInt32(fId) } });
                }
            }
            
            int counter = 0;
            foreach (IFormFile file in Request.Form.Files)
            {
                if (file.Length > 0)
                {
                    string ext = file.FileName.Substring(file.FileName.LastIndexOf("."));
                    string fileName = $"{DateTime.Now.Ticks}_{++counter}{ext}";
                    string url = $"~/images/p_advs/{fileName}";
                    string path = hostingEnv.WebRootPath + $@"\images\p_advs\{fileName}";
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
                    {
                        file.CopyTo(fs);
                    }

                    var find = db.PropertyImage.Where(x => x.Priority.Equals(counter)).FirstOrDefault();
                    if(find != null && !string.IsNullOrWhiteSpace(find.ImageUrl)) { find.ImageUrl = url; db.SaveChanges(); }
                    else
                    {
                        var findII = db.PropertyImage.OrderByDescending(x => x.Priority).FirstOrDefault();
                        int count = ++findII.Priority;
                        entity.Images.Add(new PropertyImage { ImageUrl = url, Priority = counter,DateCreated = DateTime.Now });
                    }
                    
                }
            }
            new PropertyAdvsHandler().UpdatePropertyAdv(entity,model.Id);
            return RedirectToAction("manage");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            CreatePropertyAdvModel obj = new PropertyAdvsHandler().GetPropertyAdv(id).ToModel();
            return PartialView("~/Views/propertyadvs/_Delete.cshtml", obj);
        }

        [HttpPost]
        public IActionResult Delete(CreatePropertyAdvModel model)
        {
            new PropertyAdvsHandler().DeletePropertyAdv(model.ToEntity(),model.Id);
            return RedirectToAction("Manage");
        }

    }
}