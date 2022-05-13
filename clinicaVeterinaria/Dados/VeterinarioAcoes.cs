using clinicaVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace clinicaVeterinaria.Dados
{
    public class VeterinarioAcoes
    {
        Conexao con = new Conexao();
        public void inserirVeterinario(VeterinarioModel veterinario) //Método para inserir tipo do usuário
        {
            MySqlCommand cmd = new MySqlCommand("insert into veterinario values (default, @nome)", con.MyConectarBD());
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = veterinario.Nome;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public DataTable ConsultaVeterinario()//Método de consulta do tipo de usuário
        {
            MySqlCommand cmd = new MySqlCommand("select * from veterinario", con.MyDesconectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable tipo = new DataTable();
            da.Fill(tipo);
            con.MyDesconectarBD();
            return tipo;
        }
    }
}