using ExampleProject.DAO;
using ExampleProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ExampleProject.Controllers
{
    public class Example : Controller
    {
        private readonly ExampleDbContext _context;
        public Example(ExampleDbContext context)
        {
            _context = context;
        }

        public IActionResult listAll()
        {
            return View("listAll", _context);
        }

        public IActionResult sampleDetails(int sampleID)
        {
            // List<SampleModel> sampleItems = _context.Samples.Include(sample => sample.itemList).ToList();
            // if(sampleItems.Count < 0)
            // {
            //     return Content("No Items");
            // }
            
            SampleModel foundSample = _context.Samples.Include(sample => sample.itemList).FirstOrDefault(sample => sample.id == sampleID);

            return View("sampleDetails", foundSample);
        }

        [HttpPost]
        public IActionResult addSample(SampleModel newSample)
        {
            _context.Add(newSample);
            _context.SaveChanges();

            return Content($"Added Sample {newSample.id}");
        }

        

        [HttpPost]
        public IActionResult addItemToSample(ItemModel newItem, int sampleID)
        {
            SampleModel foundSample = _context.Samples.Include(sample => sample.itemList).FirstOrDefault(sample => sample.id == sampleID);

            _context.Add(newItem);
            foundSample.itemList.Add(newItem);
            _context.SaveChanges();

            return Content($"Added Item {newItem.id} to Sample {foundSample.id}");
        }

    }
}