using System.Collections.Generic;
using ApiMySql.Model;
using MySql.Data.MySqlClient;
using Dapper;

namespace ApiMySql.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly string _connectionString;

        public PessoaRepository(string connectionString)
        {
            _connectionString = connectionString;   // Injetando a string de conexão no construtor da classe
        }

        public IEnumerable<Pessoa> GetAll()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Pessoa>("SELECT Codigo, Nome, Endereco FROM Pessoa ORDER BY Nome ASC");
            }
        }
    }
}