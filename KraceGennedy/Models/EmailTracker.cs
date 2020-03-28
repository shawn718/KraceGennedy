using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KraceGennedy.Models
{
    public class EmailTracker
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(name: "ScheduleId")]
        public Schedule Schedule { get; set; }
        public int ScheduleId { get; set; }
        public bool Sent { get; set; }
        public DateTime DateSent { get; set; }
    }
}
