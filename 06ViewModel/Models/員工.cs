//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace _06ViewModel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class 員工
    {
        public int 員工編號 { get; set; }
        public string 姓名 { get; set; }
        public string 名 { get; set; }
        public string 稱呼 { get; set; }
        public Nullable<System.DateTime> 出生日期 { get; set; }
        public string 地址 { get; set; }
        public string 城市 { get; set; }
        public string 行政區 { get; set; }
        public Nullable<int> 職稱 { get; set; }
    
        public virtual 職稱 職稱1 { get; set; }
    }
}
