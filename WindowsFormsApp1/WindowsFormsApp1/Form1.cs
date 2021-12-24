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



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public const int WM_COPYDATA = 0x4A;

        public struct COPYDATASTRUCT
        {
            public int cbData;
            public IntPtr dwData;
            [MarshalAs(UnmanagedType.LPStr)] public string lpData;
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, ref COPYDATASTRUCT lParam);

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr taskHandle = FindWindow(null, "Task2");
            SetForegroundWindow(taskHandle);
            string m = textBox1.Text;
           
            var cds = new COPYDATASTRUCT
            {
                dwData = new IntPtr(m.Length),
                cbData = m.Length + 1,
                lpData = m
            };
            SendMessage(taskHandle, WM_COPYDATA, IntPtr.Zero, ref cds);
        }
    }
}
