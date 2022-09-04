using System.Data.Entity;

namespace demo.Models
{
    public class onlinecontext : DbContext
    {

        public onlinecontext() : base(@"Data Source=DESKTOP-J08FQ7J;Initial Catalog=DBProduct;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }


        public virtual DbSet<Product> products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }


    }
}
