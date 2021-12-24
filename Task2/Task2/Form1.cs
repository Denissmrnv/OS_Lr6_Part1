using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace Task2
{
    public partial class Task2 : Form
    {
        public const int WM_COPYDATA = 0x4A;
        public struct COPYDATASTRUCT
        {
            public int cbData;
            public IntPtr dwData;
            [MarshalAs(UnmanagedType.LPStr)] public string lpData;
        }

        public Task2()
        {
            InitializeComponent();

        }
        protected override void WndProc(ref Message message)
        {
            if (message.Msg == WM_COPYDATA)
            {
                COPYDATASTRUCT mystr = new COPYDATASTRUCT();
                Type mytype = mystr.GetType();
                mystr = (COPYDATASTRUCT)message.GetLParam(mytype);
                label1.Text = mystr.lpData;
            }
            base.WndProc(ref message);
        }
    }
}
