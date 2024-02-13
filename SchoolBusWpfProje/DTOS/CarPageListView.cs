using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusWpfProje.DTOS
{
    public class CarPageListView
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string CarNumber { get; set; }
        public int FullPlace { get; set; }
        public int Capacity { get; set; }


    }
}
