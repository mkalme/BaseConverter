using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseConverter;

namespace BaseConverterGUI {
    public partial class Window : Form {
        public Converter Converter { get; set; } = new Converter("");

        public Window()
        {
            InitializeComponent();

            Converter.Base = "0123456789ABCDEF";

            Console.WriteLine(Converter.Convert("Hello World!") + " | tst");
        }
    }
}
