using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PISCINA_ENTIDADES;
using PISCINA_NEGOCIO;
using PISCINA_PRESENTACION.Utilidades;
using PISCINA_PRESENTACION;
using System.Windows.Forms;

namespace PISCINA_PRESENTACION
{
    public partial class frmUsuarioModal : Form
    {
        public frmUsuarioModal()
        {
            InitializeComponent();
        }

        private void frmUsuarioModal_Load(object sender, EventArgs e)
        {
            //Cargar lista de Estados
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "ACTIVO" });
            cmbEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "INACTIVO" });
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
            cmbEstado.SelectedIndex = 0;


            //Cargar lista de roles
            List<EROLES> listaRol = new NROLES().Listar();
            foreach (EROLES item in listaRol)
            {
                cmbRol.Items.Add(new OpcionCombo() { Valor = item.IdTRol, Texto = item.Descripcion });
            }
            cmbRol.DisplayMember = "Texto";
            cmbRol.ValueMember = "Valor";
            cmbRol.SelectedIndex = 0;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;



        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Cancel;
        }
    }
}
