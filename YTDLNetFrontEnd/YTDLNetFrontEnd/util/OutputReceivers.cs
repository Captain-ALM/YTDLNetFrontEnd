using System;
using System.Windows.Forms;
namespace com.captainalm.YTDLNetFrontEnd.util
{
    public class OutputReceiverReader : IProcessOuputReceiver
    {
        private string theOutput = "";

        public void receiveData(string dataIn)
        {
            theOutput += dataIn;
        }

        public string getData()
        {
            return theOutput.TrimEnd(Environment.NewLine.ToCharArray());
        }
    }

    public class OutputReceiverTextbox : IProcessOuputReceiver
    {
        protected TextBox theOutputTextbox;

        public OutputReceiverTextbox(TextBox tboxIn)
        {
            theOutputTextbox = tboxIn;
        }

        public virtual void receiveData(string dataIn)
        {
            if (theOutputTextbox.InvokeRequired)
            {
                theOutputTextbox.Invoke(new Action(() =>
                {
                    theOutputTextbox.AppendText(dataIn + Environment.NewLine);
                }));
            }
        }
    }

    public class OutputReaderPrefixed : OutputReceiverTextbox
    {
        protected string prefix;

        public OutputReaderPrefixed(TextBox tboxIn, string prefix)
            : base(tboxIn)
        {
            this.prefix = prefix;
        }

        public override void receiveData(string dataIn)
        {
            base.receiveData(prefix + dataIn);
        }
    }
}