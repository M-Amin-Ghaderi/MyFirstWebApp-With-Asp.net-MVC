//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Tbl_Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Users()
        {
            this.Tbl_Products = new HashSet<Tbl_Products>();
        }

        [Display(Name="آیدی")]
        public int Id { get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }
        [Display(Name = "موبایل")]
        public string Phone { get; set; }
        [Display(Name = "رمز عبور")]
        public string password { get; set; }
        [Display(Name="ایمیل")]
        public string Email { get; set; }
        [Display(Name = "تاریخ عضویت")]
        public System.DateTime Register_date { get; set; }
        [Display(Name = "جنسیت")]
        public Nullable<bool> gender { get; set; }
        [Display(Name = "وضعیت حساب")]
        public bool IsActive { get; set; }
        [Display(Name = "آیدی نقش کاربر")]
        public int UserRole_Id { get; set; }
    
        public virtual Tbl_Roles Tbl_Roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Products> Tbl_Products { get; set; }
    }
}
