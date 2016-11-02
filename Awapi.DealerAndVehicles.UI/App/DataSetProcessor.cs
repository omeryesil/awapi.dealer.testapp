using Awapi.DealerAndVehicles.UI.App.Utilities;
using IO.Swagger.Api;
using IO.Swagger.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Awapi.DealerAndVehicles.UI.App
{
    public class DataSetProcessor
    {
        private DataSetApi _dataSetApiClient;

        public DataSetProcessor()
        {
            _dataSetApiClient = new DataSetApi(ConfigProvider.API_BaseURL);
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetDatasetId()
        {
            var dataSetIdResponse = _dataSetApiClient.DataSetGetDataSetId();
            return dataSetIdResponse.DatasetId;
        }

        /// <summary>
        /// Acquires Vehicles and Dealers, then Posts to Answer's endpoint 
        /// </summary>
        /// <param name="dataSetId"></param>
        /// <returns></returns>
        public async Task<AnswerResponse> ProcessAnswer(string dataSetId)
        {
            VehicleProcessor vehicleProcessor = new VehicleProcessor();
            DealerProcessor dealerProcessor = new DealerProcessor();

            //Retrieve all vehicles for the given dataSetId
            List<int?> vehiclesIds = vehicleProcessor.GetVehicleIds(dataSetId);
            List<VehicleResponse> vehicleList = await vehicleProcessor.GetVehicles(dataSetId, vehiclesIds);


            //Retrieve all dealers for the given dataSetId
            List<int?> dealerIds = vehicleList.Select(l => l.DealerId).Distinct().ToList();
            List<DealersResponse> dealerList = await dealerProcessor.GetDealers(dataSetId, dealerIds);

            //Create Answer instance, and Post it --------
            Answer answer = CreateAnswer(vehicleList, dealerList);
            var answerResponse = PostAnswer(dataSetId, answer);

            return answerResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleList"></param>
        /// <param name="dealerList"></param>
        /// <returns></returns>
        public Answer CreateAnswer(List<VehicleResponse> vehicleList, List<DealersResponse> dealerList)
        {
            var answer = new Answer();
            answer.Dealers = (from d in dealerList
                              select new DealerAnswer
                              {
                                  DealerId = d.DealerId,
                                  Name = d.Name,
                                  Vehicles = (from v in vehicleList
                                              where v.DealerId == d.DealerId
                                              select new VehicleAnswer
                                              {
                                                  VehicleId = v.VehicleId,
                                                  Make = v.Make,
                                                  Model = v.Model,
                                                  Year = v.Year
                                              }).ToList()
                              }).ToList();

            return answer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSetId"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        public AnswerResponse PostAnswer(string dataSetId, Answer answer)
        {
            var answerResponse = _dataSetApiClient.DataSetPostAnswer(dataSetId, answer);
            return answerResponse;
        }

    }
}