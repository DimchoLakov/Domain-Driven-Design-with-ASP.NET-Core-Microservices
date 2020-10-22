namespace OreonCinema.Domain.Bookings.Models.Bookings
{
    using Common.Models;
    using Exceptions;

    using static ModelConstants.Seat;

    public class Seat : ValueObject
    {
        internal Seat(int rowNumber, string rowLetter, SeatStatus seatStatus)
        {
            this.Validate(rowNumber, rowLetter);

            this.RowNumber = rowNumber;
            this.RowLetter = rowLetter;
            this.SeatStatus = seatStatus;
        }

        private Seat(int rowNumber, string rowLetter)
        {
            this.RowNumber = rowNumber;
            this.RowLetter = rowLetter;

            this.SeatStatus = default!;
        }

        public int RowNumber { get; private set; }

        public string RowLetter { get; private set; }

        public SeatStatus SeatStatus { get; private set; }

        private void Validate(int rowNumber, string rowLetter)
        {
            this.ValidateRowNumber(rowNumber);
            this.ValidateRowLetter(rowLetter);
        }

        private void ValidateRowLetter(string rowLetter)
        {
            Guard.ForRegex<InvalidSeatException>(
                rowLetter,
                RowLetterRegexPattern,
                nameof(this.RowLetter));
        }

        private void ValidateRowNumber(int rowNumber)
        {
            Guard.AgainstOutOfRange<InvalidSeatException>(
                rowNumber,
                MinRowNumber,
                MaxRowNumber,
                nameof(this.RowNumber));
        }

        public string GetSeatName()
        {
            return $"{this.RowNumber}{this.RowLetter}";
        }
    }
}
