using System.Collections.Generic;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    //Access Modifier ---> internal, public, private, protected
    public class Category
    {
        //Field
        //int x;

        //Property
        //public int x { get; set; }

        //Variable
        //void test()
        //{
        //    int x;
        //}

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }
        public List<Product> Products { get; set; }
    }
}
