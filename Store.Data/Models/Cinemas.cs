using System;
using System.Collections.Generic;

namespace Store.Data.Models
{
    public class Cinemas
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }

    }
}
