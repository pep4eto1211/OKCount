//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OkService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class QRTZ_SIMPROP_TRIGGERS
    {
        public string SCHED_NAME { get; set; }
        public string TRIGGER_NAME { get; set; }
        public string TRIGGER_GROUP { get; set; }
        public string STR_PROP_1 { get; set; }
        public string STR_PROP_2 { get; set; }
        public string STR_PROP_3 { get; set; }
        public Nullable<int> INT_PROP_1 { get; set; }
        public Nullable<int> INT_PROP_2 { get; set; }
        public Nullable<long> LONG_PROP_1 { get; set; }
        public Nullable<long> LONG_PROP_2 { get; set; }
        public Nullable<decimal> DEC_PROP_1 { get; set; }
        public Nullable<decimal> DEC_PROP_2 { get; set; }
        public Nullable<bool> BOOL_PROP_1 { get; set; }
        public Nullable<bool> BOOL_PROP_2 { get; set; }
    
        public virtual QRTZ_TRIGGERS QRTZ_TRIGGERS { get; set; }
    }
}