using clinicaVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace clinicaVeterinaria.Dados
{
    public class TipoUsuarioAcoes
    {
        Conexao con = new Conexao();
        public void inserirTipoUsu(TipoUsuarioModel tipoUsuario) //Método para inserir tipo do usuário
        {
            MySqlCommand cmd = new MySqlCommand("insert into TipoUsuario values (default, @usuario)", con.MyConectarBD());
            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = tipoUsuario.Usuario;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public DataTable ConsultaTipo()//Método de consulta do tipo de usuário
        {
            MySqlCommand cmd = new MySqlCommand("select * from TipoUsuario", con.MyDesconectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable tipo = new DataTable();
            da.Fill(tipo);
            con.MyDesconectarBD();
            return tipo;
        }



    }
}