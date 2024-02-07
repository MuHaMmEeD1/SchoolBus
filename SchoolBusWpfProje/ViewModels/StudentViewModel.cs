using SchoolBusWpfProje.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusWpfProje.ViewModels
{
    public class StudentViewModel
    {
        public BasePageView basePageView { get; set; }

        public StudentViewModel(BasePageView basePageView)
        {
            this.basePageView = basePageView;
        }
    }
}
