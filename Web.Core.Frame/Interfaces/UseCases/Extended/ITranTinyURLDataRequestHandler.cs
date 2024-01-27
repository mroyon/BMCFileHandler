using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.Interfaces
{
    public interface ITranTinyURLDataRequestHandler<in TranTinyURLDataResponse>
    {
        void customOutputProcess(TranTinyURLDataResponse response);
    }
}
