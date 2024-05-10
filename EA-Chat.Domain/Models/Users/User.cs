using System.ComponentModel.DataAnnotations;

namespace EA_Chat.Domain.Models.Users;

public class User:BaseEntity
{
    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(100, ErrorMessage = "حداکثر کاراکتر مجاز {1} میباشد")]
    public string UserName { get; set; }
    
    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(350, ErrorMessage = "حداکثر کاراکتر مجاز {1} میباشد")]
    public string Email { get; set; }
    
    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(350, ErrorMessage = "حداکثر کاراکتر مجاز {1} میباشد")]
    public string Password { get; set; }
    
    [Display(Name = "موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(11, ErrorMessage = "حداکثر کاراکتر مجاز {1} میباشد")]
    public string Mobile { get; set; }
    
    [Display(Name = "آواتار")]
    [MaxLength(50, ErrorMessage = "حداکثر کاراکتر مجاز {1} میباشد")]
    public string? Avatar { get; set; }
    
    [Display(Name = "فعال/غیرفعال")]
    public bool IsActive { get; set; }

    [Display(Name = "تاریخ ثبت نام")]
    public DateTime RegisterDate { get; set; }
}