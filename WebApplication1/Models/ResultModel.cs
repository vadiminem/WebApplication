using System;
using WebApplication.Models;

namespace WebApplication1.Models
{
    public class ResultModel : Result
    {
        public ResultModel() { }
        public ResultModel(Result result) : base(result)
        {
            TraksModel = new TraksModel[result.Traks.Length];
            for (var i = 0; i < result.Traks.Length; i++)
            {
                TraksModel[i] = new TraksModel(result.Traks[i]);
            }
            
        }
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public TraksModel[] TraksModel { get; set; }
    }
}
