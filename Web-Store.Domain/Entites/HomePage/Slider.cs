using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Domain.Entites.Commons;

namespace Web_Store.Domain.Entites.HomePage
{
    public class Slider:BaseEntites
    {
        public string Src {  get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
    }
}
