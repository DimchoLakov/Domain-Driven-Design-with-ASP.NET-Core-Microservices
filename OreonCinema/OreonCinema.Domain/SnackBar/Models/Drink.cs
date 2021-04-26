namespace OreonCinema.Domain.SnackBar.Models
{
    using OreonCinema.Domain.Common.Models;
    using OreonCinema.Domain.SnackBar.Exceptions;

    public class Drink : Entity<int>
    {
        internal Drink(
            string name,
            double amount,
            decimal price)
        {
            this.ValidateName(name);
            this.ValidateAmount(amount);
            this.ValidatePrice(price);

            this.Name = name;
            this.Amount = amount;
            this.Price = price;
        }

        public string Name { get; private set; }

        public double Amount { get; private set; }

        public decimal Price { get; private set; }

        private void ValidateName(string name)
        {
            Guard.AgainstEmptyString<InvalidDrinkException>(name, nameof(this.Name));
        }

        private void ValidatePrice(decimal price)
        {
            Guard.AgainstOutOfRange<InvalidDrinkException>(price, ModelConstants.Common.Zero, decimal.MaxValue, nameof(this.Price));
        }

        private void ValidateAmount(double amount)
        {
            Guard.AgainstOutOfRange<InvalidDrinkException>(amount, ModelConstants.Common.Zero, double.MaxValue, nameof(this.Amount));
        }

        public Drink ChangeName(string name)
        {
            this.ValidateName(name);

            this.Name = name;

            return this;
        }

        public Drink ChangeAmount(double amount)
        {
            this.ValidateAmount(amount);

            this.Amount = amount;

            return this;
        }

        public Drink ChangePrice(decimal price)
        {
            this.ValidatePrice(price);

            this.Price = price;

            return this;
        }
    }
}
