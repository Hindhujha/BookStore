using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonLayer
{
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int UserId { get; set; }
        public string FullName { get; set; }

        public string EmailId { get; set; }

        public string password { get; set; }
        public string phNo { get; set; }

    }
}
