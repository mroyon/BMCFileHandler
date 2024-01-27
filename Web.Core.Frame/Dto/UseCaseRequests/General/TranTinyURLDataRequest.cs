using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.RequestResponse.UseCaseRequests
{
    public partial class TranTinyURLDataRequest : IUseCaseRequest<TranTinyURLDataResponse>
    {
        public trantinyurldataEntity Objtrantinyurldata { get; }
        
        public TranTinyURLDataRequest(trantinyurldataEntity objtrantinyurldata)
        {
            Objtrantinyurldata = objtrantinyurldata;
        }
    }
}
