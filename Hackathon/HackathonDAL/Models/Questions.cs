using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.DAL.Models
{
    [Table("Questions")]
    public class Questions
    {
        public int ID { get; set; }
        public int QuestionNumber { get; set; }
        public string? QuestionTR { get; set; }
        public string? QuestionEN { get; set; }
        [StringLength(1)]
        public string? Answer { get; set; }
    }
}
