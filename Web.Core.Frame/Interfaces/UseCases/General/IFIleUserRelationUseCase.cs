using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.Interfaces.UseCases
{
    public partial interface IFIleUserRelationUseCase : IUseCaseRequestHandler<FIleUserRelationRequest, FIleUserRelationResponse>
    {
        Task<bool> Save(FIleUserRelationRequest message, ICRUDRequestHandler<FIleUserRelationResponse> outputPort);

        Task<bool> Update(FIleUserRelationRequest message, ICRUDRequestHandler<FIleUserRelationResponse> outputPort);

        Task<bool> Delete(FIleUserRelationRequest message, ICRUDRequestHandler<FIleUserRelationResponse> outputPort);


        Task<bool> GetSingle(FIleUserRelationRequest message, ICRUDRequestHandler<FIleUserRelationResponse> outputPort);

        Task<bool> GetAll(FIleUserRelationRequest message, ICRUDRequestHandler<FIleUserRelationResponse> outputPort);


        Task<bool> GetAllPaged(FIleUserRelationRequest message, ICRUDRequestHandler<FIleUserRelationResponse> outputPort);

        Task<bool> GetListView(FIleUserRelationRequest message, ICRUDRequestHandler<FIleUserRelationResponse> outputPort);
        
        
            
    }
}
