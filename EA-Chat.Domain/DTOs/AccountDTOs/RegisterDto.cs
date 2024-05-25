using System.ComponentModel.DataAnnotations;

namespace EA_Chat.Domain.DTOs.AccountDTOs;

public class RegisterDto
{
    #region Properties

    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(100, ErrorMessage = "حداکثر کاراکتر مجاز {1} میباشد")]
    public string UserName { get; set; }
    
    [Display(Name = "موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(11, ErrorMessage = "حداکثر کاراکتر مجاز {1} میباشد")]
    public string Mobile { get; set; }
    
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(350, ErrorMessage = "حداکثر کاراکتر مجاز {1} میباشد")]
    public string Email { get; set; }
    
    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(350, ErrorMessage = "حداکثر کاراکتر مجاز {1} میباشد")]
    public string Password { get; set; }
    
    [Display(Name = "تکرار رمز عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(350, ErrorMessage = "حداکثر کاراکتر مجاز {1} میباشد")]
    [Compare(nameof(Password), ErrorMessage = "رمز عبور و تکرار آن برابر نیست!")]
    public string RePassword { get; set; }
    
    #endregion
}