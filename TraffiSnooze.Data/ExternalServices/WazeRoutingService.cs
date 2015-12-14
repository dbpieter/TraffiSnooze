using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraffiSnooze.Data.Common;
using TraffiSnooze.Data.ExternalModels.Waze;

namespace SleepTitle.Data.ExternalServices
{
    public class WazeRoutingService
    {
        public string RootUrl => "https://www.waze.com/";

        public string RequestUrl = "row-routingManager/routingRequest";
        
        private enum WazeLocation {
            Europe,
            USA_CANADA,
            ISRAEL
        }

        private ApiRepoBase repoBase;

        public WazeRoutingService()
        {
            repoBase = new ApiRepoBase(RootUrl);
        }

        public async Task<IEnumerable<Result>> GetRoutingInfo(float fromX, float fromY, float toX, float toY)
        {
            string from = $"x:{fromX}+y{fromY}";
            string to = $"x:{toX}+y{toY}";

            var urlParams = new List<UrlParam>()
            {
                new UrlParam("from",from),new UrlParam("to",to), new UrlParam("returnJSON","true")
            };
            var rootObj = await repoBase.GetAsync<Rootobject>(RequestUrl, urlParams.ToArray());
            return new List<Result>(rootObj.response.results);
        }
        //https://www.waze.com/row-RoutingManager/routingRequest?from=x%3A4.262249+y%3A50.752061&to=x%3A3.954767+y%3A50.969350&at=0&returnJSON=true&returnGeometries=true&returnInstructions=true&returnJSON=true
    }
}
