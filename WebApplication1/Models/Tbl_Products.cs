namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Tbl_Products
    {
        [Display(Name = "آیدی")]
        public int Id { get; set; }
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        [StringLength(20,MinimumLength =2,ErrorMessage ="نام حداقل 2 کاراتر حداکثر 20 کاراکتر")]
        public string Product_Name { get; set; }
        [Display(Name = "توضیحات محصول")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        [DataType(DataType.MultilineText)]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "نام حداقل 2 کاراتر حداکثر 100 کاراکتر")]
        public string Product_Details { get; set; }
        [Display(Name = "قیمت محصول")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        [RegularExpression("^[0-9]+$",ErrorMessage ="قیمت را به صورت عددی و به تومان وارد کنید")]
        
        public string Product_Price { get; set; }
        [Display(Name = "عکس محصول")]
        [DataType(DataType.Upload)]
        public string Product_Image { get; set; }
        [Display(Name = "ثبت کننده محصول")]
        public int Product_UserId { get; set; }

        public virtual Tbl_Users Tbl_Users { get; set; }
    }
}


