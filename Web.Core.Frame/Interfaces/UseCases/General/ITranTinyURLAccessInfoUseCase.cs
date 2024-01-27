using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.Interfaces.UseCases
{
    public partial interface ITranTinyURLAccessInfoUseCase : IUseCaseRequestHandler<TranTinyURLAccessInfoRequest, TranTinyURLAccessInfoResponse>
    {
        Task<bool> Save(TranTinyURLAccessInfoRequest message, ICRUDRequestHandler<TranTinyURLAccessInfoResponse> outputPort);

        Task<bool> Update(TranTinyURLAccessInfoRequest message, ICRUDRequestHandler<TranTinyURLAccessInfoResponse> outputPort);

        Task<bool> Delete(TranTinyURLAccessInfoRequest message, ICRUDRequestHandler<TranTinyURLAccessInfoResponse> outputPort);


        Task<bool> GetSingle(TranTinyURLAccessInfoRequest message, ICRUDRequestHandler<TranTinyURLAccessInfoResponse> outputPort);

        Task<bool> GetAll(TranTinyURLAccessInfoRequest message, ICRUDRequestHandler<TranTinyURLAccessInfoResponse> outputPort);


        Task<bool> GetAllPaged(TranTinyURLAccessInfoRequest message, ICRUDRequestHandler<TranTinyURLAccessInfoResponse> outputPort);

        Task<bool> GetListView(TranTinyURLAccessInfoRequest message, ICRUDRequestHandler<TranTinyURLAccessInfoResponse> outputPort);
        
        
            
    }
}
