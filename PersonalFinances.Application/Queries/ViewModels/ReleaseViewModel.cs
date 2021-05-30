using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalFinances.Application.Queries.ViewModels
{
    public class ReleaseViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public string Account { get; set; }
        public string Type { get; set; }
    }
}
