using CoffeShop.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.Services
{
    public class CoffeService
    {
        private readonly static IEnumerable<Coffee> _coffees = new List<Coffee>
        {
            new Coffee
            {
                Name = "Cappuccino",
                SubTitle = "Delight",
                Image = "cappuccino",
                Price = 5.00
            },
            new Coffee
            {
                Name = "Cappuccino",
                SubTitle = "Decaf",
                Image = "cappuccino2",
                Price = 5.00
            },
            new Coffee
            {
                Name = "Cappuccino",
                SubTitle = "Delight",
                Image = "cappuccino4",
                Price = 5.00
            },new Coffee
            {
                Name = "Cappuccino",
                SubTitle = "Delight",
                Image = "cappuccino5",
                Price = 5.00
            },
            
            new Coffee
            {
                Name = "Arctic ColdBrew",
                SubTitle = "Mountain",
                Image = "coldbrew1",
                Price = 6.00
            },

            new Coffee
            {
                Name = "Midnight ColdBrew",
                SubTitle = "Tranquil",
                Image = "coldbrew2",
                Price = 6.00
            },


            new Coffee
            {
                Name = "Starbucks light",
                SubTitle = "Summit",
                Image = "starbuck1",
                Price = 5.00
            },

            new Coffee
            {
                Name = "StarBucks",
                SubTitle = "Pike's",
                Image = "starbuck2",
                Price = 5.00
            },

            new Coffee
            {
                Name = "Velvet Mocha",
                SubTitle = "Decaf",
                Image = "mocha1",
                Price = 6.00
            },

            new Coffee
            {
                Name = "Rich Mocha",
                SubTitle = "Tranquil",
                Image = "mocha2",
                Price = 6.00
            },

            new Coffee
            {
                Name = "Iced Coffee",
                SubTitle = "Peaceful",
                Image = "icedcoffe1",
                Price = 7.00
            },

            new Coffee
            {
                Name = "Iced Coffee",
                SubTitle = "Crest",
                Image = "icedcoffe2",
                Price = 7.00
            },
        };


        public IEnumerable<Coffee> GetAllCoffees() => _coffees;
        public IEnumerable<Coffee> GetAllPopularCoffees(int count = 3) => _coffees.OrderBy(p => Guid.NewGuid()).Take(count);
        public IEnumerable<Coffee> GetAllbelowPopularCoffees(int count = 5) => _coffees.OrderBy(p => Guid.NewGuid()).Take(count);
        public IEnumerable<Coffee> GetSpelicalOfferCoffee(int count = 1) => _coffees.OrderBy(p => Guid.NewGuid()).Take(count);
        public IEnumerable<Coffee> SearchCoffees(String searchItem) => String.IsNullOrWhiteSpace(searchItem) ? _coffees : _coffees.Where(p => p.Name.Contains(searchItem, StringComparison.OrdinalIgnoreCase));
        public IEnumerable<Coffee> FilterCoffees(String searchItem) => String.IsNullOrWhiteSpace(searchItem) ? _coffees : _coffees.Where(p => p.Name.Contains(searchItem, StringComparison.OrdinalIgnoreCase));


    }
}
