using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using IO.Swagger.Api;
using Awapi.DealerAndVehicles.UI.App.Utilities;

namespace Awapi.DealerAndVehicles.UI.App
{
    /// <summary>
    /// 
    /// </summary>
    public class VehicleProcessor
    {

        private VehiclesApi _vehicleApiClient;

        public VehicleProcessor()
        {
            _vehicleApiClient = new IO.Swagger.Api.VehiclesApi(ConfigProvider.API_BaseURL);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSetId"></param>
        /// <returns></returns>
        public List<int?> GetVehicleIds(string dataSetId)
        {
            //Retrieve all vehicles 
            var vehiclesClient = new IO.Swagger.Api.VehiclesApi(ConfigProvider.API_BaseURL);
            var vehiclesIdsResponse = vehiclesClient.VehiclesGetIds(dataSetId);

            return vehiclesIdsResponse.VehicleIds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSetId"></param>
        /// <param name="vehicleIds"></param>
        /// <returns></returns>
        public async Task<List<VehicleResponse>> GetVehicles(string dataSetId, List<int?> vehicleIds)
        {
            //Retrieve all vehicles --------------------
            List<Task<VehicleResponse>> vehiclesResponseTasks = new List<Task<VehicleResponse>>();

            foreach (int? vehicleId in vehicleIds)
            {
                vehiclesResponseTasks.Add(ProcessVehicleRequest(dataSetId,
                                                    vehicleId,
                                                    _vehicleApiClient));
            }
            var vehicleList = await Task.WhenAll(vehiclesResponseTasks);

            return vehicleList.ToList();
        }

        /// <summary>
        /// Makes an async call to Vehicles API endpoint to get a specific vehicle
        /// </summary>
        /// <param name="dataSetId"></param>
        /// <param name="vehicleId"></param>
        /// <param name="vehicleApi"></param>
        /// <returns></returns>
        async Task<VehicleResponse> ProcessVehicleRequest(string dataSetId, int? vehicleId, IO.Swagger.Api.VehiclesApi vehicleApi)
        {
            var vehicleReturn = await vehicleApi.VehiclesGetVehicleAsync(dataSetId, vehicleId);

            return vehicleReturn;
        }

    }
}