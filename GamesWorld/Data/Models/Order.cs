using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GamesWorld.Data.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }

        [Display(Name = "First name:")]
        [StringLength(31)]
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name:")]
        [StringLength(31)]
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Display(Name = "Address:")]
        [Required(ErrorMessage = "Please enter your address")]
        [StringLength(50)]
        public string Address { get; set; }

        [Display(Name = "Zip code:")]
        [StringLength(21)]
        [Required(ErrorMessage = "Please enter your zip code")]
        public string ZipCode { get; set; }

        [Display(Name = "City:")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }

        [Display(Name = "Country:")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your country")]
        public string Country { get; set; }

        [Display(Name = "Phone number:")]
        [StringLength(21)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please enter your phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email:")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }

        [BindNever] //This attribute adds a model state error if binding cannot occur
        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime DateOfOrder { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
