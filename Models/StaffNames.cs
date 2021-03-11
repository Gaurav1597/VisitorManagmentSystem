using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace VisitorManagmentSystem.Models
{
    public class StaffNames
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public String Department { get; set; }
        public int VisitorCount { get; set; }
    }
}
