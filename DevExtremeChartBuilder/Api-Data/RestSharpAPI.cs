using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace DevExtremeChartBuilder.Api_Data
{
    public class RestSharpAPI
    {
        public static async Task<AccessToken> GetToken()
        {
            var client = new RestClient("https://wso2am-dev.chinhquyendientu.vn/oauth2/token?grant_type=client_credentials");
            //client.Timeout = -1;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var request = new RestRequest("https://wso2am-dev.chinhquyendientu.vn/oauth2/token?grant_type=client_credentials", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", "Basic aENXTU9oTUlIVGN2ZkxHaXR0RVIwWFRHa09RYTpYaXV3NHZ0amZIN2NiSUFpUXFCOEhfOGc3VFlh");
            RestResponse response = await client.PostAsync(request);

            Console.WriteLine(response.Content);
            AccessToken token = new AccessToken
            {
                access_token = "1",
                scope = "1",
                expires_in = "1",
                token_type = "1"
            };


            if (response.Content != null)
            {
                token = JsonConvert.DeserializeObject<AccessToken>(response.Content);
            }


            return await Task.FromResult(token);
        }


        public static async Task<SubjectArea[]> Get_SubjectArea()
        {
            AccessToken token = await GetToken();

            string bearer_token = "Bearer " + token.access_token;

            var client = new RestClient("https://apiwso2am-dev.chinhquyendientu.vn/subjectarea/1.0/resource");
            //client.Timeout = -1;
            var request = new RestRequest("https://apiwso2am-dev.chinhquyendientu.vn/subjectarea/1.0/resource", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", bearer_token);
            RestResponse response2 = await client.GetAsync(request);

            JObject responseRaw = (JObject)JsonConvert.DeserializeObject(response2.Content);
            SubjectArea[] jwt = responseRaw["c_subject_area"].ToObject<JObject>()["Data"].ToObject<SubjectArea[]>();
            return await Task.FromResult(jwt);
        }




        public static async Task<So_don_vi_hanh_chinh[]> Lay_so_don_vi_hanh_chinh()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient("https://wso2am-dev.chinhquyendientu.vn/oauth2/token?grant_type=client_credentials");

            var request = new RestRequest("https://wso2am-dev.chinhquyendientu.vn/oauth2/token?grant_type=client_credentials", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Basic c0Vfd2p0QWp6TXBvUXRRSEpGaWZmczNvR1JNYTphQUlsV3htWFpEamZCWFJzRVVXbWZKODkzM1Fh");
            RestResponse response = await client.PostAsync(request);
            AccessToken token = JsonConvert.DeserializeObject<AccessToken>(response.Content);

            var client_1 = new RestClient("https://apiwso2am-dev.chinhquyendientu.vn/open_data/api/v1/tc_hc/so_dv_hc?group_code=A001");
            var request_1 = new RestRequest("https://apiwso2am-dev.chinhquyendientu.vn/open_data/api/v1/tc_hc/so_dv_hc?group_code=A001", Method.Get);
            request_1.AddHeader("Accept", "application/json");
            request_1.AddHeader("Authorization", "Bearer " + token.access_token);
            RestResponse response_1 = await client_1.GetAsync(request_1);

            JObject responseraw = (JObject)JsonConvert.DeserializeObject(response_1.Content);
            So_don_vi_hanh_chinh[] jwt = responseraw["so_don_vi_hanh_chinh"].ToObject<JObject>()["Data"].ToObject<So_don_vi_hanh_chinh[]>();
            return await Task.FromResult(jwt);
        }



    }
}