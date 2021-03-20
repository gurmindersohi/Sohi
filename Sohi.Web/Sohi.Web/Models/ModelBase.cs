using System;
namespace Sohi.Web.Models
{
    public class ModelBase : ICloneable
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
