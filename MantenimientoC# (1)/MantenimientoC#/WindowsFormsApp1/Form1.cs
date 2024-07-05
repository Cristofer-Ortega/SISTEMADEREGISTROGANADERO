using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa_Entidad;
using Capa_Negocio;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();
        public Form1()
        {
            InitializeComponent();
        }
        public void exportaraexcel(DataGridView tabla)
        {

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int IndiceColumna = 0;

            foreach (DataGridViewColumn col in tabla.Columns)
            {

                IndiceColumna++;

                excel.Cells[1, IndiceColumna] = col.Name;

            }

            int IndeceFila = 0;

            foreach (DataGridViewRow row in tabla.Rows)
            {

                IndeceFila++;

                IndiceColumna = 0;

                foreach (DataGridViewColumn col in tabla.Columns)
                {

                    IndiceColumna++;

                    excel.Cells[IndeceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;

                }

            }

            excel.Visible = true;


        }


        void mantenimiento(String accion) 
        {
            objent.codigo = txtcodigo.Text;
            objent.medida = txtmedida.Text;
            objent.cantidad = Convert.ToInt32(txtcantidad.Text);
            objent.precio = Convert.ToInt32(txtprecio.Text);
            objent.accion = accion;
            String men = objneg.N_mantenimiento_registro(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void limpiar() 
        {
            txtcodigo.Text = "";
            txtmedida.Text = "";
            txtcantidad.Text = "";
            txtprecio.Text = "";
            txtbuscar.Text = "";
            dataGridView1.DataSource = objneg.N_listar_registro();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objneg.N_listar_registro();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text == "")
            {
                if (MessageBox.Show("¿Deseas registrar a " + txtmedida.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("1");
                    limpiar();
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + txtmedida.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a " + txtmedida.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscar.Text != "")
            {
                objent.medida = txtbuscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_registro(objent);
                dataGridView1.DataSource = dt;
            }
            else 
            {
                dataGridView1.DataSource = objneg.N_listar_registro();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            txtcodigo.Text = dataGridView1[0,fila].Value.ToString();
            txtmedida.Text = dataGridView1[1, fila].Value.ToString();
            txtcantidad.Text = dataGridView1[2, fila].Value.ToString();
            txtprecio.Text = dataGridView1[3, fila].Value.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblMensaje.Visible = true;
            lblMensaje.Text = "Se esta exportando";
            exportaraexcel(dataGridView1);

        }
    }
}
