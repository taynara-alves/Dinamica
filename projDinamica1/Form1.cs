using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace projDinamica1
{
    public partial class Form1 : Form
    {

        private Poltrona[, ,] lugar;
        private Button[,] botoes;
        private Button ultimoClicado;

        public Form1()
        {
            InitializeComponent();
            lugar = new Poltrona[31, 25, 4];
            botoes = new Button[25, 4];
           
            for (int d = 0; d < 31; ++d)
                for (int f = 0; f < 25; ++f)
                    for (int p = 0; p < 4; p++)
                        lugar[d, f, p] = new Poltrona();

            for (int dia = 1; dia <= 31; ++dia)
                comboBox1.Items.Add(dia.ToString());
        }

        private void clicouNoBotao(object sender, EventArgs e)
        {
            Button botaoClicado = (Button)sender;
            botaoClicado.Text = "X";
            if (ultimoClicado != null)
                ultimoClicado.Text = "L";
            ultimoClicado = botaoClicado;
        }

        private void criarBotoes()
        {
            
            for (int i = 0; i < 25; i++)
                for (int j = 0; j < 4; j++)
                {
                    botoes[i, j] = new Button();
                    botoes[i, j].Parent = groupBox1;
                    botoes[i, j].Top = (j * 25) + 10;
                    botoes[i, j].Left = (i * 25) + 10;
                    botoes[i, j].Width = 25;
                    botoes[i, j].Height = 25;
                    botoes[i, j].Click += new EventHandler(clicouNoBotao);
                }
        }

        private void ativarBotoes(int dia)
        {
            for (int fileira = 0; fileira < 25; fileira++)
                for (int poltrona = 0; poltrona < 4; poltrona++)
                    if (lugar[dia, fileira, poltrona].Ocupada)
                    {
                        botoes[fileira, poltrona].Text = "R";
                        botoes[fileira, poltrona].Enabled = false;
                    }
                    else
                        botoes[fileira, poltrona].Text = "L";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            criarBotoes();
            ativarBotoes(int.Parse(comboBox1.SelectedItem.ToString()) - 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            efetuarReserva(int.Parse(comboBox1.SelectedItem.ToString()) - 1);
        }

        public void efetuarReserva(int dia)
        {
            for (int f = 0; f < 25; f++)
                for (int p = 0; p < 4; p++)
                    if (botoes[f, p].Text == "X")
                        lugar[dia, f, p].Ocupada = true;
            ativarBotoes(int.Parse(comboBox1.SelectedItem.ToString()) - 1);
        }
        
    }
}
