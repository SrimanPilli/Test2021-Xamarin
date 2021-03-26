using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test2021Library.Models;

namespace Test2021Library.Helper
{
    public abstract class SqliteDataService : ISqliteDataService
    {

        private static readonly object LockObject = new object();

        private SQLiteConnection _connection;
        public abstract void InitPlatform();
        public abstract string GetPlatformDatabasePath(string databaseName);
        public abstract void DeleteDatabaseFromPlatform(string filePath);

        protected SqliteDataService()
        {
            if (_connection != null)
                return;

            Initialize();
        }

        private void Initialize()
        {
          
            InitPlatform();

            //Create/Open the database

            string filePath = GetPlatformDatabasePath("localRepository.db");

            //Connect then Test Database Encryption to check Key is Valid
            try
            {
                //Connect to the Database
                var connectionString = new SQLiteConnectionString(filePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create, true);
                _connection = new SQLiteConnection(connectionString);
                //This will try to query the SQLite Schema Database, No Error If the key is Correct 
            }
            catch (SQLiteException)
            {
                //If Key is invalid then Dispose the connection and  Delete the db filepath
                _connection?.Dispose();
                _connection = null;
                DeleteDatabaseFromPlatform(filePath);
            }
        }
        public void CreateTables()
        {
            _connection.BeginTransaction();
            _connection.CreateTable<UsersModel>();
        }
        public int Count<T>() where T : new()
        {
            lock (LockObject)
            {
                try
                {
                    return _connection.Table<T>().Count();
                }
                catch
                {
                    return 0;
                }
            }
        }

        public int Insert(object value, Type type)
        {
            lock (LockObject)
            {
                try
                {
                    int result = _connection.Insert(value, type);

                    return result;
                }
                catch
                {
                    return -1;
                }
            }
        }

        public int InsertOrUpdate(object value, Type type)
        {
            lock (LockObject)
            {
                try
                {
                    int result = _connection.InsertOrReplace(value, type);

                    return result;
                }
                catch
                {
                    return -1;
                }
            }
        }

        public List<T> ReadList<T>() where T : new()
        {
            lock (LockObject)
            {
                try
                {
                    return _connection.Table<T>().ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public int Update(object value, Type type)
        {
            lock (LockObject)
            {
                try
                {
                    int result = _connection.Update(value, type);

                    return result;
                }
                catch
                {
                    return -1;
                }
            }
        }

        

        public T ReadFirst<T>(Expression<Func<T, bool>> predicate) where T : new()
        {
            lock (LockObject)
            {
                try
                {
                    return _connection.Table<T>().Where(predicate).FirstOrDefault();
                }
                catch
                {
                    return default;
                }
            }
        }
    }
}
