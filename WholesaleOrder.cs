using System.ComponentModel.DataAnnotations;

namespace Wang_Gloria_HW2.Models
{
    public class WholesaleOrder : Order
    {
        // properties for wholesale orders

        [Display(Name = "Customer Code:")]
        [Required(ErrorMessage = "Customer code is required!")]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "Customer code must be 4-6 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Customer code may only contain letters.")]
        public String CustomerCode { get; set; }

        [Display(Name = "Delivery Fee:")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Required(ErrorMessage = "Delivery fee is required!")]
        [Range(0, 250, ErrorMessage = "Delivery fee must be between 0 and 250.")]
        public Decimal DeliveryFee { get; set; }

        [Display(Name = "Is this customer a preferred customer?")]
        public Boolean PreferredCustomer { get; set; }

        // methods

        public void CalcTotals()
        {
            try
            {
                // call calcSubtotals on base class
                base.CalcSubtotals();
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error!", ex);
            }

            // set DeliveryFee property
            if (PreferredCustomer == true || Subtotal >= 1200)
            { DeliveryFee = 0; }

            // calculate total
            base.Total = base.Subtotal + DeliveryFee;
        }
    }
}
