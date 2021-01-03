using System;
using System.IO;
using SQLite;
using TvDashboard.Backend.Models;

namespace TvDashboard.Backend.Services
{
    public class DbService
    {
        public string DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TvDashboardData.db");
        public SQLiteConnection GetConnection => new(DbPath);
        public SQLiteAsyncConnection GetAsyncConnection => new(DbPath);

        public DbService()
        {
            var db = GetConnection;
            db.CreateTable<Todo>();
        }
    }
}