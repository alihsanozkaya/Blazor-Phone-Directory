using Dapper;
using Npgsql;
using Phone_Directory.DataAccess.Abstract;
using Phone_Directory.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Directory.DataAccess.Concrete
{
    public class DirectoryRepository : IDirectoryRepository
    {
        private readonly string _connectionString;
        public DirectoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddDirectoryAsync(Entities.Models.Directory directory)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Directory (Firstname, LastName, Phonenumber, Address, UserId, CreatedAt)
                    VALUES (@Firstname, @LastName, @Phonenumber, @Address, @UserId, @CreatedAt)";
                await connection.ExecuteAsync(query, directory);
            }
        }

        public async Task DeleteDirectoryAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string query = "DELETE FROM Directory WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<Entities.Models.Directory>> GetDirectoriesByUserIdAsync(int userId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Directory WHERE UserId = @UserId ORDER BY LOWER(FirstName), LOWER(LastName)";
                var directories = await connection.QueryAsync<Entities.Models.Directory>(query, new { UserId = userId });
                return directories;
            }
        }

        public async Task<Entities.Models.Directory> GetDirectoryByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Directory WHERE Id = @Id";
                var directory = await connection.QuerySingleOrDefaultAsync<Entities.Models.Directory>(query, new { Id = id });
                return directory;
            }
        }

        public async Task UpdateDirectoryAsync(Entities.Models.Directory directory)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string query = "UPDATE Directory SET Firstname = @firstname, " +
                    "Lastname = @lastname, Phonenumber = @phonenumber, " +
                    "Address = @address WHERE Id = @Id";
                await connection.ExecuteAsync(query, directory);
            }
        }

    }
}
