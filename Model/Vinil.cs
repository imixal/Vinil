using EntityAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Vinil : Entity
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Style { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
