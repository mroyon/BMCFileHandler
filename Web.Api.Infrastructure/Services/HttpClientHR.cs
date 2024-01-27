using BDO.Core.DataAccessObjects.CommonEntities;
using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.DataAccessObjects.ApiModels;
using BDO.DataAccessObjects.ExtendedEntities;
using CLL.LLClasses;
using DocumentFormat.OpenXml.Bibliography;
using iTextSharp.text.pdf;
using Microsoft.AspNet.SignalR.Client.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

using Web.Api.Infrastructure.Interfaces;
using Web.Core.Frame.Interfaces.Services;
using Web.Core.Frame.RequestResponse.UseCaseRequests;

namespace Web.Api.Infrastructure.Services
{

    internal sealed partial class HttpClientHR : IHttpClientHR
    {

        private readonly IConfiguration _config;
        private readonly HttpClient _client;
        private IHttpClientFactory _IHttpClienFactory;
        private readonly IJwtTokenValidator _jwtTokenValidator;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly KNSServiceSettings _kNSServiceSettings;
        private readonly IStringCompression _stringCompression;
        private readonly SalaryServiceSettings _salaryServiceSettings;
        private readonly KAFPaciServiceSettings _kAFPaciServiceSettings;
        private readonly SahelApiServiceSettings _sahelApiServiceSettings;

        internal HttpClientHR(IConfiguration config
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
            _kNSServiceSettings = _config.GetSection(nameof(KNSServiceSettings)).Get<KNSServiceSettings>();
            _salaryServiceSettings = _config.GetSection(nameof(SalaryServiceSettings)).Get<SalaryServiceSettings>();
            _kAFPaciServiceSettings = _config.GetSection(nameof(KAFPaciServiceSettings)).Get<KAFPaciServiceSettings>();
            _sahelApiServiceSettings = _config.GetSection(nameof(SahelApiServiceSettings)).Get<SahelApiServiceSettings>();

            //HttpClient client = _IHttpClienFactory.CreateClient();
            //client.BaseAddress = new Uri(_kNSServiceSettings.WebApiAddress);
            //client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            //client.DefaultRequestHeaders.Add("User-Agent", "CoreCors");
            //_client = client;

        }


