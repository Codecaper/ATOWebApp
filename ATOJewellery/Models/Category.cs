using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ATOJewellery.Models;
//Is a creation example of a model  | It will be pushed to our database creating a table with these four coloumns
public class Category
{ 
  [key] //We have data annotation / attribute called key  | to make it work we use "Control + . " to add a using statement.
        //Press enter and it now has the data annotation we want which is to utilize Id as a primary-key and it is an "identity coloumn"
        // THis is what we are telling the entityframe work to do | it does all the configuration and talking by itself 
public int Id { get; set; }
    //here withname we want another attribute "Required" 
    [Required]
    public string Name { get; set; }

    [DisplayName("Display Order")] //This line will Change the name DisplaOrder into into Display Order w/ a space 
    [Range(1,100,ErrorMessage ="Display Order must be between 1 and 100 only!!")] //This creates a range for the inteiger in the Display input feild  | after the maximum value we camn add a custom Error msg
    public int DisplayOrder { get; set; }
    public DateTime CreatedDataTime { get; set; } = DateTime.Now; // The defualt value will automatically be assigned when we creat an object of this class
}
// As this Model is on to a good start we need to now have it stored in our "DataBase"
//We need to create a database and a table inside SQL Server