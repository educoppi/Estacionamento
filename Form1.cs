using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estacionamento
{
    public partial class Form1 : Form
    {

        List<string> veiculos = new List<string>();

        void atualizaLista()
        {
            listVeiculos.Items.Clear();
            txtPlaca.Clear();

            if (veiculos.Any() == false)
            {
                lblContagemVeículos.Text = "0";
                return;
            }

            for (int i = 0; i < veiculos.Count; i++)
            {
                string placa = $"[VAGA {i+1}] ";
                placa += veiculos[i].ToString();

                listVeiculos.Items.Add(placa);
                lblContagemVeículos.Text = veiculos.Count.ToString();
            }
        }

        bool txtEstaVazio()
        {
            if (txtPlaca.Text == "")
            {
                MessageBox.Show("Insira uma placa");
                return true;
            }
            else
            {
                return false;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnEstacionar_Click(object sender, EventArgs e)
        {
            if (txtEstaVazio() == true)
            {
                return;
            }

            if (veiculos.Count == 5)
            {
                MessageBox.Show("Não há mais vagas disponíveis!");
                txtPlaca.Clear();

                return;
            }

            veiculos.Add(txtPlaca.Text);

            atualizaLista();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            if (txtEstaVazio() == true)
            {
                return;
            }

            veiculos.Remove(txtPlaca.Text);

            atualizaLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (veiculos.Count != 0)
            {
                MessageBox.Show("Não é possível fechar o estacionamento com veículos estacionados");
                return;
            }

            MessageBox.Show("Estacionamento fechado");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

