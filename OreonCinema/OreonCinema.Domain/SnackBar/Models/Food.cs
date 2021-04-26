namespace OreonCinema.Domain.SnackBar.Models
{
    using OreonCinema.Domain.Common.Models;
    using OreonCinema.Domain.SnackBar.Exceptions;

    public class Food : Entity<int>
    {
        public Food(
            string name,
            double weight,
            decimal price)
        {
            this.ValidateName(name);
            this.ValidateWeight(weight);
            this.ValidatePrice(price);

            this.Name = name;
            this.Weight = weight;
            this.Price = price;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public decimal Price { get; private set; }

        private void ValidateName(string name)
        {
            Guard.AgainstEmptyString<InvalidFoodException>(name, nameof(this.Name));
        }

        private void ValidatePrice(decimal price)
        {
            Guard.AgainstOutOfRange<InvalidFoodException>(price, ModelConstants.Common.Zero, decimal.MaxValue, nameof(this.Price));
        }

        private void ValidateWeight(double weight)
        {
            Guard.AgainstOutOfRange<InvalidFoodException>(weight, ModelConstants.Common.Zero, double.MaxValue, nameof(this.Weight));
        }

        public Food ChangeName(string name)
        {
            this.ValidateName(name);

            this.Name = name;

            return this;
        }

        public Food ChangeAmount(double weight)
        {
            this.ValidateWeight(weight);

            this.Weight = weight;

            return this;
        }

        public Food ChangePrice(decimal price)
        {
            this.ValidatePrice(price);

            this.Price = price;

            return this;
        }
    }
}
