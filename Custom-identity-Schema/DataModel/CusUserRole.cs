using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Custom_identity_Schema.DataModel
{
    [Table("ApplicationUserRoles")]
    public class CusUserRole
    {
        public CusUserRole()
        {
        }

        [Key]
        public int Id {  get;set; }

        [Required]
        [ForeignKey(nameof(CusUser))]
        public int UserId {  get;set; }

        [Required]
        [ForeignKey(nameof(CusRole))]
        public int RoleId {  get;set; }

        public virtual CusUser User {  get;set; }
        public virtual CusRole Role {  get;set; }
    }
}
