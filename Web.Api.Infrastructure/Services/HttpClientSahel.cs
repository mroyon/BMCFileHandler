using BDO.Core.DataAccessObjects.CommonEntities;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.DataAccessObjects.ExtendedEntities;
using BDO.DataAccessObjects.ExtendedEntities.IQRCodeAuthentication;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Infrastructure.Interfaces;
using Web.Core.Frame.Dto;
using Web.Core.Frame.Interfaces.Services;
using Web.Core.Frame.RequestResponse.UseCaseRequests;

namespace Web.Api.Infrastructure.Services
{

    internal sealed partial class HttpClientSahel : IHttpClientSahel
    {

        private readonly IConfiguration _config;
        private readonly HttpClient _client;
        private IHttpClientFactory _IHttpClienFactory;
        private readonly IJwtTokenValidator _jwtTokenValidator;
        private readonly IHttpContextAccessor _contextAccessor;

        private readonly IStringCompression _stringCompression;
        private readonly SahelServiceSettings _sahelServiceSettings;

        internal HttpClientSahel(IConfiguration config
            , IHttpContextAccessor contextAccessor
            , IHttpClientFactory IHttpClienFactory
            , IJwtTokenValidator jwtTokenValidator
            , IStringCompression stringCompression
            )
        {
            _contextAccessor = contextAccessor;
            _config = config;
            _IHttpClienFactory = IHttpClienFactory;
            _stringCompression = stringCompression;
            _jwtTokenValidator = jwtTokenValidator;
            _sahelServiceSettings = _config.GetSection(nameof(SahelServiceSettings)).Get<SahelServiceSettings>();

            HttpClient client = _IHttpClienFactory.CreateClient();
            client.BaseAddress = new Uri(_sahelServiceSettings.WebApiAddress);
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            client.DefaultRequestHeaders.Add("User-Agent", "CoreCors");
            _client = client;
        }

