using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class PatronIndexViewModel
    {
        public IEnumerable<PatronDetailViewModel> Patrons { get; set; }
    }
}
