using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PISCINA_DATOS;
using PISCINA_ENTIDADES;
using System.Security.Claims;
using System.Reflection;

namespace PISCINA_DATOS
{
    public class DUSUARIOS
    {
        public List<EUSUARIOS> Listar()
        {
            List<EUSUARIOS> lusuarios= new List<EUSUARIOS>();
            using(SqlConnection oConexion = new SqlConnection(DCONEXION.cadena))
            {
                try {
                    
 

                    StringBuilder consultaUsuario = new StringBuilder();
                    consultaUsuario.AppendLine("select u.IdTUsuario,u.Usuario,u.NombreCompleto,u.Correo,u.Clave,u.Estado,r.IdTRol,r.Descripcion from usuarios u");
                    consultaUsuario.AppendLine("inner join roles r on r.IdTRol = u.IdTRol");


                    SqlCommand cmd = new SqlCommand(consultaUsuario.ToString(),oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader()) { 
                        
                        while(dr.Read()) {
                            lusuarios.Add(new EUSUARIOS()
                            {
                                IdTUsuario = Convert.ToInt32(dr["IdTUsuario"]),
                                Usuario = dr["Usuario"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oRol = new EROLES() { IdTRol = Convert.ToInt32(dr["IdTRol"]), Descripcion = dr["Descripcion"].ToString() }
                            });
                        }
                    }
                
                }
                catch(Exception ex) { 
                    lusuarios = new List<EUSUARIOS>();
                } 
            }
            
            return lusuarios;
        }
    }
}
