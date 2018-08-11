using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C_empleado;

namespace Programa_empleados
{
    public partial class Form1 : Form
    {
        public ArregloE obj_empleados;
        int numempleado = 0;
        string foto = "";    
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            obj_empleados = new ArregloE(Convert.ToInt32(nudArreglo.Value));
            MessageBox.Show("Tamaño Definido");
            obj_empleados.p_empleado[numempleado] = new Persona();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (obj_empleados.p_pos > 1)
                {
                    string sexo = "";
                    if (rbMasculino.Checked == true)
                        sexo = "Masculino";
                    else
                        sexo = "Femenino";

                    try
                    {
                        obj_empleados.llenar(txtNombre.Text, sexo, foto, cmbPuesto.Text, Convert.ToInt32(nudEdad.Value), DateTime.Parse(dtpFechaIngreso.Text), numempleado);
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Algo se te olvido");
                    }

                    cmbNombre.Items.Add(txtNombre.Text);
                    lblSueldob.Text = "$ " + obj_empleados.sueldo_base(numempleado);
                    lblAnioS.Text = obj_empleados.año_sabatic(numempleado) + " años";
                    lblTPrestamo.Text = obj_empleados.tipo_prestamos(numempleado);
                    lblMPrestamo.Text = "$ " + obj_empleados.monto_prestamos(numempleado);

                    lstNombre.Items.Add(obj_empleados.p_empleado[numempleado].nombre);
                    lstSexo.Items.Add(sexo);
                    lstPuesto.Items.Add(obj_empleados.p_empleado[numempleado].puesto);
                    lstSueldo.Items.Add(obj_empleados.sueldo_base(numempleado));
                    lstFecha.Items.Add(obj_empleados.p_empleado[numempleado].fechaIngreso);

                }
            }

            catch(Exception)
            {
                MessageBox.Show("Verifique sus datos");
            }
 
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            Image a;
            Agregar_Foto.Title = "Abrir Archivo.....";
            Agregar_Foto.Filter = "imagenes jpg(*.jpg)|*.jpg|imagenes pmg(*.png)|*.png";
            if (Agregar_Foto.ShowDialog() == DialogResult.OK)
            {
                a = Image.FromFile(Agregar_Foto.FileName);
                pbFoto.Image = a;
                foto = Agregar_Foto.FileName;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            cmbPuesto.Text = "";
            rbFemenino.Checked = false;
            rbMasculino.Checked = false;
            nudEdad.Value = 0;
            pbFoto.Image = null;
            dtpFechaIngreso.Value = DateTime.Now;
            lblAnioS.Text = "________";
            lblMPrestamo.Text = "_________";
            lblSueldob.Text = "__________";
            lblTPrestamo.Text = "__________";
        }

        private void cmbLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void cmbNombre_SelectedIndexChanged(object sender, EventArgs e)
        {            
            string sexo = "";
            if (rbMasculino.Checked == true)
                sexo = rbMasculino.Text;
            else
                sexo = rbMasculino.Text;

            DateTime fechai = dtpFechaIngreso.Value.Date;
            Persona obj_persona = new Persona();
            obj_persona = obj_empleados.buscar(cmbNombre.Text, numempleado);
            ListViewItem item;
            lvResultado.Items.Clear();            
            item = lvResultado.Items.Add(cmbNombre.Text);   
            item.SubItems.Add(nudEdad.Value.ToString());            
            item.SubItems.Add(sexo);
            item.SubItems.Add(cmbPuesto.Text);
            item.SubItems.Add(lblSueldob.Text);
            item.SubItems.Add(fechai.ToLongDateString());           
        }
    }
}
