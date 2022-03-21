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
        int idActual = 1;//guarda el id del pokemon

        public VentanaPrincipal()
        {
            InitializeComponent();
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.BackColor = Color.Transparent;

                
            label2.Hide();
        }
        private Image convierteBlobAImagen(byte[] img) {
            MemoryStream ms = new System.IO.MemoryStream(img);
            return (Image.FromStream(ms));
        }
        private void Izquierda_Click(object sender, EventArgs e)
        {
            idActual--;

            if (idActual>0) {
                
                misPokemons = miConexion.getPokemonPorId(idActual);
                nombrePokemons.Text = misPokemons.Rows[0]["nombre"].ToString();
                pictureBox1.Image = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
            }
        }

        private void Derecha_Click(object sender, EventArgs e)
        {
            idActual++;
            if (idActual < 152)
                
            {
                
                misPokemons = miConexion.getPokemonPorId(idActual);
                nombrePokemons.Text = misPokemons.Rows[0]["nombre"].ToString();
                Altura.Text = misPokemons.Rows[0]["altura"].ToString();
                Peso.Text = misPokemons.Rows[0]["peso"].ToString();
                Especie.Text="Especie ->"+ misPokemons.Rows[0]["especie"].ToString();
                Especie.Text = "Especie ->" + misPokemons.Rows[0]["especie"].ToString();
                Habitat.Text = "Habitat ->" + misPokemons.Rows[0]["habitat"].ToString();

                pictureBox1.Image = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
            }
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
            label2.Text = misPokemons.Rows[0]["descripcion"].ToString() + "\r\n Movimiento 1: " + misPokemons.Rows[0]["Movimiento1"].ToString()+"\r\n Movimiento 2: " +misPokemons.Rows[0]["movimiento2"].ToString()+"\r\n Movimiento 3: "  + misPokemons.Rows[0]["movimiento3"].ToString() + "\r\n Movimiento 4: " + misPokemons.Rows[0]["movimiento4"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Hide();
        }
    }
}
