using System;
using System.Collections.Generic;
using System.Text;

namespace Example6
{
    public delegate void ChangeTextDelegate(String msg);
    class DelegateTest
    {
        public ChangeTextDelegate changeTextDelegate;

        public DelegateTest(ChangeTextDelegate changeTextDelegate)
        {
            this.changeTextDelegate = changeTextDelegate;
        }

        public void ChangeTextD(String msg)
        {
            changeTextDelegate.Invoke(msg);
        }
    }

}
