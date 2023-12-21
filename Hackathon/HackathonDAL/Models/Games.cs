using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.DAL.Models
{
    [Table("Games")]
    public class Games
    {
        public int ID { get; set; }
        public Guid GameKey { get; set; }
        public Guid Gamer1Key { get; set; }
        public Guid Gamer2Key { get; set; }
        public int Gamer1Point { get; set; }
        public int Gamer2Point { get; set; }
        public int Gamer1Question { get; set; }
        public int Gamer2Question { get; set; }
        public bool Gamer1Finish { get; set; }
        public bool Gamer2Finish { get; set; }
    }
}
