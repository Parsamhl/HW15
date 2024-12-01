using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW15.Entities
{
    public class User
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public List<Card> Cards { get; set; }


    }
}
