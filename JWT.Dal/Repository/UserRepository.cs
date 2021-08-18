using JWT.Dal.Interfaces;
using JWT.Dal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tools.Connections.Database;

namespace JWT.Dal.Repository
{
    public class UserRepository : RepositoryBase<User, Guid>, IUserRepo
    {
        public UserRepository() : base("V_UserApp", "Id")
        {

        }

        public override bool Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public override Guid Insert(User entity)
        {
            Command cmd = new Command("RegisterUser", true);
            cmd.AddParameter("@Email", entity.Email);
            cmd.AddParameter("@Username", entity.Username);
            cmd.AddParameter("@Password", entity.Password);
            cmd.AddParameter("@IsAdmin", entity.IsAdmin);
            cmd.AddParameter("@BirthDate", entity.BirthDate);

            return (Guid)Connection.ExecuteScalar(cmd);
        }

        public User Login(string Email, string password)
        {
            Command cmd = new Command("LoginUser", true);
            cmd.AddParameter("@Email", Email);
            cmd.AddParameter("@Password", password);

            return Connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public override bool Update(User entity)
        {
            throw new NotImplementedException();
        }

        protected override User Convert(IDataRecord record)
        {
            return new User()
            {
                Id = Guid.Parse(record["Id"].ToString()),
                Email = record["Email"].ToString(),
                Username = record["Username"].ToString(),
                IsAdmin = (bool)record["IsAdmin"],
                Password = null,
                BirthDate = (DateTime)record["BirthDate"]
            };
        }
    }
}
