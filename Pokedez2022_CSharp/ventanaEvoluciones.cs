﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokedez2022_CSharp
{
    public partial class ventanaEvolusiones : Form
    {
        public ventanaEvolusiones()
        {
            InitializeComponent();
        }

        private void ventanaEvolusiones_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        internal void imagenEvolucion(Image image) {
            pictureBox1.Image = image;
        }
        internal void imagenEvolucion2(Image image)
        {
            pictureBox2.Image = image;
        }
        internal void imagenEvolucion3(Image image)
        {
            pictureBox3.Image = image;
        }
    }
}
