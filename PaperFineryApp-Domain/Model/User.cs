using Microsoft.AspNetCore.Identity;

namespace PaperFineryApp_Domain.Model
{
    public class User:IdentityUser
    {      
        public Supplier Supplier { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
//i believe it should be the supplier
//Review is for what? Apphow the transaction went, weda it was convience and the everything about the process 
//so manufacturer no get say?well yh?