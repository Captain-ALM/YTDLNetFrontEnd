using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.captainalm.YTDLNetFrontEnd.util
{
    public interface IProcessOuputReceiver
    {
        void receiveData(string dataIn);
    }
}
