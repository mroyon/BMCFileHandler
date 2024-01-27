using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.Interfaces.UseCases
{
    public partial interface ITranTinyURLDataUseCase : IUseCaseRequestHandler<TranTinyURLDataRequest, TranTinyURLDataResponse>
    {
        Task<bool> Save(TranTinyURLDataRequest message, ICRUDRequestHandler<TranTinyURLDataResponse> outputPort);

        Task<bool> Update(TranTinyURLDataRequest message, ICRUDRequestHandler<TranTinyURLDataResponse> outputPort);

        Task<bool> Delete(TranTinyURLDataRequest message, ICRUDRequestHandler<TranTinyURLDataResponse> outputPort);


        Task<bool> GetSingle(TranTinyURLDataRequest message, ICRUDRequestHandler<TranTinyURLDataResponse> outputPort);

        Task<bool> GetAll(TranTinyURLDataRequest message, ICRUDRequestHandler<TranTinyURLDataResponse> outputPort);


        Task<bool> GetAllPaged(TranTinyURLDataRequest message, ICRUDRequestHandler<TranTinyURLDataResponse> outputPort);

        Task<bool> GetListView(TranTinyURLDataRequest message, ICRUDRequestHandler<TranTinyURLDataResponse> outputPort);
        
        
            
    }
}
