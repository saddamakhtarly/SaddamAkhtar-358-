using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVS358.Handler;
using EVS358.PropertyHub.WebUI.Models;
using EVS358.PropertyHub.WebUI;
using EVS358.UsersMgt;


namespace EVS358.PropertyHub.WebUI.ModelsHelper
{
    public static class PropertyAdvsHelper
    {

        public static PropertyAdvSummaryModel ToSummaryModel(this PropertyAdv entity)
        {
            PropertyAdvSummaryModel model = new PropertyAdvSummaryModel();
            model.Id = entity.Id;
            model.Name = entity.Name;
            model.Price = entity.Price;
            model.Type = entity.PropertyType.Name;
            //model.Area = $"{entity.Area.Value} {entity.Area.Unit.Name}";
            model.AdvAge = $"{DateTime.Today.Subtract(entity.StartOn).Days} Days";
            if (entity.Images?.Count > 0)
            {
                model.MainImageUrl = model.AlternateImageUrl = entity.Images.ToList()[0].ImageUrl;
                if (entity.Images.Count > 1)
                {
                    model.AlternateImageUrl = entity.Images.ToList()[1].ImageUrl;
                }
            }
            else
            {
                model.MainImageUrl = model.AlternateImageUrl = "~/images/p_advs/none.png";
            }
            model.Location = $"{entity.Neighborhood.Name} {entity.Neighborhood.City.Name}";
            return model;
        }

        public static List<PropertyAdvSummaryModel> ToSummaryModelList(this List<PropertyAdv> entitiesList)
        {
            List<PropertyAdvSummaryModel> modelsList = new List<PropertyAdvSummaryModel>();
            foreach (var entity in entitiesList)
            {
                modelsList.Add(entity.ToSummaryModel());
            }
            modelsList.TrimExcess();
            return modelsList;
        }

        public static PropertyAdv ToEntity(this CreatePropertyAdvModel model)
        {
            PropertyAdv entity = new PropertyAdv();
            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Price = model.Price;
            
            entity.Beds = model.Beds;
            entity.Baths = model.Baths;
            entity.Neighborhood = new Neighborhood { Id = model.BlockId };
            entity.AdvStatus = new AdvStatus { Id = 1 }; // by default adv is in pending status
            entity.AdvType = new AdvType { Id = model.AdvType };
            entity.Area = new PropertyArea { Value = model.Area, Unit = new AreaUnit { Id = model.AreaUnitId } };
            //entity.Images
            entity.IsActive = true; // by default adv is active
            entity.PostedBy = new User { Id = 3 }; // currently login user will be assigned here
            entity.PostedOn = DateTime.Today;
            entity.PropertyType = new PropertyType { Id = model.AdvType };
            entity.StartOn = model.StartDate;

            return entity;
        }



        public static CreatePropertyAdvModel ToModel(this PropertyAdv Entity)
        {
            CreatePropertyAdvModel Model = new CreatePropertyAdvModel();
            Model.Id = Entity.Id;
            Model.Name = Entity.Name;
            Model.Price = Entity.Price;
            Model.CityId = Entity.Neighborhood.City.Id;
            Model.AreaUnitId = Entity.Area.Unit.Id;
            Model.AdvType = Entity.AdvType.Id;
            Model.PropertyTypeId = Entity.PropertyType.Id;
            Model.BlockId = Entity.Neighborhood.Id ;
            Model.SchemeId = Entity.Neighborhood.Parent.Id;
            Model.StartDate = Entity.StartOn;
            Model.Area = Entity.Area.Value;
            Model.Beds = Entity.Beds;
            Model.Baths = Entity.Baths;
            //entity.
            //Model.BlockId = new Neighborhood { Id = Entity.Neighborhood.Id };
            //Model.AdvStatus = new AdvStatus { Id = 1 }; // by default adv is in pending status
            //Model.AdvType = new AdvType { Id = Entity.AdvType };
            //Model.Area = new PropertyArea { Value = Entity.Area, Unit = new AreaUnit { Id = Entity.AreaUnitId } };
            //entity.Images

            if (Entity.Images?.Count > 0)
            {
                Model.MainImageUrl = Model.AlternateImageUrl = Entity.Images.ToList()[0].ImageUrl;
                if (Entity.Images.Count > 1)
                {
                    Model.AlternateImageUrl = Entity.Images.ToList()[1].ImageUrl;
                  
                }
            }
            else
            {
                Model.MainImageUrl = Model.AlternateImageUrl = "~/images/p_advs/none.png";
            }
            return Model;
        }
    }
}
