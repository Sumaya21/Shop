//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shop
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductsCustomer
    {
        public int Id { get; set; }
        public int CustomersId { get; set; }
        public int ProductsId { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
