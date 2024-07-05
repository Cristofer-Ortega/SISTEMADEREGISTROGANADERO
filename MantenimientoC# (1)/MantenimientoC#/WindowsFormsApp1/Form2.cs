using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private Form activateForm = null;
        private void openForm(Form form)
        {
            if (activateForm != null)
                activateForm.Close();
            activateForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel_Contenedor.Controls.Add(form);
            panel_Contenedor.Tag = form;
            form.BringToFront();
            form.Show();
        }

        private void button_Registrar_Click(object sender, EventArgs e)
        {
            openForm(new Form1());
        }
    }
}
