using OkService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OkService.Controllers
{
    public class OkController : ApiController
    {
        [HttpGet]
        public JsonResult<List<DailyScore>> HighScores()
        {
            using (TestDbEntities db = new TestDbEntities())
            {
                var entry = db.Scores.FirstOrDefault();
                if (entry != null)
                {
                    List<DailyScore> score = JsonConvert.DeserializeObject<List<DailyScore>>(entry.JsonData);
                    return Json<List<DailyScore>>(score);
                }
                else
                {
                    return Json<List<DailyScore>>(null);
                }
            }
        }

        [HttpPost]
        public IHttpActionResult SaveScore(DailyScore score)
        {
            using (TestDbEntities db = new TestDbEntities())
            {
                var entry = db.Scores.FirstOrDefault();
                if (entry != null)
                {
                    List<DailyScore> scores = JsonConvert.DeserializeObject<List<DailyScore>>(entry.JsonData ?? string.Empty);
                    scores.Add(score);
                    entry.JsonData = JsonConvert.SerializeObject(scores);
                    db.SaveChanges();
                }
                else
                {
                    Score newScore = new Score();

                    List<DailyScore> scores = new List<DailyScore>();
                    scores.Add(score);
                    newScore.JsonData = JsonConvert.SerializeObject(scores);
                    
                    db.Scores.Add(newScore);
                    db.SaveChanges();
                }

                return Ok();
            }
        }

    }
}