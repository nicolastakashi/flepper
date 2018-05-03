﻿using Flepper.Tests.Integration.Infra.Extensions;
using Microsoft.Data.Sqlite;
using System;
using System.Data;

namespace Flepper.Tests.Integration.Infra.Fixture
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            Connection = new SqliteConnection("Data Source=flepper.db");

            Connection
                .CreateProfileTable()
                .CreateUserTable()
                .CreatePeopleTable()
                .CreateTest1AndTest2Table()
                .LoadProfileTable()
                .LoadUserTable()
                .LoadPeopleTable()
                .LoadTest1Table();
        }

        public void Dispose()
        {
            Connection
                .ResetUserTable()
                .ResetProfileTable()
                .ResetPeopleTable()
                .ResetTest1AndTest2Table();
        }

        public IDbConnection Connection { get; private set; }
    }
}
