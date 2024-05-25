using System.ComponentModel.DataAnnotations;

namespace EA_Chat.Domain.DTOs.AccountDTOs;

public class ForgotPasswordDto
{
    #region Properties

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(350, ErrorMessage = "حداکثر کاراکتر مجاز {1} میباشد")]
    public string Email { get; set; }
    
    #endregion
}