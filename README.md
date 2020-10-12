# Using and Populating Drop-down Menus with Razor Template HTML Helpers in a .NET MVC Application

### Model Structure 
```
Sample Model
|___ Many Items : List of Items
|
|___ One Bucket : Bucket ID
```
Item Model : ONLY IN RELATION TO SAMPLE (includes sample model ID)
Bucket Model : Separate model but optionally linked via bucket id in sample model

### Functionally
- Display drop-down functionality, simple(enum) and complex(object) examples 
- Create Sample Object with Bucket Object
- View All Sample Objects
- View Sample Object details
- Add Item Objects to Sample Object
- Create Bucket Object
- View All Bucket Objects

### Drop-downs
Drop downs are included in Sample create form
- Enum drop-down to select sample type
- Bucket drop-down to select bucket by description

### Resources

- [Pluralsight Tutorial](https://www.pluralsight.com/guides/asp-net-mvc-populating-dropdown-lists-in-razor-views-using-the-mvvm-design-pattern-entity-framework-and-ajax)
- [Stack Overflow Answer](https://stackoverflow.com/questions/18382311/populating-a-razor-dropdownlist-from-a-listobject-in-mvc)



