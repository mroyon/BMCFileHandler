using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.Interfaces.UseCases
{
    public partial interface ITranTinyURLDataUseCase 
    {
        Task<bool> SetActualURLByTinyURL(TranTinyURLDataRequest message, ITranTinyURLDataRequestHandler<TranTinyURLDataResponse> outputPort);

        Task<bool> GetActualURLByTinyURL(TranTinyURLDataRequest message, ITranTinyURLDataRequestHandler<TranTinyURLDataResponse> outputPort);
    }
}
