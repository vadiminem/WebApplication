using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.IdentityModel.Protocols;
using Npgsql;
using WebApplication.Models;

namespace WebApplication1.Models
{
    public class ResultRepository
    {

        string connectionString = "User ID=postgres;Password=1234;Host=localhost; Port=5432; Database=testwebapidb; Pooling=true;";
        public void Create(SomeObject someObject)
        {
            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
                var randValue = new Random();
                var date = DateTime.Now; Console.WriteLine(date);
                var sqlQuery = "INSERT INTO \"Result\" DEFAULT VALUES;";
                db.Execute(sqlQuery, new { cDate = date });
                var rId = db.Query<int>("SELECT resultid FROM \"Result\";").Last();
                foreach (var trak in someObject.Result.Traks)
                {
                    sqlQuery = "INSERT INTO \"Traks\"(resultid, pos, vmin, vmax) VALUES(@resultId, @pos, @vMin, @vMax);";
                    db.Execute(sqlQuery, new { resultId = rId, pos = trak.Pos, vMin = trak.VMin, vMax = trak.VMax });
                    var tId = db.Query<int>("SELECT traksid FROM \"Traks\" WHERE resultid = @resultId AND pos = @pos;", new { resultId = rId, pos = trak.Pos }).FirstOrDefault();
                    foreach (var set in trak.Sets)
                    {
                        sqlQuery = "INSERT INTO \"Sets\"(traksid) VALUES(@traksId);";
                        db.Execute(sqlQuery, new { traksId = tId });
                        var sId = db.Query<int>("SELECT setsid FROM \"Sets\" WHERE traksid = @traksId;", new { traksI = rId }).LastOrDefault();
                        foreach (var item in set.Items)
                        {
                            sqlQuery = "INSERT INTO \"Items\"(setsid, time, value, randvalue)" +
                                "VALUES(@setsid, @time, @value, @randvalue);";
                            db.Execute(sqlQuery, new { setsid = sId, time = item.Time, value = item.Value, randvalue = randValue.Next(10, 100) });
                        }

                    }
                }
            }
        }

        public object Get()
        {
            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
                var someObject = new SomeObject();
                someObject.Result = new Result();
                var rId = db.Query<int>("SELECT resultid FROM \"Result\"").Last();
                var sqlRes = db.Query("SELECT traksid FROM \"Traks\" WHERE resultid=@resultId", new { resultid = rId }).ToArray();
                someObject.Result.Traks = new Traks[sqlRes.Count()];
                for (var i = 0; i < sqlRes.Count(); i++)
                {
                    someObject.Result.Traks[i] = db.Query<Traks>("SELECT * FROM \"Traks\" WHERE traksid=@traksId", new { traksId = sqlRes[i].traksid }).ToArray()[0];
                    var sqlSets = db.Query("SELECT * FROM \"Sets\" WHERE traksid=@traksId", new { traksId = sqlRes[i].traksid }).ToArray();
                    someObject.Result.Traks[i].Sets = new Sets[sqlSets.Count()];
                    for (var j = 0; j < sqlSets.Count(); j++)
                    {
                        someObject.Result.Traks[i].Sets[j] = new Sets();
                        var sqlItems = db.Query<Items>("SELECT * FROM \"Items\" WHERE setsid=@setsId", new { setsId = sqlSets[j].setsid }).ToArray();
                        someObject.Result.Traks[i].Sets[j].Items = sqlItems;
                    }
                }
                return someObject;
            }
        }
    }
}
