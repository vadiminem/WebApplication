using System;
using System.Data;
using System.Linq;
using DapperExtensions;
using Npgsql;
using WebApplication.Models;
using WebApplication1.Interfaces;

namespace WebApplication1.Models
{
    public class ResultRepository : IResultRepository
    {
        private string connectionString = default;
        public ResultRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(SomeObject someObject)
        {
            var randValue = new Random();
            using (var db = new NpgsqlConnection(connectionString))
            {
                var res = new ResultModel(someObject.Result);
                var id = db.Insert(res);
                foreach (var trak in res.TraksModel)
                {
                    trak.ResultId = id;
                    var tId = db.Insert(trak);
                    foreach (var sets in trak.SetsModel)
                    {
                        sets.TraksId = tId;
                        var sId = db.Insert(sets);
                        foreach (var item in sets.ItemsModel)
                        {
                            item.SetsId = sId;
                            item.RandValue = randValue.Next(10, 100);
                            db.Insert(item);
                        }
                    }
                }
            }
        }

        public SomeObject Get()
        {
            using (IDbConnection db = new NpgsqlConnection(connectionString))
            {
                var someObject = new SomeObject();
                var id = db.GetList<ResultModel>().Last().Id;
                someObject.Result = new Result(db.Get<ResultModel>(id));
                var traks = db.GetList<TraksModel>().Where(t => t.ResultId == id).ToArray();
                someObject.Result.SetTraks(traks);
                for (var i = 0; i < someObject.Result.Traks.Length; i++)
                {
                    var sets = db.GetList<SetsModel>().Where(s => s.TraksId == traks[i].Id).ToArray();
                    someObject.Result.Traks[i].SetSets(sets);
                    for (var j = 0; j < someObject.Result.Traks[i].Sets.Length; j++)
                    {
                        var items = db.GetList<ItemsModel>().Where(itm => itm.SetsId == sets[j].Id).ToArray();
                        someObject.Result.Traks[i].Sets[j].SetItems(items);
                    }
                }
                return someObject;
            }
        }
    }
}
