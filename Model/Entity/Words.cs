using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Entity
{
    internal class Words
    {
        [Key]
        public int ID { get; set; }
        public string Word{ get; set; }
    }
}
