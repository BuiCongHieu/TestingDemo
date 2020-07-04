using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class RatingViewModel
    {
        public Guid Id { get; set; }
        public int idQuestion { get; set; }
        public int Scores { get; set; }
        public string comment { get; set; }
        public DateTime? CreateDay { get; set; }
        public int idService { get; set; }
        public string NameService { get; set; }
        public Guid EmployeeID { get; set; }
    }
}
