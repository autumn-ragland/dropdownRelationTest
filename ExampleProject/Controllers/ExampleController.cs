using ExampleProject.DAO;
using ExampleProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ExampleProject.Controllers
{
    public class Example : Controller
    {
        // ref to DB
        private readonly ExampleDbContext _context;
        public Example(ExampleDbContext context)
        {
            _context = context;
        }
        // list all samples
        public IActionResult listAll()
        {
            return View("listAll", _context);
        }
        // view details of one sample
        public IActionResult sampleDetails(int sampleID)
        {
            // find sample by query param
            SampleModel foundSample = _context.Samples.Include(sample => sample.itemList).FirstOrDefault(sample => sample.id == sampleID);
            // pass matching sample to view
            return View("sampleDetails", foundSample);
        }
        // add sample to db
        [HttpPost]
        public IActionResult addSample(SampleModel newSample)
        {
            // sanity check
            // if(newSample.sampleBucketID > 0)
            // {
            //     _context.Add(newSample);
            //     _context.SaveChanges();
            //     return Content($"Added Sample {newSample.id} with Bucket {newSample.sampleBucketID}");
            // } else 
            // {
            //     return Content($"bucket dropdown error");
            // }
            _context.Add(newSample);
            _context.SaveChanges();
            return RedirectToAction("listAll");
        }
        // display form to add sample to view
        public IActionResult displaySampleForm()
        {
            // new object to pass to view
            SampleModel newSample = new SampleModel();
            // project each object in the bucket DB set to a select list item
            List<SelectListItem> bucketOptions = _context.Buckets.Select( b => new SelectListItem {Value = b.id.ToString(), Text = b.desc}).ToList();
            // update empty value of new object's select list property to newly created list of select list items
            newSample.buckets = new SelectList(bucketOptions, "Value", "Text").ToList();

            // assign default/first value to select list
            SelectListItem defaultBucket = new SelectListItem()
            {
                Value = null,
                Text = "---Select a Bucket---"
            };
            newSample.buckets.Insert(0, defaultBucket);

            return View(newSample);
        }
        // add item to sample
        [HttpPost]
        public IActionResult addItemToSample(ItemModel newItem)
        {
            // find sample based on item property
            SampleModel foundSample = _context.Samples.Include(sample => sample.itemList).FirstOrDefault(sample => sample.id == newItem.SampleModelid);

            // sanity check
            // if(foundSample != null)
            // {
            //     return Content($"Found Sample ID = {foundSample.id} New Item ID = {newItem.id}");
            // } else 
            // {
            //     return Content($"No sample found with ID {newItem.SampleModelid}");
            // }

            // add item to db and relate to sample
            _context.Add(newItem);
            foundSample.itemList.Add(newItem);
            _context.SaveChanges();

            // return Content($"Added Item {newItem.id} to Sample {foundSample.id}"); // sanity check
            return RedirectToAction("sampleDetails", new { sampleID = foundSample.id });
        }
        // display form to add item to sample
        public IActionResult displayItemForm(int sampleID)
        {
            ItemModel newItem = new ItemModel(); // create a new ItemModel object
            newItem.SampleModelid = sampleID; // set property to asp-route-param
            return View(newItem); // pass object to view to populate relational field
        }
        // add bucket to db
        [HttpPost]
        public IActionResult addBucket(BucketModel newBucket)
        {
            _context.Add(newBucket);
            _context.SaveChanges();

            // return Content($"Added Bucket {newBucket.id}"); // sanity check
            return RedirectToAction("listAllBuckets");
        }
        // display form to add item to sample
        public IActionResult displayBucketForm()
        {
            return View(); 
        }
        // display all buckets
        public IActionResult listAllBuckets()
        {
            return View(_context);
        }
        // display bucket details
        public IActionResult bucketDetails(int bucketID)
        {
            BucketModel foundBucket = _context.Buckets.FirstOrDefault(b => b.id == bucketID);
            return View(foundBucket);
        }
    }
}