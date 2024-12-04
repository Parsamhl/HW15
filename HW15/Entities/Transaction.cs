using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Entities
{
    public class Transaction
    {
    
        public int TransactionsId { get; set; }
      
        public int SourceCardNumberId { get; set; }
        
        public int DestinationCardNumberID{ get; set; }
        
        public float Amount { get; set; }
        
        public float? Fee { get; set; }
     
        public DateTime TransactionDate { get; set; }
       
        public bool IsSuccessful { get; set; }
        public Card SourceCard { get; set; }
        public Card DestinationCard { get; set; }
    }
}
