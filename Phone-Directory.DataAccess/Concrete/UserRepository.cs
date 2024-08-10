using Phone_Directory.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Dapper;
using Phone_Directory.Entities.Models;

namespace Phone_Directory.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Users WHERE Username = @Username";
                return await connection.QueryFirstOrDefaultAsync<User>(query, new { Username = username });
            }
        }

        public async Task CreateUserAsync(User user)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "INSERT INTO Users (Username, PasswordHash, PasswordSalt, FirstName, LastName, CreatedAt) VALUES (@Username, @PasswordHash, @PasswordSalt, @FirstName, @LastName, @CreatedAt) RETURNING Id";
                user.Id = await connection.ExecuteScalarAsync<int>(query, user);
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "UPDATE Users SET Username = @username, " +
                    "Firstname = @firstname, Lastname = @lastname " +
                    "WHERE Id = @Id";
                await connection.ExecuteAsync(query, user);
            }
        }

        public async Task<User> GetUserAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Users WHERE Id = @Id";
                var user = await connection.QuerySingleOrDefaultAsync<User>(query, new {Id = id});
                return user;
            }
        }
    }
}
