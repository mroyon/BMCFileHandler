using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.DataAccessObjects.ExtendedEntities;
using BDO.DataAccessObjects.ExtendedEntities.IQRCodeAuthentication;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;

namespace Web.Core.Frame.Interfaces.Services
{
    public partial interface IHttpClientSahel
    {

        Task<string> LoginToSahelAPIService();

        Task<sahelNotificationResponseEntity> SendNotificationToSahel(sahelNotificationRequestEntity objEntity);


        Task<List<sahelNotificationResponseEntity>> SendNotificationToSahelList(sahelNotificationRequestListEntity objEntity);


        Task<List<sahelNotificationResponseEntity>> SendNotificationToSahelBulk(sahelNotificationRequestListEntity objEntity);


    }

}
