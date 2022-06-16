using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHostel.SharedClient.Components
{
    public class TabRequestArgs
    {
        internal Action ActivateNext { get; set; }
        internal Action ActivatePrevious { get; set; }

        public void ActiveNext() => ActivateNext.Invoke();
        public void ActivePrevious() => ActivatePrevious.Invoke();

    }
}
