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
            string[] chiavi = new string[16];
            InitializeComponent();
            GeneraChiavi("ciaociao",chiavi);
        }

        //conferma di voler uscire dal programma
        private void mainInterfaceDes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)             
                e.Cancel = true;
        }

        //disabilita il pulsante di invio se il testo di ingresso è vuoto
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "") Submit.Enabled = false;
            else Submit.Enabled = true;
        }

        //evento CLICK del pulsante di invio
        private void Submit_Click(object sender, EventArgs e)
        {

        }

        //INPUT: chiave a 64 bit generata casualmente
        //OUTPUT: array di 16 stringhe da 48 caratteri
        private void GeneraChiavi(string ChiavePrimaria,string[] chiavi) 
        {
            string chiave = "";
            int[] PC1 = {57,49,41,33,25,17,09, 01,58,50,42,34,26,18, 10,02,59,51,43,35,27, 19,11,03,60,52,44,36, 63,55,47,39,31,23,15, 07,62,54,46,38,30,22, 14,06,61,53,45,37,29, 21,13,05,28,20,12,04};
            int[] PC2 = {14,17,11,24,01,05, 03,28,15,06,21,10, 23,19,12,04,26,08, 16,07,27,20,13,02, 41,52,31,37,47,55, 30,40,51,45,33,48 ,44,49,39,56,34,53, 46,42,50,36,29,32 };
            string sc1 = "", sc2 = "", sc = "";


            foreach (char c in ChiavePrimaria)
                chiave += (Convert.ToString(c, 2).PadLeft(8, '0'));

            for(int i=0;i<28;i++)              
                sc1 += chiave[PC1[i]-1];
            for (int i = 28; i < 56; i++)
                sc2 += chiave[PC1[i]-1];

            for(int i=1;i<=16;i++)
            {
                if ((i == 1) || (i == 2) || (i == 9) || (i == 16))
                {
                    sc1 = sc1.Substring(1, sc1.Length - 1) + sc1.Substring(0, 1);
                    sc2 = sc2.Substring(1, sc2.Length - 1) + sc2.Substring(0, 1);
                }
                else
                {
                    sc1 = sc1.Substring(2, sc1.Length - 2) + sc1.Substring(0, 2);
                    sc2 = sc2.Substring(2, sc2.Length - 2) + sc2.Substring(0, 2);
                }
                sc = sc1 + sc2;
                for (int ii = 0; ii < 48; ii++)
                    chiavi[i - 1] += sc[PC2[ii]-1];
                textBox1.Text += chiavi[i - 1] + "\n";
            }

        }

       private void PermutazioneIniziale(string Ingresso,string ParteSx, string ParteDx)
        {
            int[] PI = {58,50,42,34,26,18,10,02,60,52,44,36,28,20,12,04,62,54,46,38,30,22,14,06,64,56,48,40,32,24,16,08,57,49,41,33,25,17,09,01,59,51,43,35,27,19,11,03,61,53,45,37,29,21,13,05,63,55,47,39,31,23,15,07};

            for (int i = 0; i < 32; i++)
                ParteSx += Ingresso[PI[i] - 1];
            for (int i = 0; i < 32; i++)
                ParteDx += Ingresso[PI[i] - 1];
        }

        private void FunzioneE(string ParteDx,string ParteDx48)
        {
            int[] BloccoE = {32,1,2,3,4,5,4,5,6,7,8,9,8,9,10,11,12,13,12,13,14,15,16,17,16,17,18,19,20,21,20,21,22,23,24,25,24,25,26,27,28,29,28,29,30,31,32,1};

            for (int i = 0; i < 48; i++)
                ParteDx48 += ParteDx[BloccoE[i] - 1];
        }
    }
}
