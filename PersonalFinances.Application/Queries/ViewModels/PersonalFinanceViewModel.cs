using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalFinances.Application.Queries.ViewModels
{
    public class PersonalFinanceViewModel
    {
        public List<ReleaseViewModel> Releases { get; set; } = new List<ReleaseViewModel>();
    }
}
