using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExampleProject.Models
{
    // This is the primary model referenced in the application - A Sample has many items and one bucket 
    public class SampleModel 
    {
        [Key]
        public int id{get;set;}
        public int sampleInteger {get;set;}
        public string sampleString {get;set;}
        // example of an enumerated type used in a dropdown 
        public sampleType sampleEnumType {get;set;}
        // a Sample can have 0 to many items
        public List<ItemModel> itemList {get;set;}

        /*
        a sample will have one bucket 

        a bucket id is provided so that a look up can be done to associate a bucket to a sample

        a select item list is included to populate the razor html helper dropdown selection, this list will be populated in the controller
        */ 
        public int sampleBucketID{get;set;}
        [NotMapped] // the `NotMapped` annotation is added to resolve a key reference error and imported from `System.ComponentModel.DataAnnotations.Schema;`
        public List<SelectListItem> buckets {get;set;}
        // public enum is scope to populate the simple dropdown
        public enum sampleType
        {
            typeOne, typeTwo, typeThree
        }
        // empty constructor to create a Sample object and populate the `buckets` select item list
        public SampleModel()
        {
        }
    }
    
}
