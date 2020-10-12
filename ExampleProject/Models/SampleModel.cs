using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExampleProject.Models
{
    public class SampleModel 
    {
        [Key]
        public int id{get;set;}
        public int sampleInteger {get;set;}
        public string sampleString {get;set;}
        public sampleType sampleEnumType {get;set;}

        public List<ItemModel> itemList {get;set;}
        public int sampleBucketID{get;set;}
        [NotMapped]
        public List<SelectListItem> buckets {get;set;}
        public enum sampleType
        {
            typeOne, typeTwo, typeThree
        }
        public SampleModel()
        {
        }
    }
    
}
