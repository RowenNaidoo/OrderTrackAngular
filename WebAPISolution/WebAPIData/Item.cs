//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public Item()
        {
            this.CartItem = new HashSet<CartItem>();
            this.CPAStage = new HashSet<CPAStage>();
        }
    
        public long ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CategoryID { get; set; }
        public decimal Price { get; set; }
        public string ItemImage { get; set; }
    
        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<CPAStage> CPAStage { get; set; }
    }
}
