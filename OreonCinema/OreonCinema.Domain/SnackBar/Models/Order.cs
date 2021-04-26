namespace OreonCinema.Domain.SnackBar.Models
{
    using OreonCinema.Domain.Common;
    using OreonCinema.Domain.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Order : Entity<int>, IAggregateRoot
    {
        private readonly IList<Food> foods;
        private readonly IList<Drink> drinks;

        internal Order()
        {
            this.foods = new List<Food>();
            this.drinks = new List<Drink>();

            this.DateCreated = DateTime.Now;
            this.OrderNumber = Guid.NewGuid().ToString()[..8];
        }

        public DateTime DateCreated { get; }

        public string OrderNumber { get; }

        public IReadOnlyCollection<Food> Foods => this.foods.ToList().AsReadOnly();

        public IReadOnlyCollection<Drink> Drinks => this.drinks.ToList().AsReadOnly();

        public Order AddFood(Food food)
        {
            this.foods.Add(food);

            return this;
        }

        public Order AddDrink(Drink drink)
        {
            this.drinks.Add(drink);

            return this;
        }
    }
}
