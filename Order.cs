using System.ComponentModel.DataAnnotations;

namespace Wang_Gloria_HW2.Models
{
    public enum CustomerType { Direct, Wholesale }
    public abstract class Order
    {
        //fields - constants for book prices

        public const Decimal HARDBACK_PRICE = 17.95m;
        public const Decimal PAPERBACK_PRICE = 9.50m;

        // properties shared by both order types

        [Display(Name = "Customer Type:")]
        public CustomerType CustomerType { get; set; }

        [Display(Name = "Number of Hardback Books:")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [Required(ErrorMessage = "Number of hardbacks is required!")]
        [Range(0, 10000, ErrorMessage = "The number of hardbacks must be at least zero.")]
        public Int32 NumberOfHardbacks { get; set; }

        [Display(Name = "Number of Paperback Books:")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [Required(ErrorMessage = "Number of paperbacks is required!")]
        [Range(0, 10000, ErrorMessage = "The number of paperbacks must be at least zero.")]
        public Int32 NumberOfPaperbacks { get; set; }

        // private set because read only

        [Display(Name = "Hardback Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal HardbackSubtotal { get; private set; }

        [Display(Name = "Paperback Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal PaperbackSubtotal { get; private set; }

        [Display(Name = "Subtotal:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Subtotal { get; private set; }

        [Display(Name = "Total:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal Total { get; protected set; }

        [Display(Name = "Total Items:")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public Int32 TotalItems { get; private set; }

        // method with exception

        public void CalcSubtotals()
        {
            TotalItems = NumberOfHardbacks + NumberOfPaperbacks;
            if (TotalItems == 0)
            {
                throw new Exception("You must purchase at least one item");
            }

            HardbackSubtotal = NumberOfHardbacks * HARDBACK_PRICE;

            PaperbackSubtotal = NumberOfPaperbacks * PAPERBACK_PRICE;

            Subtotal = HardbackSubtotal + PaperbackSubtotal;
        }
    }
}
