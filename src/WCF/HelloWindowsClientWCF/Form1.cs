﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWindowsClientWCF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HelloService.HelloServiceWCFClient client = 
                new HelloService.HelloServiceWCFClient("NetTcpBinding_IHelloServiceWCF");
            label1.Text = client.GetMessage(textBox1.Text);
        }
    }
}
