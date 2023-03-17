using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCredit.Models
{
    public class credit
    {
        public int id { get; set; }
        public int id_client { get; set; }
        public DateTime date { get; set; }
        public string articles { get; set; }
        public int cost { get; set; }
        public int final_cost { get; set; }
    }
}
