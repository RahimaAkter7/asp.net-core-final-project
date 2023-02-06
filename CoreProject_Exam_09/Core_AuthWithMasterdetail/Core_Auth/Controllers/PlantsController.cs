using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core_Auth.Data;
using Core_Auth.Models;
using Microsoft.AspNetCore.Hosting;
using Core_Auth.Models.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Core_Auth.Controllers
{

    
    //[Authorize(Roles ="Admin,Stuff")]
    public class PlantsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _he;

        public PlantsController(ApplicationDbContext context, IWebHostEnvironment  he)
        {
            _context = context;
            _he = he;
        }

        
        public  IActionResult Index()
        {
            return View(_context.Plants.Include(x => x.StockEntries).ThenInclude(b => b.pot).ToList());

            //var applicationDbContext = _context.Plants.Include(p => p.PlantSize);
            //return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult AddNewPot(int? id)
        {
            ViewBag.pots = new SelectList(_context.pots.ToList(), "potId", "potName", id.ToString() ?? "");
            return PartialView("_AddNewpot");
        }

        //[Authorize(Policy = "Plantshop")]
        public IActionResult Create()
        {
            ViewData["SizeId"] = new SelectList(_context.plantSizes.ToList(), "SizeId", "SizeType");
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Policy = "Plantshop")]
        public async Task<IActionResult> Create(PlantVM  plantVM, int[] potId)
        {
            if (ModelState.IsValid)
            {
                Plant plant = new Plant()
                {
                    PlantName = plantVM.PlantName,
                    StockDate=plantVM.StockDate,
                    Quantity = plantVM.Quantity,
                    SizeId=plantVM.SizeId,
                    IsAvaible = plantVM.IsAvaible,
                    
                };
                //Img
                string webroot = _he.WebRootPath;
                string folder = "Images";
                string imgFileName = Path.GetFileName(plantVM.PictureFile.FileName);
                string fileToWrite = Path.Combine(webroot, folder, imgFileName);

                using (var stream = new FileStream(fileToWrite, FileMode.Create))
                {
                    await plantVM.PictureFile.CopyToAsync(stream);
                    plant.Picture = "/" + folder + "/" + imgFileName;
                }
                foreach (var item in potId)
                {
                    StockEntry stockEntry = new StockEntry()
                    {
                        Plant = plant,
                        PlantId = plant.PlantId,
                        potId = item
                    };
                    _context.stockEntries.Add(stockEntry);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();

        }

    
        public  IActionResult Edit(int? id)
        {
            Plant plant = _context.Plants.First(x => x.PlantId == id);
            var potList = _context.stockEntries.Where(x => x.PlantId == id).Select(x => x.potId).ToList();

            ViewData["SizeId"] = new SelectList(_context.plantSizes.ToList(), "SizeId", "SizeType");

            PlantVM plantVM = new PlantVM
            {
                PlantId = plant.PlantId,
                PlantName = plant.PlantName,
                StockDate = plant.StockDate,
                Quantity = plant.Quantity,
                Picture=plant.Picture,
                SizeId= plant.SizeId,
                IsAvaible = plant.IsAvaible,
                potList = potList
            };
            return View(plantVM);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PlantVM plantVM, int[] potId)
        {

            if (ModelState.IsValid)
            {
                Plant plant = new Plant()
                {
                    PlantId=plantVM.PlantId,
                    PlantName = plantVM.PlantName,
                    StockDate = plantVM.StockDate,
                    Quantity = plantVM.Quantity,
                    SizeId = plantVM.SizeId,
                    IsAvaible = plantVM.IsAvaible,
                    Picture=plantVM.Picture

                };
                //Img
                if (plantVM.PictureFile !=null)
                {
                    string webroot = _he.WebRootPath;
                    string folder = "Images";
                    string imgFileName = Path.GetFileName(plantVM.PictureFile.FileName);
                    string fileToWrite = Path.Combine(webroot, folder, imgFileName);

                    using (var stream = new FileStream(fileToWrite, FileMode.Create))
                    {
                        await plantVM.PictureFile.CopyToAsync(stream);
                        plant.Picture = "/" + folder + "/" + imgFileName;
                    }
                }

                //exists spotList
                var existspot = _context.stockEntries.Where(x => x.PlantId == plantVM.PlantId).ToList();
                foreach (var item in existspot)
                {
                    _context.stockEntries.Remove(item);
                }
                foreach (var item in potId)
                {
                    StockEntry stockEntry = new StockEntry()
                    {
                       
                        PlantId = plant.PlantId,
                        potId = item
                    };
                    _context.stockEntries.Add(stockEntry);
                }
                _context.Entry(plant).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();

        }

    
        public async Task<IActionResult> Delete(int? id)
        {


            Plant plant = _context.Plants.First(x => x.PlantId == id);
            var spotList = _context.stockEntries.Where(x => x.PlantId == id).ToList();

            foreach (var item in spotList)
            {
                _context.stockEntries.Remove(item);
            }
            _context.Entry(plant).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        
    }
}
