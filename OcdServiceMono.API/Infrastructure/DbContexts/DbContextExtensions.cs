﻿using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;

namespace OcdServiceMono.API.Infrastructure.DbContexts
{
    public static class DbContextExtensions
    {
        public static DataTable DataTable(this DbContext context, string sqlQuery)
        {
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(context.Database.GetDbConnection());

            using (var cmd = dbFactory.CreateCommand())
            {
                cmd.Connection = context.Database.GetDbConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlQuery;
                using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = cmd;

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
            }
        }
    }
}
