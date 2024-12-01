using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Entities
{
    public class Card
    {
        
        public int ID { get; set; }
        public string CardNumber { get; set; }
        public float Balance { get; set; }
        public bool IsActive { get; set; } = true;
        public string Password { get; set; }
        public User owner { get; set; }
        public int UserID { get; set; }
        public int WrongPassTry {get; set; }
       
        public List <Transaction> RecivedTransaction { get; set; }
        public List<Transaction> SentTransaction { get; set; }
       
    }
}
