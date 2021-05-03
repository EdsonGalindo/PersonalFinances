using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalFinances.Domain.Entities
{
    public class Release
    {
        public int ID { get; private set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public string Account { get; set; }
        public string Type { get; set; }

        public Release()
        {

        }
    }
}
