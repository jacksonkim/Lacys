//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LacysMobile.Management
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public user()
        {
            this.webpages_UsersInRoles = new HashSet<webpages_UsersInRoles>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string CellNumber { get; set; }
        public string PhoneExtension { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime ModifiedOn { get; set; }
    
        public virtual ICollection<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }
    }
}
