using EntityAccess;
using System.Collections.Generic;

namespace Model
{
    public class Vinil : Entity
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Styles { get;set;}
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
