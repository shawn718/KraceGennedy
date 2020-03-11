using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KraceGennedy.Models
{
    public class Position
    {
        [Key]
        public int ID { get; set; }
        public string PositionName { get; set; }
        public string PositionDesc { get; set; }

    }
}
