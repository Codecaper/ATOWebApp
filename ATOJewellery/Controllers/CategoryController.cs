using ATOJewellery.Data;
using ATOJewellery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ATOJewellery.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)// Whatever is registered inside the container we can receive | Thats what is in service on our program.cs | pass by reference
       //This reference will have all the db dtrings  and implementation of the data | We can populate our local db Object with this implematation 
        {
            _db = db; // And this variable may be used to retreive our categories  | from here we can move on to the view area
        }
        public IActionResult Index()
        {  //intead of usring var we can use the strongly type of: category : see second line below | Because ew are using IEnumerable we can remove .ToList() Because we are passing IEnumerable to our view now
            //var objCategoryList = _db.Categories.ToList(); //This line makes the list possible for use in the viewe | we need to passitby reference | deprecated line 
            IEnumerable<Category> objCategoryList = _db.Categories;  // More solid line of use 
            return View(objCategoryList);
            //Now that this is done we weed to set up everything in "view category Index" file
        }

        //Get
        public IActionResult Create()
        {  
            return View();
        }

        //Post
        [HttpPost]  //Most be used for Posting 
        [ValidateAntiForgeryToken]// Prevents cross site request forgery attack | It basicly injects a key, and it most be validated 
        public IActionResult Create(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString()) {
                ModelState.AddModelError("name","THe DisplayOrder cannot exactly match the Name."); //We can change "CustomError property to say name and this will move the error msg to wherer the name property is "
                // This line works injunction with view | the function-helper there is "asp-validation-summary="All"" When there is an errror this custom msg will pop-up
            }
            if (ModelState.IsValid)
                {//Exception - When the create button is hit it throws an exception error. bacause when we created the Catogry 
                 // model it had requirements | Thus this arguement checks the requiremnts are met (ModelState) | This also condered a server-side validation
                    _db.Categories.Add(obj); // THis gather wjats we are trying to send
                    _db.SaveChanges();// This command will push it to db and save the changes
                TempData["success"] = "Category created successfully";//TempDate stores values temerally | success is a key to access the msg | the msg is like a one time use where it will be deleted after reload
                    return RedirectToAction("Index"); // Instead of "view" we redirct to see what was posted back on the Index page
                                                      // | So it looks for the index inthe same controller
                                                      // If we wanted to redircet to another controller we would put a cooma and name of the controller 
                                                      // Example "Index","___Controller"
                }
            return View(obj);    
        }

        //////////////////////////////////// Below are edit functionalities
        ///        //Get
        public IActionResult Edit(int? id) // When the render page is loaded it will display the new values
        {
            if (id == null || id == 0) { //Here we are checking the id is valid | if not we move on 
            return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //Once equiped will check it 
            if (categoryFromDb == null) {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //Post
        [HttpPost]  //Most be used for Posting 
        [ValidateAntiForgeryToken]// Prevents cross site request forgery attack | It basicly injects a key, and it most be validated 
        public IActionResult Edit(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "THe DisplayOrder cannot exactly match the Name."); //We can change "CustomError property to say name and this will move the error msg to wherer the name property is "
                // This line works injunction with view | the function-helper there is "asp-validation-summary="All"" When there is an errror this custom msg will pop-up
            }
            if (ModelState.IsValid)
            {//Exception - When the create button is hit it throws an exception error. bacause when we created the Catogry 
             // model it had requirements | Thus this arguement checks the requiremnts are met (ModelState) | This also condered a server-side validation
                _db.Categories.Update(obj); // THis gather wjats we are trying to send
                _db.SaveChanges();// This command will push it to db and save the changes
                TempData["success"] = "Category edited successfully";//TempDate stores values temerally | success is a key to access the msg | the msg is like a one time use where it will be deleted after reload
                return RedirectToAction("Index"); // Instead of "view" we redirct to see what was posted back on the Index page
                                                  // | So it looks for the index inthe same controller
                                                  // If we wanted to redircet to another controller we would put a cooma and name of the controller 
                                                  // Example "Index","___Controller"
            }
            return View(obj);
        }


        ////////////////////////////
        ///        //////////////////////////////////// Below are delete functionalities
        ///        //Get

        public IActionResult Delete(int? id) // When the render page is loaded it will display the new values
        {
            if (id == null || id == 0)
            { //Here we are checking the id is valid | if not we move on 
                return NotFound();
            }
            var categoryInDb = _db.Categories.Find(id);
            //Once equiped will check it 
            if (categoryInDb == null)
            {
                return NotFound();
            }

            return View(categoryInDb);
        }

        //Post
        [HttpPost, ActionName("Delete")]  //Most be used for Posting  | If we want to change the name for use in the action on view page we can add "ActionName" Attribute
        [ValidateAntiForgeryToken]// Prevents cross site request forgery attack | It basicly injects a key, and it most be validated 
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
           

                _db.Categories.Remove(obj); // Removes the object
                _db.SaveChanges();// This command will push it to db and save the changes
            TempData["success"] = "Category deleted successfully";//TempDate stores values temerally | success is a key to access the msg | the msg is like a one time use where it will be deleted after reload
            return RedirectToAction("Index"); // Instead of "view" we redirct to see what was posted back on the Index page
                                                 
        }

    }
}
// The Tempdata will apppear on the page if true | it is called throught its key in a if staement on the index page of category and if it is true it wil post/show