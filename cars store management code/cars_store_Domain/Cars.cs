using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cars_store_Domain
{
    //
    public class Cars
    {
        public Cars()
        {
            listparts = new List<parts>();
        }
        public int id { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string gear { get; set; }
        public double KM { get; set; }
        public  string  Color { get; set; }
        public List<parts> listparts { get; set; }
       
    }
}
