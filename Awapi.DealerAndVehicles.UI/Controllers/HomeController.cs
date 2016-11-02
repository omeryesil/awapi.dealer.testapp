using Awapi.DealerAndVehicles1.App.Utilities;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Awapi.DealerAndVehicles.UI.App
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Generate")]
        public ActionResult Generate(string action)
        {
            //Get a dataSetId from the API 
            var dataSetId = new DataSetProcessor().GetDatasetId();
            ViewBag.DatasetId = dataSetId;

            return View("");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Submit")]
        public async Task<ActionResult> Submit(string action)
        {
            string dataSetId = Request["dataSetId"];

            #region Diagnostic 
            var stopWatch = System.Diagnostics.Stopwatch.StartNew();
            stopWatch.Start();
            #endregion

            if (!string.IsNullOrWhiteSpace(dataSetId))
            {
                DataSetProcessor dataSetProcessor = new DataSetProcessor();
                var result = await dataSetProcessor.ProcessAnswer(dataSetId);

                ViewBag.AnswerResponse = result.ToJson();
                ViewBag.DatasetId = dataSetId;
            }

            #region Diagnostic 
            stopWatch.Stop();
            ViewBag.ExecutionTime = string.Format("Execution time: {0}ms", stopWatch.ElapsedMilliseconds);

            #endregion

            return View("");
        }


    }
}