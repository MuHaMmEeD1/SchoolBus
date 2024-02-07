using SchoolBusWpfProje.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusWpfProje.ViewModels
{
    public class CarViewModel
    {
        public BasePageView basePageView { get; set; }

        public CarViewModel(BasePageView basePageView)
        {
            this.basePageView = basePageView;
        }
    }
}
