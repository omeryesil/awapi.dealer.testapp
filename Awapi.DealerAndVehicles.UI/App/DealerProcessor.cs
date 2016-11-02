using Awapi.DealerAndVehicles.UI.App.Utilities;
using IO.Swagger.Api;
using IO.Swagger.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awapi.DealerAndVehicles.UI.App
{
    public class DealerProcessor
    {
        private DealersApi _dealerApiClient;

        public DealerProcessor()
        {
            _dealerApiClient = new DealersApi(ConfigProvider.API_BaseURL);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSetId"></param>
        /// <param name="dealerIds"></param>
        /// <returns></returns>
        public async Task<List<DealersResponse>> GetDealers(string dataSetId, List<int?> dealerIds)
        {
            //Retrieve all vehicles --------------------
            List<Task<DealersResponse>> dealersResponseTasks = new List<Task<DealersResponse>>();
            foreach (int? dealerId in dealerIds)
            {
                dealersResponseTasks.Add(ProcessDealerRequest(dataSetId,
                                                    dealerId,
                                                    _dealerApiClient));
            }
            var dealerResponseList = await Task.WhenAll(dealersResponseTasks);

            return dealerResponseList.ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSetId"></param>
        /// <param name="dealerId"></param>
        /// <param name="dealerApi"></param>
        /// <returns></returns>
        async Task<DealersResponse> ProcessDealerRequest(string dataSetId, int? dealerId, IO.Swagger.Api.DealersApi dealerApi)
        {
            var dealerResponse = await dealerApi.DealersGetDealerAsync(dataSetId, dealerId);

            return dealerResponse;
        }
    }
}