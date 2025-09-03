using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDA_queue
{
    public partial class Form1 : Form
    {
        private string[] cola;
        private int front;
        private int rear;
        private int count;
        public Form1()
        {
            InitializeComponent();

            int capacidad = 50; // Tamaño maximo de la cola
            cola = new string[capacidad];
            front = 0;
            rear = -1;
            count = 0;
        }
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            //este boton agrega al paciente a la cola
            ////Encolar
            string paciente = txtPaciente.Text.Trim();

            if (paciente == "")
            {
                MessageBox.Show("Escribe el nombre del paciente.");
                return;
            }

            if (count == cola.Length)
            {
                MessageBox.Show("La cola está llena.");
                return;
            }

            rear = (rear + 1) % cola.Length; // Avanzar circularmente
            cola[rear] = paciente;
            count++;

            txtPaciente.Clear();
            MostrarCola();
        }
        private void btnAtender_Click_1(object sender, EventArgs e)
        {
            //este boton atiende al paciente que esta en la cola
            //Desencolar
            if (count == 0)
            {
                MessageBox.Show("No hay pacientes en espera.");
                return;
            }

            string atendido = cola[front];
            front = (front + 1) % cola.Length; // Avanza circularmente
            count--;
            //Muestra el paciente atendido
            lblAtendido.Text = "Atendiendo a: " + atendido;
            MostrarCola();

        }
        // Mostrar la cola en el ListBox
        private void MostrarCola()
        {
            lstPacientes.Items.Clear();

            for (int i = 0; i < count; i++)
            {
                int index = (front + i) % cola.Length;
                lstPacientes.Items.Add(cola[index]);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
    
}