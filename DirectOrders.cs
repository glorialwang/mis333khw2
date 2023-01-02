using System.ComponentModel.DataAnnotations;

namespace Wang_Gloria_HW2.Models
{
    public class DirectOrder : Order
    {
        //field - named constants

        private const Decimal SALES_TAX_RATE = 0.0825m;

        //properties for direct orders

        [Display(Name = "Customer Name:")]
        public String? CustomerName { get; set; }

        // private set because read only

        [Display(Name = "Sales Tax:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Decimal SalesTax { get; private set; }

        // methods

        public void CalcTotals()
        {
            try
            {
                // call CalcSubtotals on base class
                base.CalcSubtotals();
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error!", ex);
            }

            // calculate sales tax
            SalesTax = base.Subtotal * SALES_TAX_RATE;

            // calculate the total
            base.Total = base.Subtotal + SalesTax;
        }
    }
}


