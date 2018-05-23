using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzumiSagiris.Service.IzumiEntity
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public long UserID { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(2000)]
        public string token { get; set; }

        [NotMapped]
        public string TimeSpan { get; set; }
    }
}
