//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Avarez.Models
{
    using System;
    
    public partial class sp_Peacockery_LogSelect
    {
        public long fldID { get; set; }
        public long کد_پرونده { get; set; }
        public string تاریخ_صدور { get; set; }
        public int کد_شماره_حساب { get; set; }
        public string کد_فیش { get; set; }
        public int اصل_عوارض { get; set; }
        public int جریمه { get; set; }
        public int ارزش_افزوده { get; set; }
        public int سایر_مبالغ { get; set; }
        public int مبلغ_کل { get; set; }
        public string از_تاریخ { get; set; }
        public string تا_تاریخ { get; set; }
        public Nullable<int> مبلغ_تخفیف { get; set; }
        public Nullable<int> ارزش_افزوده_تخفیف { get; set; }
        public Nullable<int> سایر_تخفیف { get; set; }
        public string توضیحات { get; set; }
        public string تاریخ_ایجاد { get; set; }
        public string کاربر_ایجاد_کننده { get; set; }
        public string نوع_تغییرات { get; set; }
        public Nullable<System.TimeSpan> ساعت_تغییرات { get; set; }
        public string موقعیت_کاربر_ایجاد_کننده { get; set; }
    }
}
