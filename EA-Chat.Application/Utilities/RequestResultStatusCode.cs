﻿using System.ComponentModel.DataAnnotations;

namespace EA_Chat.Application.Utilities;

public enum RequestResultStatusCode
{
    [Display(Name = "عملیات با موفقیت انجام شد")]
    Success = 200,

    [Display(Name = "خطایی در سرور رخ داده است")]
    ServerError = 500,

    [Display(Name = "پارامتر های ارسالی معتبر نیستند")]
    BadRequest = 400,

    [Display(Name = "یافت نشد")]
    NotFound = 404,

    [Display(Name = "خطای احراز هویت")]
    UnAuthorized = 401,
    
    [Display(Name = "داده وارد شده از قبل وجود دارد")]
    Conflict = 409
}