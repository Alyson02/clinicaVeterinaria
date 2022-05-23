using clinicaVeterinaria.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace clinicaVeterinaria.Dados
{
    public class LoginAcoes
    {
        Conexao con = new Conexao();

        public void TestarUsuario(LoginModel user) //Método para verificar se usuário e senha estão corretos
        {
            MySqlCommand cmd = new MySqlCommand("select * from login where usuario = @usuario and senha = @senha", con.MyConectarBD());

            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = user.Usuario;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = user.Senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.Usuario = Convert.ToString(leitor["Usuario"]);
                    user.Senha = Convert.ToString(leitor["Senha"]);
                    user.IdTipoUsuario = Convert.ToInt32(leitor["IdTipoUsuario"]);
                }
            }
            else
            {
                user.Usuario = null;
                user.Senha = null;
                user.IdTipoUsuario = 0;
            }

            con.MyDesconectarBD();
        }

        public void inserirLogin(LoginModel login)//Método para cadastrar o Login
        {
            MySqlCommand cmd = new MySqlCommand("insert into login values (@usuario, @senha, @tipoUsu)", con.MyConectarBD());
            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = login.Usuario;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = login.Senha;
            cmd.Parameters.Add("@tipoUsu", MySqlDbType.VarChar).Value = login.IdTipoUsuario;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

        public DataTable ConsultaUsuarios()//Método de consulta do tipo de usuário
        {
            MySqlCommand cmd = new MySqlCommand("select * from login", con.MyDesconectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.MyDesconectarBD();
            return dt;
        }
    }
}