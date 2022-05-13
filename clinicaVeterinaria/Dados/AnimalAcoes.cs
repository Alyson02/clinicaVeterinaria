using clinicaVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace clinicaVeterinaria.Dados
{
    public class AnimalAcoes
    {
        Conexao con = new Conexao();
        public void inserirAnimal(AnimalModel animal) //Método para inserir tipo do usuário
        {
            MySqlCommand cmd = new MySqlCommand("insert into animal values (default, @nome, @idTipo, @idCliente)", con.MyConectarBD());
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = animal.Nome;
            cmd.Parameters.Add("@idCliente", MySqlDbType.VarChar).Value = animal.IdCliente;
            cmd.Parameters.Add("@idTipo", MySqlDbType.VarChar).Value = animal.IdTipo;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public DataTable ConsultaAnimal()//Método de consulta do tipo de usuário
        {
            MySqlCommand cmd = new MySqlCommand("select * from animal", con.MyDesconectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable tipo = new DataTable();
            da.Fill(tipo);
            con.MyDesconectarBD();
            return tipo;
        }
    }
}