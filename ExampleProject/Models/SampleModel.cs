using System.Collections.Generic;

namespace ExampleProject.Models
{
    public class SampleModel 
    {
        public int id{get;set;}
        public int sampleInteger {get;set;}
        public string sampleString {get;set;}
        public sampleType sampleEnumType {get;set;}

        public List<ItemModel> itemList {get;set;}
        public enum sampleType
        {
            typeOne, typeTwo, typeThree
        }
    }
    
}
