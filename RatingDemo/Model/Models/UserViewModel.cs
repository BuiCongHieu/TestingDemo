using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    [Serializable]
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string passCode { get; set; }
        public int idService { get; set; }
    }
}
