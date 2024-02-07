using SchoolBusWpfProje.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusWpfProje.ViewModels
{
    public class ClassViewModel
    {

        public BasePageView basePageView { get; set; }

        public ClassViewModel(BasePageView basePageView)
        {
            this.basePageView = basePageView;
        }
    }
}
