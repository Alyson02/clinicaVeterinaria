using clinicaVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace clinicaVeterinaria.Dados
{
    public class TipoAnimalAcoes
    {
        Conexao con = new Conexao();
        public void inserirTipoAnimal(TipoAnimalModel tipoAnimal) //Método para inserir tipo do usuário
        {
            MySqlCommand cmd = new MySqlCommand("insert into TipoAnimal values (default, @tipo)", con.MyConectarBD());
            cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = tipoAnimal.Tipo;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public DataTable ConsultaTipoAnimal()//Método de consulta do tipo de usuário
        {
            MySqlCommand cmd = new MySqlCommand("select * from TipoAnimal", con.MyDesconectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable tipo = new DataTable();
            da.Fill(tipo);
            con.MyDesconectarBD();
            return tipo;
        }
    }
}