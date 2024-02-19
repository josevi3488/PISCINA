using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PISCINA_PRESENTACION;
using PISCINA_ENTIDADES;
using PISCINA_NEGOCIO;
using System.Windows.Controls;
using PISCINA_PRESENTACION.Utilidades;

namespace PISCINA_PRESENTACION
{
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {


            foreach (DataGridViewColumn dvgColumna in dgvUsuarios.Columns)
            {
                if(dvgColumna.Visible == true && dvgColumna.Name != "btnSeleccionar")
                {
                    cmbBusqueda.Items.Add(new OpcionCombo() { Valor = dvgColumna.Name, Texto = dvgColumna.HeaderText });
                }
            }
            cmbBusqueda.DisplayMember = "Texto";
            cmbBusqueda.ValueMember = "Valor";
            cmbBusqueda.SelectedIndex = 0;



            //Mostrar usuarios en el grid
            List<EUSUARIOS> listaUsuario = new NUSUARIOS().Listar();
            foreach (EUSUARIOS item in listaUsuario)
            {
                dgvUsuarios.Rows.Add(new Object[] {"",item.IdTUsuario,item.NombreCompleto,item.Usuario,item.Correo,item.Clave,
                item.oRol.IdTRol,
                item.oRol.Descripcion,
                item.Estado == true ? 1 : 0,
                item.Estado == true ? "ACTIVO" : "INACTIVO",
                });

            }


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmUsuarioModal frmUsuModal = new frmUsuarioModal();

            if(frmUsuModal.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Aceptar");
            }
        }
    }
}
