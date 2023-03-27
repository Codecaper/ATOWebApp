using ATOJewellery.Models;
using Microsoft.EntityFrameworkCore;

namespace ATOJewellery.Data
{//TO allow this to work the "Control + . " was used to install Entity Framework and then we connected w/"COntrol + . "
    // The base class was also added to utilze the library DbContent
    public class ApplicationDBContext :DbContext
    {
        //We need oone line to establish the connection between entity frame work | Library variables are passed through the constructor 
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {//Once the program.cs configures itt comes here, we are passing the options and we are sending thase options to the base class. 
            // sending them to the base class
        }
       
        // In the Entity FrameWork there are two was to appraoach writing we took the code first approach } wrote the Model then Database \ The other appraoch is the databaase approach and this is usually because there is an exasiting database
        //Whatever models we have create inside the database, will need us to create a DbSet
       // When we create this Db will have the read lines under the class name in this Catogry, this is because it cannot find anything
       // named "Catagory" in the same file | We need to add the using staement , "Control + . " Will provide option to get to folder where
       //the "Category class was made"
       //THis will create a table called categoriesthat will house our "Category" Class/Model
        // the DbSet perameters: Class , inside database name(Create)
        public DbSet<Category> Categories { get; set; }    

        
    }
}
