using System.Diagnostics;
using LinqProject.Data;
using LinqProject.Models;

namespace LinqProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            //1-List all customers' first and last names along with their email addresses.
            //var customer = context.Customers;
            //foreach(var item in customer) 
            //{
            //    Console.WriteLine($"FirstName : {item.FirstName} , LastName : {item.LastName} , EmailAddresses : {item.Email}");
            //} 

            //2 - Retrieve all orders processed by a specific staff member(e.g., staff_id = 3)
            //var orders=context.Orders.Where(e=>e.StaffId==3);
            //foreach(var item in orders)
            //{
            //    Console.WriteLine($"orderId :{item.OrderId} , OrderStatus : {item.OrderStatus}");
            //}

            //3 - Get all products that belong to a category named "Mountain Bikes".
            var products = context.Products.Where(e=>e.ca)


        }
    }
}
