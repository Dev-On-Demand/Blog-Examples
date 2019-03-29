using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Custom_identity_Schema.DataModel
{
    [Table("Role")]
    public class CusRole
    {
        public CusRole()
        {
        }

        [Key]
        public int Id {  get;set; }

        [Required]
        public string Name {  get;set; }

        public virtual ICollection<CusUserRole> UserRoles {  get;set; }
    }
}
