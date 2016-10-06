using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Task1
    {
        public static void TestQuery()
        {
            using (var db = new NorthwindDB())
            {
                int category = 1; // just for example - to check if it works 
                var query = from od in db.Order_Details
                            join o in db.Orders
                            on od.OrderID equals o.OrderID
                            join p in db.Products
                            on od.ProductID equals p.ProductID
                            join c in db.Customers
                            on o.CustomerID equals c.CustomerID
                            where p.CategoryID == category
                            select new { od, c.CompanyName, p.ProductName };

                foreach (var q in query)
                    Console.WriteLine("{0} {1} {2} {3} {4} | {5} {6}",
                        q.od.OrderID, q.od.ProductID, q.od.Quantity,
                        q.od.UnitPrice, q.od.Discount,
                        q.CompanyName, q.ProductName);

                Console.ReadLine();
            }
        }
    }
}
