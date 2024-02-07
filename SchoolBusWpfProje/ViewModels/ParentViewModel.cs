using SchoolBusWpfProje.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusWpfProje.ViewModels
{
    public class ParentViewModel
    {
        public BasePageView basePageView { get; set; }

        public ParentViewModel(BasePageView basePageView)
        {
            this.basePageView = basePageView;
        }
    }
}
