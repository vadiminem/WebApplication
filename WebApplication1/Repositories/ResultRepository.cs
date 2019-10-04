using System;
using System.Data;
using System.Linq;
using DapperExtensions;
using Microsoft.Extensions.Configuration;
using Npgsql;
using WebApplication.Models;
using WebApplication1.Interfaces;

namespace WebApplication1.Models
{
    public class ResultRepository : IResultRepository
    {
        private IConfigurationSection connectionStrings = default;
        public ResultRepository(IConfigurationSection connectionStrings)
        {
            this.connectionStrings = connectionStrings;
        }

        public void Create(SomeObject someObject)
        {
            try
            {
                var randValue = new Random();
                using (var db = new NpgsqlConnection(connectionStrings.GetSection("PostgresqlConnection").Value))
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public SomeObject Get()
        {
            try
            {
                using (IDbConnection db = new NpgsqlConnection(connectionStrings.GetSection("PostgresqlConnection").Value))
                {
                    var someObject = new SomeObject();
                    var id = db.GetList<ResultModel>().OrderBy(t => t.Id).Last().Id;
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
            catch (Exception ex)
            {
                return new SomeObject() {ErrorMessage = ex.Message };
            }
        }
    }
}
