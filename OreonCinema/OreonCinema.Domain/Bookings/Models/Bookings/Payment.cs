namespace OreonCinema.Domain.Bookings.Models.Bookings
{
    using Common.Models;
    using Exceptions;
    using System;

    using static ModelConstants.Payment;

    public class Payment : Entity<int>
    {
        internal Payment(decimal amount, PaymentStatus paymentStatus)
        {
            this.ValidateAmount(amount);

            this.Amount = amount;
            this.PaymentStatus = paymentStatus;
            this.OnDate = DateTime.Now;
        }

        private void ValidateAmount(decimal amount)
        {
            Guard.AgainstOutOfRange<InvalidPaymentException>(
                amount,
                MinAmount,
                MaxAmount,
                nameof(this.Amount));
        }

        private Payment(decimal amount)
        {
            this.Amount = amount;
            this.PaymentStatus = default!;
            this.OnDate = DateTime.Now;
        }

        public decimal Amount { get; private set; }

        public PaymentStatus PaymentStatus { get; private set; }

        public DateTime OnDate { get; private set; }
    }
}
