using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokedez2022_CSharp
{
    public partial class VentanaPrincipal : Form
    {
        Conexión miConexion = new Conexión();
        DataTable misPokemons = new DataTable();
        DataTable misPokemons2 = new DataTable();
        DataTable misPokemons3= new DataTable();
        DataTable misPokemons4= new DataTable();
        DataTable misPokemons5= new DataTable();

        int idActual = 1;//guarda el id del pokemon
        int idAnterior = 150;
            int idSiguiente = 1;

        public VentanaPrincipal()
        {
            InitializeComponent();
            idActual--;
            pictureBox1.Hide();
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.BackColor = Color.Transparent;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.BackColor = Color.Transparent;
            button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button4.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button4.BackColor = Color.Transparent;


            label2.Hide();
        }
        private Image convierteBlobAImagen(byte[] img) {
            MemoryStream ms = new System.IO.MemoryStream(img);
            return (Image.FromStream(ms));
        }
        private void Izquierda_Click(object sender, EventArgs e)
        {
            idActual--;
            idAnterior--;
            idSiguiente--;
            if (idSiguiente <= 0)
            {
                idSiguiente = 151;
            }
            if (idAnterior <= 0)
            {
                idAnterior = 151;
            }
            

            if (idActual <= 0)
            {
                idActual = 151;
            }
                
                misPokemons = miConexion.getPokemonPorId(idActual);
                misPokemons2 = miConexion.preEvoulicion(idActual);
                misPokemons3 = miConexion.posEvoulicion(idActual);
                misPokemons4 = miConexion.preEvoulicion(idAnterior);
                misPokemons5 = miConexion.posEvoulicion(idSiguiente);
                nombrePokemons.Text = misPokemons.Rows[0]["nombre"].ToString();
                pictureBox1.Image = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
            
        }

        private void Derecha_Click(object sender, EventArgs e)
        {
            idActual++;
            idAnterior++;
            idSiguiente++;

            if (idAnterior > 151) {
                idAnterior = 1;
            }
            if (idSiguiente > 151) {
                idSiguiente = 1; }
            if (idActual >151)
            {
                idActual = 1;
            }

            misPokemons = miConexion.getPokemonPorId(idActual);
                misPokemons = miConexion.getPokemonPorId(idActual);
                misPokemons2 = miConexion.preEvoulicion(idActual);
                misPokemons3 = miConexion.posEvoulicion(idActual);
                misPokemons4 = miConexion.preEvoulicion(idAnterior);
                misPokemons5 = miConexion.posEvoulicion(idSiguiente);
                nombrePokemons.Text = misPokemons.Rows[0]["nombre"].ToString();
                Altura.Text = misPokemons.Rows[0]["altura"].ToString();
                Peso.Text = misPokemons.Rows[0]["peso"].ToString();
                Especie.Text="Especie ->"+ misPokemons.Rows[0]["especie"].ToString();
                Especie.Text = "Especie ->" + misPokemons.Rows[0]["especie"].ToString();
                Habitat.Text = "Habitat ->" + misPokemons.Rows[0]["habitat"].ToString();

                pictureBox1.Image = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
            
        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label2.Show();
            misPokemons = miConexion.getPokemonPorId(idActual);
            label2.Text = misPokemons.Rows[0]["descripcion"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
            ventanaEvolusiones ventana = new ventanaEvolusiones();
            ventana.Show();
            ventana.imagenEvolucion(convierteBlobAImagen((Byte[])misPokemons.Rows[0]["imagen"]));
            if (misPokemons.Rows[0]["posEvolucion"].ToString() != "")
            {
                ventana.imagenEvolucion3(convierteBlobAImagen((Byte[])misPokemons3.Rows[0]["imagen"]));
            }
            else if (misPokemons.Rows[0]["preEvolucion"].ToString() != "" && misPokemons2.Rows[0]["preEvolucion"].ToString() != "")
            {
                ventana.imagenEvolucion3(convierteBlobAImagen((Byte[])misPokemons4.Rows[0]["imagen"]));
            }


            if (misPokemons.Rows[0]["preEvolucion"].ToString() != "")
            {
                ventana.imagenEvolucion2(convierteBlobAImagen((Byte[])misPokemons2.Rows[0]["imagen"]));
            }
            else if (misPokemons.Rows[0]["posEvolucion"].ToString() != "" && misPokemons3.Rows[0]["posEvolucion"].ToString() != "")
            {
                ventana.imagenEvolucion2(convierteBlobAImagen((Byte[])misPokemons5.Rows[0]["imagen"]));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = " Movimiento 1: " +misPokemons.Rows[0]["Movimiento1"].ToString() + "\r\n Movimiento 2: " + misPokemons.Rows[0]["movimiento2"].ToString() + "\r\n Movimiento 3: " + misPokemons.Rows[0]["movimiento3"].ToString() + "\r\n Movimiento 4: " + misPokemons.Rows[0]["movimiento4"].ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = misPokemons.Rows[0]["descripcion"].ToString();
        }
    }
}
