using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantAPI.Entities;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC - DESCRIPTION HERE, LOREM IPSUM",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Hot Chicken",
                            Price = 10.30M
                        },
                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 5.30M
                        },
                    },
                    Address = new Address()
                    {
                        City = "Krakow",
                        Street = "Dluga 5",
                        PostalCode = "30-001"
                    }
                },
                new Restaurant()
                {
                    Name = "MC Donald",
                    Category = "Fast Food",
                    Description = "MC - DESCRIPTION HERE, LOREM IPSUM",
                    ContactEmail = "contact@mcdonald.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Burger",
                            Price = 8.30M
                        },
                        new Dish()
                        {
                            Name = "Fries",
                            Price = 6.30M
                        },
                    },
                    Address = new Address()
                    {
                        City = "Warszawa",
                        Street = "Jasna 13",
                        PostalCode = "30-210"
                    }
                }
            };
            return restaurants;
        }
    }
}
