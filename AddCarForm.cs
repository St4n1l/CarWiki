using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarWiki;

namespace CarWiki
{
    public partial class AddCarForm : Form
    {
        public AddCarForm()
        {
            InitializeComponent();
        }

        public string ImagePath()
        {
            return imageTextBox.Text;
        }

        public string Make()
        {
            return makeTextBox.Text;
        }

        public string Model()
        {
            return modelTextBox.Text;
        }

        public int Year()
        {
            try
            {
                int.Parse(yearTextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Year must be a number");
                return 0;
            }

            return int.Parse(yearTextBox.Text);
        }

        public int HorsePower()
        {
            try
            {
                int.Parse(horsePowerTextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Horse Power must be a number");
                return 0;
            }

            return int.Parse(horsePowerTextBox.Text);
        }
    }
}
