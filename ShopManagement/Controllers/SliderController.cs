using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopManagement.Controllers
{
    public class SliderController : Controller
    {
        // GET: Slider
        public ActionResult SliderSettings()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");
            Utilities.Slider sliderUtility = new Utilities.Slider();
            var Images = sliderUtility.GetAllImages();
            Models.ImageAdditionalInfo imageAdditionalInfo = new Models.ImageAdditionalInfo();
            imageAdditionalInfo.HighQualityImage = Images.Where(x => x.Type.ToLower() == "high").ToList();
            imageAdditionalInfo.LowQualityImage = Images.Where(x => x.Type.ToLower() == "low").ToList();
            imageAdditionalInfo.MediumQualityImage = Images.Where(x => x.Type.ToLower() == "medium").ToList();
            return View(imageAdditionalInfo);
        }

        public ActionResult AddImage()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");
            return View();
        }

        public ActionResult Gallery()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");
            string QueryStringValue = Request.QueryString["action"];
            ViewBag.Message = QueryStringValue;
            Utilities.Slider sliderUtility = new Utilities.Slider();
            var Images = sliderUtility.GetAllImages();
            Models.ImageAdditionalInfo imageAdditionalInfo = new Models.ImageAdditionalInfo();
            imageAdditionalInfo.HighQualityImage = Images.Where(x => x.Type.ToLower() == "high").ToList();
            imageAdditionalInfo.LowQualityImage = Images.Where(x => x.Type.ToLower() == "low").ToList();
            imageAdditionalInfo.MediumQualityImage = Images.Where(x => x.Type.ToLower() == "medium").ToList();
            return View(imageAdditionalInfo);
        }
    }
}