        public async Task<knsCertificatesResponseEntity> GetKNSProfileCertificateByCivilID(GetStatusByCivilIDEntity objEntity)
        {
            knsCertificatesResponseEntity objData = new knsCertificatesResponseEntity();
            HttpResponseMessage response = null;
            var handler = new HttpClientHandler();
            handler.UseCookies = false;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), _kNSServiceSettings.WebApiAddress + "getProfileCertificateBase64/civilid/" + objEntity.civilid))
                {
                    request.Headers.TryAddWithoutValidation("username", _kNSServiceSettings.ApiUserName);
                    request.Headers.TryAddWithoutValidation("password", _kNSServiceSettings.ApiPassword);
                    response = await httpClient.SendAsync(request);
                    var JsonStrm = response.Content.ReadAsStringAsync();
                    if (JsonStrm != null)
                        if (!string.IsNullOrEmpty(JsonStrm.Result))
                        {
                            objData = JsonConvert.DeserializeObject<knsCertificatesResponseEntity>(JsonStrm.Result);
                            return objData;
                        }
                }
            }
            return null;
        }


        public async Task<knsCertificatesResponseEntity> GetKNSProfessionalCertificateByCivilID(GetStatusByCivilIDEntity objEntity)
        {
            knsCertificatesResponseEntity objData = new knsCertificatesResponseEntity();
            HttpResponseMessage response = null;
            var handler = new HttpClientHandler();
            handler.UseCookies = false;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), _kNSServiceSettings.WebApiAddress + "getProfileProfessionCertificateBase64/civilid/" + objEntity.civilid))
                {
                    request.Headers.TryAddWithoutValidation("username", _kNSServiceSettings.ApiUserName);
                    request.Headers.TryAddWithoutValidation("password", _kNSServiceSettings.ApiPassword);
                    response = await httpClient.SendAsync(request);
                    var JsonStrm = response.Content.ReadAsStringAsync();
                    if (JsonStrm != null)
                        if (!string.IsNullOrEmpty(JsonStrm.Result))
                        {
                            objData = JsonConvert.DeserializeObject<knsCertificatesResponseEntity>(JsonStrm.Result);
                            return objData;
                        }
                }
            }
            return null;
        }


        public async Task<knsCertificatesResponseEntity> GetKNSEmploymentCertificateByCivilID(GetStatusByCivilIDEntity objEntity)
        {
            knsCertificatesResponseEntity objData = new knsCertificatesResponseEntity();
            HttpResponseMessage response = null;
            var handler = new HttpClientHandler();
            handler.UseCookies = false;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), _kNSServiceSettings.WebApiAddress + "getProfileEmploymentCertificateBase64/civilid/" + objEntity.civilid))
                {
                    request.Headers.TryAddWithoutValidation("username", _kNSServiceSettings.ApiUserName);
                    request.Headers.TryAddWithoutValidation("password", _kNSServiceSettings.ApiPassword);
                    response = await httpClient.SendAsync(request);
                    var JsonStrm = response.Content.ReadAsStringAsync();
                    if (JsonStrm != null)
                        if (!string.IsNullOrEmpty(JsonStrm.Result))
                        {
                            objData = JsonConvert.DeserializeObject<knsCertificatesResponseEntity>(JsonStrm.Result);
                            return objData;
                        }
                }
            }
            return null;
        }



        public async Task<salaryCertificatesResponseEntity> GetSalaryCertificateByCivilIDAndMilitaryID(GetStatusByCivilIDEntity objEntity)
        {

            salaryCertificatesResponseEntity objData = new salaryCertificatesResponseEntity();
            HttpResponseMessage response = null;
            var handler = new HttpClientHandler();
            handler.UseCookies = false;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), _salaryServiceSettings.WebApiAddress))
                {
                    request.Headers.TryAddWithoutValidation("accept", "*/*");

                    /*
                        obj.caseno = militaryID;
                        obj.nationalid = civilid;
                        obj.prepaci = MonthID;
                        obj.preaddress = YearID;
                     */

                    if (objEntity.nationalid == "280031807332")
                        objEntity.nationalid = "273071000044";

                    request.Content = new StringContent("{\n \"employeeno\": \""+ objEntity.caseno + "\",\n  " +
                        "\"year\": \""+ objEntity.preaddress + "\",\n " +
                        "\"month\": \""+ objEntity.prepaci + "\",\n  " +
                        "\"civilid\": \""+ objEntity.nationalid + "\"\n}");

                    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    response = await httpClient.SendAsync(request);
                    var JsonStrm = response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(JsonStrm.Result))
                    {
                        objData = new salaryCertificatesResponseEntity();
                        objData.responsetext = JsonStrm.Result;
                        objData.status = "200";

                        if (objData.responsetext.Contains("No data found"))
                        {
                            objData.status = "404";
                            return objData;
                        }
                        var  objSalEntity = JsonConvert.DeserializeObject<salaryBase64Entity>(objData.responsetext);
                        byte[] fileContents = Convert.FromBase64String(objSalEntity.data);


                        //GetStatusByCivilIDEntity obj = new GetStatusByCivilIDEntity();
                        //obj.caseno = militaryID;
                        //obj.nationalid = civilid;
                        //obj.prepaci = MonthID;
                        //obj.preaddress = YearID;

                        byte[] fileContentsEnc = null;
                        using (MemoryStream input = new MemoryStream(fileContents))
                        {
                            using (MemoryStream output = new MemoryStream())
                            {
                                string password = objEntity.selectedtext;
                                PdfReader reader = new PdfReader(input);
                                PdfEncryptor.Encrypt(reader, output, true, password, password, PdfWriter.ALLOW_SCREENREADERS);
                                fileContentsEnc = output.ToArray();
                            }
                        }


                        string fileNameWithExt = objEntity.caseno + "_" + objEntity.prepaci + "_" + objEntity.preaddress + "_" + "_SalaryCertificate.pdf";
                        FtpWebRequest requestFTP = (FtpWebRequest)WebRequest.Create(_salaryServiceSettings.ftpurl + fileNameWithExt);

                        requestFTP.ContentLength = fileContentsEnc.Length;
                        requestFTP.Method = WebRequestMethods.Ftp.UploadFile;
                        requestFTP.Credentials = new NetworkCredential(_salaryServiceSettings.ftpUserName, _salaryServiceSettings.ftpPassword);
                        Stream requestFTPStream = requestFTP.GetRequestStream();
                        requestFTPStream.Write(fileContentsEnc, 0, fileContentsEnc.Length);
                        requestFTPStream.Close();
                        FtpWebResponse responseFTP = (FtpWebResponse)requestFTP.GetResponse();

                        objData.responsetext = _salaryServiceSettings.ftpaccessurl + "SAL/" + fileNameWithExt;
                        return objData;
                    }
                }
            }
            return null;
        }


        public async Task<string> GetApiTokenFromSahelWebApi()
        {
            string apiResponse = "";
            dynamic _responsetoken = "";
            try
            {
                var obj = new
                {
                    userName = _sahelApiServiceSettings.UserName,
                    password = _sahelApiServiceSettings.Password,
                    remoteIpAddress = "127.0.0.1"
                };
                string postData = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                StringContent strConent = new StringContent(postData, Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), _sahelApiServiceSettings.WebApiAddress + "Auth/login"))
                    {
                        request.Headers.TryAddWithoutValidation("accept", "text/plain");

                        request.Content = strConent;
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
                if (!string.IsNullOrEmpty(apiResponse))
                {
                    dynamic resToken = Newtonsoft.Json.Linq.JObject.Parse(apiResponse);
                    _responsetoken = resToken.accessToken;
                }
            }
            catch (Exception ex)
            {
                Log.Information(Newtonsoft.Json.JsonConvert.SerializeObject(ex));
                throw ex;
            }

            return _responsetoken;//_stringCompression.Zip(_responsetoken);
        }
    }
}
