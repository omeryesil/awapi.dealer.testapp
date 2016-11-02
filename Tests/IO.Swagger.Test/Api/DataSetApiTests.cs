/* 
 * DealersAndVehicles
 *
 * No descripton provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing DataSetApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class DataSetApiTests
    {
        private DataSetApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new DataSetApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of DataSetApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' DataSetApi
            //Assert.IsInstanceOfType(typeof(DataSetApi), instance, "instance is a DataSetApi");
        }

        
        /// <summary>
        /// Test DataSetGetCheat
        /// </summary>
        [Test]
        public void DataSetGetCheatTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string datasetId = null;
            //var response = instance.DataSetGetCheat(datasetId);
            //Assert.IsInstanceOf<Answer> (response, "response is Answer");
        }
        
        /// <summary>
        /// Test DataSetGetDataSetId
        /// </summary>
        [Test]
        public void DataSetGetDataSetIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.DataSetGetDataSetId();
            //Assert.IsInstanceOf<DatasetIdResponse> (response, "response is DatasetIdResponse");
        }
        
        /// <summary>
        /// Test DataSetPostAnswer
        /// </summary>
        [Test]
        public void DataSetPostAnswerTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string datasetId = null;
            //Answer answer = null;
            //var response = instance.DataSetPostAnswer(datasetId, answer);
            //Assert.IsInstanceOf<AnswerResponse> (response, "response is AnswerResponse");
        }
        
    }

}
