using SeekAd.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeekAd.Data
{
    public static class Repository
    {
        public static List<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    Name = "SecondBite"
                },
                new Customer
                {
                    Name = "Axil Coffee Roasters"
                },
                new Customer
                {
                    Name = "MYER"
                },
                new Customer
                {
                    Name = "default"
                }
            };

            return customers;
        }
        public static List<Ad> GetAllAds()
        {
            var ads = new List<Ad>
            {
                new Ad
                {
                    Code = "classic",
                    Name = "Classic Ad",
                    Description = "Offers the most basic level of advertisement",
                    Cost = 269.99
                },
                new Ad
                {
                    Code = "standout",
                    Name = "Stand out Ad",
                    Description = "Allows advertisers to use a company logo and use a longer presentation text",
                    Cost = 322.99
                },
                new Ad
                {
                    Code = "premium",
                    Name = "Premium Ad",
                    Description = "Same benefits as Standout Ad, but also puts the advertisement at the top of the results, allowing higher visibility",
                    Cost = 394.99
                }
            };

            return ads;
        }
        public static List<Deal> GetAllDeals()
        {
            var pricingList = new List<Deal>
            {
               new Deal
               {
                   CustomerName = "SecondBite",
                   AdCode = "classic",
                   PurchaseSize = 3,
                   CostSize = 2,
                   DiscountType = DiscountType.XForY
               },
               new Deal
               {
                   CustomerName = "Axil Coffee Roasters",
                   AdCode = "standout",
                   Discount = 23,
                   DiscountType = DiscountType.Amount
               },
               new Deal
               {
                   CustomerName = "MYER",
                   AdCode = "standout",
                   PurchaseSize = 5,
                   CostSize = 4,
                   DiscountType = DiscountType.XForY
               },
               new Deal
               {
                   CustomerName = "MYER",
                   AdCode = "premium",
                   Discount = 5,
                   DiscountType = DiscountType.Amount
               }
            };

            return pricingList;
        }
        public static List<Deal> GetDealsByCustomerName(string customerName)
        {
            var deals = GetAllDeals();
            return deals.Where(x => string.Equals(x.CustomerName, customerName, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
    }
}
