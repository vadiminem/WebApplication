using WebApplication.Models;

namespace WebApplication1.Models
{
    public class TraksModel : Traks
    {
        public TraksModel() { }
        public TraksModel(Traks traks) : base(traks)
        {
            SetsModel = new SetsModel[traks.Sets.Length];
            for (var i = 0; i < traks.Sets.Length; i++)
            {
                SetsModel[i] = new SetsModel(traks.Sets[i]);
            }
        }
        public int Id { get; set; }
        public int ResultId { get; set; }
        public SetsModel[] SetsModel {get; set;}
    }
}
