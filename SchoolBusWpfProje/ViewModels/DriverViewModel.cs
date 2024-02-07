using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusWpfProje.View
{
    public class DriverViewModel
    {
        public BasePageView basePageView { get; set; }

        public DriverViewModel(BasePageView basePageView)
        {
            this.basePageView = basePageView;
        }
    }
}
