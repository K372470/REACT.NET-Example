using DriveHack.Site.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace DriveHack.Site.Controllers
{
    [ApiController]
    public class BackendActionsController : ControllerBase
    {
        [HttpGet("api/getFirst")]
        public IActionResult GetFirst([FromServices] ApplicationContext db)
        {
            var data = new List<ViewData>();

            for (int id = 0; id < db.StartUp.Count(); id++)
            {
                int result = db.Props.Count(x => x.startId == id);
                data.Add(new ViewData() { IdCount = result, Name = db.StartUp.Where(x => x.id == id).First().name, Id = id });
            }
            if (data.Count == 0)
                return new StatusCodeResult(StatusCodes.Status405MethodNotAllowed);
            else
            {
                data.Sort();
                return new JsonResult(data);
            }
        }
        [HttpPost, HttpGet, Route("getInRange")]
        public IActionResult GetInRange([FromForm] DateTimeOffset endTime, [FromForm] DateTimeOffset startTime, [FromServices] ApplicationContext db)
        {
            var data = new List<ViewData>();
            for (int id = 0; id < db.StartUp.Count(); id++)
            {
                int result = db.Props.Count(x => x.startId == id && x.publishTime < endTime & x.publishTime > startTime);
                if (result != 0)
                {
                    string name = db.StartUp.Where(x => x.id == id).First().name;
                    data.Add(new ViewData() { IdCount = result, Name = name, Id = id });
                }
            }
            if (data.Count == 0)
                return new StatusCodeResult(StatusCodes.Status405MethodNotAllowed);
            else
            {
                data.Sort();
                return new JsonResult(data);
            }

        }
        [HttpGet("getCSV")]
        public ActionResult GetStatsFile(DateTime endTime, DateTime startTime, [FromServices] ApplicationContext db)
        {
            if (startTime > endTime)
                return Ok();
            List<CsvModel> resultList = new();
            for (int id = 0; id < db.StartUp.Count(); id++)
            {
                List<string> tmp = new();
                foreach (var model in db.Props.Where(x => x.startId == id & x.publishTime > startTime & x.publishTime < endTime).Select(x => x.link))
                    tmp.Add(model);
                resultList.Add(new CsvModel(db.StartUp.First(x => x.id == id).name, tmp.ToArray()));
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("Name;Count;Links\r\n");
            foreach (var model in resultList)
            {
                if (model.MentionCount > 0)
                {
                    sb.Append(model.Name + ';' + model.MentionCount + ';');
                    foreach (var x in model.Links)
                        sb.Append(x + ',');
                    sb.Append("\r\n");
                }
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Table.csv");
        }

        [Route("details"), HttpGet]
        public DetailedViewItem Details(int id, [FromServices] ApplicationContext db)
        {
            var links = db.Props.Where(x => x.startId == id).Select(x => x.link).ToArray();
            var name = db.StartUp.First(x => x.id == id).name;
            DetailedViewItem Model = new DetailedViewItem() { Name = name, Links = links };
            return Model;
        }
    }
}
