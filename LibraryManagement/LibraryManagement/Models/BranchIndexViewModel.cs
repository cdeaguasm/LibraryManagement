using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class BranchIndexViewModel
    {
        public IEnumerable<BranchDetailViewModel> Branches { get; set; }
    }
}
