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
    
    public partial class User
    {
        public User()
        {
            this.Booking = new HashSet<Booking>();
        }
    
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int FailedPasswordAttemptCount { get; set; }
        public string IsLockedOut { get; set; }
        public Nullable<System.DateTime> LockedOutDate { get; set; }
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual ICollection<Booking> Booking { get; set; }
    }
}