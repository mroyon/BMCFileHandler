﻿using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.DataAccessObjects.ExtendedEntities;
using BDO.DataAccessObjects.ExtendedEntities.IQRCodeAuthentication;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;

namespace Web.Core.Frame.Interfaces.Services
{
    public partial interface IHttpClientPACIAuth
    {

        Task<string> LoginToPACIAPIService();

        Task<PACIQRCodeAuthenticationEntity> GetQRCodeFromPACIToAuthenticate(PACIAuthRequestEntity objEntity);

        Task<PACICivilIDAuthenticationEntity> SendAuthRequestToAuthenticate(PACIAuthRequestEntity objEntity);


        Task<string> SendPACINotification(EmailEntity objEntity);

        Task<Payload> GetPACICivilIDInformation(EmailEntity objEntity);


        Task<PACIMainShortProfileResponseEntity> GetPACIMAinCivilIDInformation(EmailEntity objEntity);
    }

}
