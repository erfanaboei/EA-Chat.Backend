using System.ComponentModel.DataAnnotations;

namespace EA_Chat.Domain.DTOs.AccountDTOs;

public class LoginDto
{
    #region Properties

    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(100, ErrorMessage = "حداکثر کاراکتر مجاز {1} میباشد")]
    public string UserName { get; set; }
    
    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(350, ErrorMessage = "حداکثر کاراکتر مجاز {1} میباشد")]
    public string Password { get; set; }
    
    #endregion
}