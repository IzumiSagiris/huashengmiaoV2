using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzumiSagiris.Service.IzumiEntity
{
    public class StudentEntity
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        [MaxLength(50)]
        public string StudentName { get; set; }


        /// <summary>
        /// 0,未就业,1已就业,2考研
        /// </summary>
        public int Status { get; set; }
    }
}
