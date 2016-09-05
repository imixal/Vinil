using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Model;

namespace Vinil.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.vinils = VinilService.PagenatorNext(6,1);
            ViewBag.count = 6;
            ViewBag.page = 1;
            ViewBag.style = VinilService.GetAllStyle();
            ViewBag.artist = VinilService.GetAllArtist();
            ViewBag.album = VinilService.GetAllAlbum();
            ViewBag.max = VinilService.GetVinilsMaxPrise();
            ViewBag.min = VinilService.GetVinilsMinPrise();
            return View();
        }
        [HttpGet]
        public  ActionResult UpdatebySettings(int priseMin, int priseMax, string style, string artist, string album,string sort,int count, int page)
        {
            ViewBag.vinils = VinilService.GetVinilsBySettings(priseMin, priseMax, style.Split(','), artist.Split(','),album.Split(','),sort,count, page);
            ViewBag.count = count;
            ViewBag.page = page;
            return PartialView("_VinilsView");
            
        }
        [HttpGet]
        public ActionResult UpdatePagenator()
        {
            return PartialView("_ControlBar");
        }
        public ActionResult Add()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult Add(Model.Vinil vinil)
        {
            VinilService.Add(vinil);
            ViewBag.vinil = vinil;
            return View("Result");
        }

    }
}