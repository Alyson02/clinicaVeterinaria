using clinicaVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace clinicaVeterinaria.Dados
{
    public class AtendimentoAcoes
    {
        Conexao con = new Conexao();

        public void TestarAtendimento(AtendimentoModel atendimento) //verificar se a atendimento está reservada
        {
            MySqlCommand cmd = new MySqlCommand("select * from atendimento where data = @data and hora = @hora", con.MyConectarBD());

            cmd.Parameters.Add("@data", MySqlDbType.VarChar).Value = atendimento.Data;
            cmd.Parameters.Add("@hora", MySqlDbType.VarChar).Value = atendimento.Hora;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    atendimento.confAtendimento = "0";
                }

            }

            else
            {
                atendimento.confAtendimento = "1";
            }

            con.MyDesconectarBD();
        }

        public void inserirAtendimento(AtendimentoModel atendimento) //Método para inserir tipo do usuário
        {
            MySqlCommand cmd = new MySqlCommand("insert into atendimento values (default, @data, @hora, @idAnimal, @idVeterinario)", con.MyConectarBD());
            cmd.Parameters.Add("@data", MySqlDbType.VarChar).Value = atendimento.Data;
            cmd.Parameters.Add("@hora", MySqlDbType.VarChar).Value = atendimento.Hora;
            cmd.Parameters.Add("@idAnimal", MySqlDbType.VarChar).Value = atendimento.IdAnimal;
            cmd.Parameters.Add("@idVeterinario", MySqlDbType.VarChar).Value = atendimento.IdVeterinario;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public DataTable ConsultaAtendimento()//Método de consulta do tipo de usuário
        {
            MySqlCommand cmd = new MySqlCommand("select * from atendimento", con.MyDesconectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable tipo = new DataTable();
            da.Fill(tipo);
            con.MyDesconectarBD();
            return tipo;
        }
    }
}