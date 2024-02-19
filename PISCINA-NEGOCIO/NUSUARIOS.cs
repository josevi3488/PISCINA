using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PISCINA_DATOS;
using PISCINA_ENTIDADES;

namespace PISCINA_NEGOCIO
{
    public class NUSUARIOS
    {
        private DUSUARIOS objUsuarios = new DUSUARIOS();

        public List<EUSUARIOS> Listar()
        {
            return objUsuarios.Listar();
        }
    }
}
