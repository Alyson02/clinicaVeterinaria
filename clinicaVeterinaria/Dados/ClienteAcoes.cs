using clinicaVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace clinicaVeterinaria.Dados
{
    public class ClienteAcoes
    {
        Conexao con = new Conexao();
        public void inserirCliente(ClienteModel cliente) //Método para inserir tipo do usuário
        {
            MySqlCommand cmd = new MySqlCommand("insert into cliente values (default, @nome, @email, @telefone)", con.MyConectarBD());
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = cliente.Nome;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = cliente.Email;
            cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = cliente.Telefone;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public DataTable ConsultaCliente()//Método de consulta do tipo de usuário
        {
            MySqlCommand cmd = new MySqlCommand("select * from cliente", con.MyDesconectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable tipo = new DataTable();
            da.Fill(tipo);
            con.MyDesconectarBD();
            return tipo;
        }
    }
}