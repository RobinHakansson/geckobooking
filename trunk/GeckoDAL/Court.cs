//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GeckoDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Court
    {
        public Court()
        {
            this.Session = new HashSet<Session>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string HourlyFee { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual ICollection<Session> Session { get; set; }
    }
}
