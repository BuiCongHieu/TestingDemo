using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rating
    {
        public virtual Employee Employee {get; set;}
        public Guid Id { get; set; }

        public int idQuestion { get; set; }

        public int Scores { get; set; }

        public string comment { get; set; }

        public DateTime? CreateDay { get; set; }

        public int idService { get; set; }
    }
}
