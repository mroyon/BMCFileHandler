using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.RequestResponse.UseCaseRequests
{
    public partial class TranTinyURLAccessInfoRequest : IUseCaseRequest<TranTinyURLAccessInfoResponse>
    {
        public trantinyurlaccessinfoEntity Objtrantinyurlaccessinfo { get; }
        
        public TranTinyURLAccessInfoRequest(trantinyurlaccessinfoEntity objtrantinyurlaccessinfo)
        {
            Objtrantinyurlaccessinfo = objtrantinyurlaccessinfo;
        }
    }
}
