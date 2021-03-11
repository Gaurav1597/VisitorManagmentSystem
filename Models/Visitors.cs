using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VisitorManagmentSystem.Models
{
    public class Visitors
    {
      [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastNAme { get; set; }
        public string Business { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime Dateout { get; set; }
        public StaffNames StaffName { get; set; }

    }
}
