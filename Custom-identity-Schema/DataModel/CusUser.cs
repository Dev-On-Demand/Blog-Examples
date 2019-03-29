using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Custom_identity_Schema.DataModel
{
    [Table("ApplicationUser")]
    public class CusUser
    {
        public CusUser()
        {
        }

        [Key]
        public int Id {  get;set; }

        [Required]
        public string Firstname {  get;set; }

        [Required]
        public string Lastname {  get;set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email {  get;set; }

        [Required]
        public string PasswordHash {  get;set; }

        public virtual ICollection<CusUserRole> UserRoles {  get;set; }
    }
}
