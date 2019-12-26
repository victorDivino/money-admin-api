using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoneyAdmin.Application.ViewModels
{
    public class AccountViewModel
    {
        [Required(ErrorMessage = "The {0} is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Initial Value")]
        public decimal InitialValue { get; set; }
    }
}
