using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DES
{
    public partial class mainInterfaceDes : Form
    {
        public mainInterfaceDes()
        {
            InitializeComponent();
        }

        private void mainInterfaceDes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {                
                e.Cancel = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                Submit.Enabled = false;
            }
            else
            {
                Submit.Enabled = true;
            }
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            int parsedValue;

            if (!int.TryParse(textBox3.Text, out parsedValue))
            {
                MessageBox.Show("the key must be a number");
            }
            else
            {
               
            }
        }

        private void GeneraChiavi(object sender, EventArgs e)
        {
            string chiave = "";
            string appoggio = "";
            int[] PC1 = {57,49,41,33,25,17,09, 01,58,50,42,34,26,18, 10,02,59,51,43,35,27, 19,11,03,60,52,44,36, 63,55,47,39,31,23,15, 07,62,54,46,38,30,22, 14,06,61,53,45,37,29, 21,13,05,28,20,12,04};
            string sc1="", sc2 = "";

            foreach (char c in "ciaociao")
            {
                appoggio += (Convert.ToString(c, 2).PadLeft(8, '0'));
            }

            for(int i=1;i<=64;i++)
            {
                if(i%8!=0)
                {
                    chiave += appoggio[i];
                }
            }

            for(int i=0;i<28;i++)              
                sc1 += chiave[PC1[i]];
            for (int i = 28; i < 56; i++)
                sc2 += chiave[PC1[i]];

            for(int i=0;i<16;i++)
            {

            }

        }
    }
}
