using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Inte_InpatientCare.Models;
using Inte_InpatientCare.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


namespace Inte_InpatientCare.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInPatRepository _inPatM;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IInPatRepository inPatManger,IWebHostEnvironment webHostEnvironment)
        {
            _inPatM = inPatManger;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InPatInfo(int id)
        {
            return View(_inPatM.GetInPatient(id));
        }

        public IActionResult InPatDetails()
        {
            return View();
        }
        public IActionResult InPatList()
        {
            return View(new HomeInPatListViewModel
            {
                InPatData = _inPatM.GetAllInPatient(),
                PageTitle = "列表页"
            });
        }

        [HttpGet]
        public IActionResult CreatInPat()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatInPat(InPatCreatViewModel inPatModel)
        {
            if (ModelState.IsValid)
            {
                //var inP = _inPatM.AddInPat(inPatient);
                //return RedirectToAction("InPatInfo", new { id = inP.ID });

                string UpFilesNames = null;
                if (inPatModel.Photo!=null)
                {
                    string strFiles = Path.Combine(_webHostEnvironment.WebRootPath,"images");
                    UpFilesNames = Guid.NewGuid().ToString() + "_" + inPatModel.Photo.FileName;
                    string QueFilePath = Path.Combine(strFiles, "\\"+UpFilesNames);
                    inPatModel.Photo.CopyTo(new FileStream(QueFilePath, FileMode.Create));
                }
                var inP = _inPatM.AddInPat(new InPatient { 
                ID= inPatModel.ID,
                Name=inPatModel.Name,
                Sex=inPatModel.Sex,
                InPatCard=inPatModel.InPatCard,
                Chaperone=inPatModel.Chaperone
                });
                return RedirectToAction("InPatInfo", new { id = inP.ID });
            }
            return View();
        }
    }
}
