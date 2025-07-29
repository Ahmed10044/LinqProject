using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Threading.Channels;
using LinqProject.Data;
using LinqProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            //var products = context.Products.Where(e => e.Category.CategoryName == "Mountain Bikes");
            //foreach (var item in products)
            //{
            //    Console.WriteLine($"productId: {item.ProductId} , productName : {item.ProductName}");
            //}

            //4 - Count the total number of orders per store.
            //var ordersPerStore = context.Orders
            //    .GroupBy(e => e.Store.StoreName)
            //    .Select(e => new
            //    {
            //        StoreName = e.Key,
            //        OrderCount = e.Count()
            //    });
            //foreach (var item in ordersPerStore)
            //{
            //    Console.WriteLine($"Store: {item.StoreName}, Orders: {item.OrderCount}");
            //}


            //5 - List all orders that have not been shipped yet(shipped_date is null).
            //var orders = context.Orders.Where(e => e.ShippedDate == null);
            //foreach (var item in orders) 
            //{ 
            //    Console.WriteLine($"OrderId :{item.OrderId} , OrderStatus :{item.OrderStatus}");
            //}

            //6 - Display each customer’s full name and the number of orders they have placed.
            //var customerOrders = context.Customers
            //      .Select(e => new
            //      {
            //          FullName = e.FirstName + " " + e.LastName,
            //          OrderCount = e.Orders.Count()
            //      });
            //foreach (var item in customerOrders)
            //{
            //    Console.WriteLine($"Customer: {item.FullName}, Orders: {item.OrderCount}");
            //}

            //7 - List all products that have never been ordered(not found in order_items).

            //8 - Display products that have a quantity of less than 5 in any store stock.
            //var lowStockProducts = context.Stocks
            //  .Where(e => e.Quantity < 5)
            //  .Select(e => e.Product);

            //foreach (var product in lowStockProducts)
            //{
            //    Console.WriteLine($"Product: {product.ProductName} (ID: {product.ProductId})");
            //}

            //9 - Retrieve the first product from the products table.
            //var firstProduct=context.Products.First(e=>e.ProductId==1);
            //Console.WriteLine($"productId: {firstProduct.ProductId} , productName : {firstProduct.ProductName} , ModelYear : {firstProduct.ModelYear}");

            //10 - Retrieve all products from the products table with a certain model year.
            //var productAndModelYear = context.Products.Select(e => new
            //{
            //    e.ProductId,
            //    e.ProductName,
            //    e.ModelYear,
            //});
            //foreach (var item in productAndModelYear)
            //{
            //    Console.WriteLine($" ProductName:{item.ProductName} , ModelYear:{item.ModelYear} ");
            //}

            //11 - Display each product with the number of times it was ordered. 
            //var productOrderCounts = context.Products
            // .Select(e => new
            // {
            //     Product_Name = e.ProductName,
            //     TimesOrdered = e.OrderItems.Count()
            // });
            //foreach (var item in productOrderCounts)
            //{
            //    Console.WriteLine($"Product: {item.Product_Name}, Ordered: {item.TimesOrdered} times");
            //}

            //12 - Count the number of products in a specific category.
            //var ProductInProduct = context.Categories
            //    .Select(e => new
            //    {
            //        categoryName = e.CategoryName,
            //        numOfProduct = e.Products.Count(),
            //    });
            //foreach (var item in ProductInProduct)
            //{
            //    Console.WriteLine($"categoryName: {item.categoryName}, numOfProduct: {item.numOfProduct} ");
            //}

            //13 - Calculate the average list price of products. 
            //var averageProducts = context.Products.Average(e=>e.ListPrice);
            //Console.WriteLine($"the average list price of product : {averageProducts}");

            //14 - Retrieve a specific product from the products table by ID
            //int productId = Convert.ToInt32(Console.ReadLine());
            //var product = context.Products.FirstOrDefault(e=>e.ProductId== productId);
            //if (product != null)
            //{
            //    Console.WriteLine($"productName :{product.ProductName} , ModelYear :{product.ModelYear} , ListPrice :{product.ListPrice} , Brand :{product.Brand}");
            //}
            //else {
            //    Console.WriteLine("error");
            //     };

            //15 - List all products that were ordered with a quantity greater than 3 in any order. 
            //var product = context.OrderItems
            //    .Where(e => e.Quantity >3)
            //    .Select(e => e.Product);
            //foreach (var item in product)
            //{
            //    Console.WriteLine($"Product: {item.ProductName} (ID: {item.ProductId})");
            //}

            //16 - Display each staff member’s name and how many orders they processed. 
            //var StaffOrders = context.Staffs.Select(e => new
            //{
            //    fullName = e.FirstName + " " + e.LastName,
            //    orderCount=e.Orders.Count()
            //});
            //foreach (var item in StaffOrders)
            //{
            //    Console.WriteLine($"fullName :{item.fullName} , orderCount :{item.orderCount}");
            //}

            //17 - List active staff members only(active = true) along with their phone numbers. active should define as bool not bytexxxxxxxxxxxxxxxxxxxxxx
            //var activeMembersOnly = context.Staffs.Where(e=>e.Active==1)
            //.Select(e => new
            //{
            //    fullName = e.FirstName + " " + e.LastName,
            //    phone = e.Phone
            //});

            //foreach (var item in activeMembersOnly)
            //{
            //    Console.WriteLine($"Staff: {item.fullName}, Phone: {item.phone}");
            //}

            //18 - List all products with their brand name and category name.
            //var products = context.Products.Select(e=>new
            //{
            //    e.ProductName,
            //    e.Brand.BrandName,
            //    e.Category.CategoryName
            //});
            //foreach (var item in products)
            //{
            //    Console.WriteLine($"ProductName:{item.ProductName},BrandName:{item.BrandName},CategoryName:{item.CategoryName}");
            //}


            //19 - Retrieve orders that are completed. OrderStatus should define as string not bytexxxxxxxxxxxxxxxxxxxxxx
            //var completedOrders = context.Orders.Where(e => e.OrderStatus ==3);
            //foreach (var item in completedOrders)
            //{
            //    Console.WriteLine($"orderId;{item.OrderId},OrderDate:{item.OrderDate}");
            //}

            //20 - List each product with the total quantity sold(sum of quantity from order_items).
            //var productWithTotalQuantity = context.Products.Select(e => new
            //{
            //    productName = e.ProductName,
            //    totalSold = e.OrderItems.Sum(e => e.Quantity)
            //});
            //foreach (var item in productWithTotalQuantity)
            //{
            //    Console.WriteLine($"productName:{item.productName} , totalSold :{item.totalSold}");
            //}





        }
    }
}