        public async Task<string> LoginToSahelAPIService()
        {
            string responseFinal = string.Empty;
            string token = string.Empty;
            try
            {
                //HttpClient client = new HttpClient();

                //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://kproxy.sahel.kw/api/sahel/token/generate");

                //request.Headers.Add("Cookie", "BIGipServerSahelKINProxy_POOL=135007754.11033.0000; TS017c39f7=019cb029383a70abeed0a63f7ad10ea95ca0bc9a1ae3f269d712ee50dd780c66fc2078ceb3f6188598ee207dc9a4641b251d3ca3258e287bb7e637a38c20d2c442c9a21911");

                //request.Content = new StringContent("{\n  \"userName\": \"mod\",\n  \"password\": \"@ba_:e%#tx:BR%)bw7oX\"\n}\u00a0\n");
                //request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //HttpResponseMessage response = await client.SendAsync(request);
                //response.EnsureSuccessStatusCode();
                //var responseBody = await response.Content.ReadAsStringAsync();


                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), _sahelServiceSettings.WebApiAddress + "token/generate"))
                    {
                        request.Content = new StringContent("{\n  \"userName\": \"" + _sahelServiceSettings.UserName + "\",\n  \"password\": \"" + _sahelServiceSettings.Password + "\"\n} \n");
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        var response = await httpClient.SendAsync(request);

                        var JsonStrm = response.Content.ReadAsStringAsync();
                        if (JsonStrm != null)
                            if (!string.IsNullOrEmpty(JsonStrm.Result))
                            {
                                responseFinal = JsonStrm.Result;
                            }
                    }
                }

                dynamic dynamicApi = JsonConvert.DeserializeObject(responseFinal);
                token = dynamicApi.accessToken.ToString();
                return token;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<sahelNotificationResponseEntity> SendNotificationToSahel(sahelNotificationRequestEntity objEntity)
        {
            string responseFinal = string.Empty;
            string token = string.Empty;
            sahelNotificationResponseEntity objRet = new sahelNotificationResponseEntity();
            try
            {
                token = await LoginToSahelAPIService();

                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), _sahelServiceSettings.WebApiAddress + "notification/single"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "bearer " + token);

                        request.Content = new StringContent("{" +
                            "\n  \"subscriberCivilId\": \"" + objEntity.subscriberCivilId + "\"," +
                            "\n  \"bodyAr\": \"" + objEntity.bodyAr + "\"," +
                            "\n  \"bodyEn\": \"" + objEntity.bodyEn + "\"," +

                            GetDataTableAR(objEntity.dataTableAr) + GetDataTableEN(objEntity.dataTableEn) +

                            "\n  \"isForSubscriber\": true," +
                            "\n  \"notificationType\": \"" + objEntity.notificationType + "\"," +

                            GetButtonActionList(objEntity.actionButtonRequestList) +

                            "\n}" +
                            "\n");


                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);
                        var JsonStrm = response.Content.ReadAsStringAsync();
                        if (JsonStrm != null)
                            if (!string.IsNullOrEmpty(JsonStrm.Result))
                            {
                                responseFinal = JsonStrm.Result;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            objRet = JsonConvert.DeserializeObject<sahelNotificationResponseEntity>(responseFinal);
            return objRet;
        }

        public async Task<List<sahelNotificationResponseEntity>> SendNotificationToSahelList(sahelNotificationRequestListEntity objEntity)
        {
            string responseFinal = string.Empty;
            string token = string.Empty;
            List<sahelNotificationResponseEntity> objRet = new List<sahelNotificationResponseEntity>();
            try
            {
                token = await LoginToSahelAPIService();

                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), _sahelServiceSettings.WebApiAddress + "notification/list"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "bearer " + token);

                        request.Content = new StringContent("{" +

                            subscriberCivilIdList(objEntity) +

                            "\n  \"bodyAr\": \"" + objEntity.bodyAr + "\"," +
                            "\n  \"bodyEn\": \"" + objEntity.bodyEn + "\"," +

                            GetDataTableListAR(objEntity.dataTableAr) + GetDataTableListEN(objEntity.dataTableEn) +

                            "\n  \"isForSubscriber\": true," +
                            "\n  \"notificationType\": \"" + objEntity.notificationType + "\"," +

                            GetButtonActionList(objEntity.actionButtonRequestList) +

                            "\n}" +
                            "\n");

                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);
                        var JsonStrm = response.Content.ReadAsStringAsync();
                        if (JsonStrm != null)
                            if (!string.IsNullOrEmpty(JsonStrm.Result))
                            {
                                responseFinal = JsonStrm.Result;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            objRet = JsonConvert.DeserializeObject<List<sahelNotificationResponseEntity>>(responseFinal);
            return objRet;
        }

        public async Task<List<sahelNotificationResponseEntity>> SendNotificationToSahelBulk(sahelNotificationRequestListEntity objEntity)
        {
            string responseFinal = string.Empty;
            string token = string.Empty;
            List<sahelNotificationResponseEntity> objRet = new List<sahelNotificationResponseEntity>();
            try
            {
                token = await LoginToSahelAPIService();

                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), _sahelServiceSettings.WebApiAddress + "notification/bulk"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "bearer " + token);

                        request.Content = new StringContent("{" +
                            
                            subscriberCivilIdList(objEntity) + 

                            "\n  \"bodyAr\": \"" + objEntity.bodyAr + "\"," +
                            "\n  \"bodyEn\": \"" + objEntity.bodyEn + "\"," +

                            GetDataTableListAR(objEntity.dataTableAr) + GetDataTableListEN(objEntity.dataTableEn) +

                            "\n  \"isForSubscriber\": true," +
                            "\n  \"notificationType\": \"" + objEntity.notificationType + "\"," +

                            GetButtonActionList(objEntity.actionButtonRequestList) +

                            "\n}" +
                            "\n");


                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);
                        var JsonStrm = response.Content.ReadAsStringAsync();
                        if (JsonStrm != null)
                            if (!string.IsNullOrEmpty(JsonStrm.Result))
                            {
                                responseFinal = JsonStrm.Result;
                            }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            objRet  = JsonConvert.DeserializeObject<List<sahelNotificationResponseEntity>>(responseFinal);
            return objRet;
        }
               

        private string GetDataTableAR(IList<BDO.DataAccessObjects.ExtendedEntities.DataTableAr> dataTableAr)
        {
            string requestDataTableAR = string.Empty;
            bool cutthelastchar = false;

            try
            {
                if (dataTableAr != null && dataTableAr.Count > 0)
                {
                    requestDataTableAR = "\n  \"dataTableAr\": {";

                    foreach (BDO.DataAccessObjects.ExtendedEntities.DataTableAr objSingle in dataTableAr)
                    {
                        cutthelastchar = true;
                        requestDataTableAR += "\n    \"" + objSingle.title + "\": \"" + objSingle.value + "\",";
                    }

                    if (cutthelastchar)
                        requestDataTableAR = requestDataTableAR.Remove(requestDataTableAR.Length - 1, 1);

                    requestDataTableAR += "\n  }";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (!string.IsNullOrEmpty(requestDataTableAR))
                requestDataTableAR = requestDataTableAR + ", ";

            return requestDataTableAR;
        }

        private string GetDataTableEN(List<BDO.DataAccessObjects.ExtendedEntities.DataTableEn> dataTableEn)
        {
            string requestDataTableEN = string.Empty;
            bool cutthelastchar = false;

            try
            {
                cutthelastchar = false;
                if (dataTableEn != null && dataTableEn.Count > 0)
                {
                    requestDataTableEN = "\n  \"dataTableEn\": {";

                    foreach (BDO.DataAccessObjects.ExtendedEntities.DataTableEn objSingle in dataTableEn)
                    {
                        cutthelastchar = true;
                        requestDataTableEN += "\n    \"" + objSingle.title + "\": \"" + objSingle.value + "\",";
                    }

                    if (cutthelastchar)
                        requestDataTableEN = requestDataTableEN.Remove(requestDataTableEN.Length - 1, 1);

                    requestDataTableEN += "\n  }";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (!string.IsNullOrEmpty(requestDataTableEN))
                requestDataTableEN = requestDataTableEN + ", ";

            return requestDataTableEN;
        }

        private string GetButtonActionList(List<BDO.DataAccessObjects.ExtendedEntities.ActionButtonRequestList> actionButtonRequestList)
        {
            string actionButtonRequestStr = string.Empty;
            bool cutthelastchar = false;

            try
            {
                actionButtonRequestStr = "\n  \"actionButtonRequestList\": [";

                if (actionButtonRequestList != null && actionButtonRequestList.Count > 0)
                {
                   

                    foreach (BDO.DataAccessObjects.ExtendedEntities.ActionButtonRequestList objSingle in actionButtonRequestList)
                    {
                        cutthelastchar = true;
                        actionButtonRequestStr += "\n    {" +
                                    "\n      \"actionType\": \"" + objSingle.actionType + "\"," +
                                    "\n      \"actionUrl\": \"" + objSingle.actionUrl + "\"," +
                                    "\n      \"viewBag\": \"" + objSingle.viewBag + "\"," +
                                    "\n      \"labelAr\": \"" + objSingle.labelAr + "\"," +
                                    "\n      \"labelEn\": \"" + objSingle.labelEn + "\"" +
                                "\n    } ,";
                    }

                    if (cutthelastchar)
                        actionButtonRequestStr = actionButtonRequestStr.Remove(actionButtonRequestStr.Length - 1, 1);

                   
                }
                actionButtonRequestStr += "\n  ]";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return actionButtonRequestStr;
        }



        private string GetDataTableListAR(IList<BDO.DataAccessObjects.ExtendedEntities.DataTableListAr> dataTableAr)
        {
            string requestDataTableAR = string.Empty;
            bool cutthelastchar = false;
            int i = 0;
            try
            {
                if (dataTableAr != null && dataTableAr.Count > 0)
                {
                    requestDataTableAR = "\n  \"dataTableAr\": {";

                    foreach (BDO.DataAccessObjects.ExtendedEntities.DataTableListAr objSingle in dataTableAr)
                    {
                        i += 1;
                        cutthelastchar = true;
                        requestDataTableAR += "\n    \"additionalProp" + i.ToString() + "\": \"" + objSingle.additionalPropValue + "\",";
                    }

                    if (cutthelastchar)
                        requestDataTableAR = requestDataTableAR.Remove(requestDataTableAR.Length - 1, 1);

                    requestDataTableAR += "\n  }";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (!string.IsNullOrEmpty(requestDataTableAR))
                requestDataTableAR = requestDataTableAR + ", ";

            return requestDataTableAR;
        }

        private string GetDataTableListEN(List<BDO.DataAccessObjects.ExtendedEntities.DataTableListEn> dataTableEn)
        {
            string requestDataTableEN = string.Empty;
            bool cutthelastchar = false;
            int i = 0;
            try
            {
                cutthelastchar = false;
                if (dataTableEn != null && dataTableEn.Count > 0)
                {
                    requestDataTableEN = "\n  \"dataTableEn\": {";

                    foreach (BDO.DataAccessObjects.ExtendedEntities.DataTableListEn objSingle in dataTableEn)
                    {
                        i += 1;
                        cutthelastchar = true;
                        requestDataTableEN += "\n    \"additionalProp" + i.ToString() + "\": \"" + objSingle.additionalPropValue + "\",";
                    }

                    if (cutthelastchar)
                        requestDataTableEN = requestDataTableEN.Remove(requestDataTableEN.Length - 1, 1);

                    requestDataTableEN += "\n  }";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (!string.IsNullOrEmpty(requestDataTableEN))
                requestDataTableEN = requestDataTableEN + ", ";

            return requestDataTableEN;
        }


        private string subscriberCivilIdList(sahelNotificationRequestListEntity objEntity)
        {
            string subscriberCivilIdListStr = string.Empty;
            bool cutthelastchar = false;

            try
            {
                cutthelastchar = false;
                if (objEntity.subscriberCivilId != null && objEntity.subscriberCivilId.Count > 0)
                {
                    subscriberCivilIdListStr = "\n  \"subscriberCivilId\": [";

                    foreach (string objSingle in objEntity.subscriberCivilId)
                    {
                        cutthelastchar = true;
                        subscriberCivilIdListStr += "\n    \"" + objSingle + "\",";
                    }

                    if (cutthelastchar)
                        subscriberCivilIdListStr = subscriberCivilIdListStr.Remove(subscriberCivilIdListStr.Length - 1, 1);

                    subscriberCivilIdListStr += "\n  ]";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (!string.IsNullOrEmpty(subscriberCivilIdListStr))
                subscriberCivilIdListStr = subscriberCivilIdListStr + ", ";

            return subscriberCivilIdListStr;
        }
    }
}
