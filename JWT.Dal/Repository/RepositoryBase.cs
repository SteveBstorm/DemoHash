using JWT.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Tools.Connections.Database;

namespace JWT.Dal.Repository
{
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : new()
    {
        protected Connection Connection { get; }
        protected string TableName { get; }
        protected string IdName { get; }

        public RepositoryBase(string tableName, string idName ="Id")
        {
            //Info de connexion
            Connection = new Connection(SqlClientFactory.Instance,@"Data Source=DESKTOP-RGPQP6I\TFTIC2014;Initial Catalog=JWT2;User ID=sa;Password=steve1983;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            TableName = tableName;
            IdName = idName;
        }

        protected abstract TEntity Convert(IDataRecord record);

        public abstract bool Delete(TKey Id);
        

        public TEntity Get(TKey Id)
        {
            Command cmd = new Command( "SELECT * FROM [" + TableName + "] WHERE "+IdName+ " = @Id");
            cmd.AddParameter("Id", Id);

            return Connection.ExecuteReader(cmd, Convert).SingleOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [" + TableName + "]");
            return Connection.ExecuteReader(cmd, Convert);
        }

        public abstract TKey Insert(TEntity entity);

        public abstract bool Update(TEntity entity);
        
    }
}
