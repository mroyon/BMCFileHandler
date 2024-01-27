using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.Interfaces.UseCases
{
    public partial interface IFolderUserRelationUseCase : IUseCaseRequestHandler<FolderUserRelationRequest, FolderUserRelationResponse>
    {
        Task<bool> Save(FolderUserRelationRequest message, ICRUDRequestHandler<FolderUserRelationResponse> outputPort);

        Task<bool> Update(FolderUserRelationRequest message, ICRUDRequestHandler<FolderUserRelationResponse> outputPort);

        Task<bool> Delete(FolderUserRelationRequest message, ICRUDRequestHandler<FolderUserRelationResponse> outputPort);


        Task<bool> GetSingle(FolderUserRelationRequest message, ICRUDRequestHandler<FolderUserRelationResponse> outputPort);

        Task<bool> GetAll(FolderUserRelationRequest message, ICRUDRequestHandler<FolderUserRelationResponse> outputPort);


        Task<bool> GetAllPaged(FolderUserRelationRequest message, ICRUDRequestHandler<FolderUserRelationResponse> outputPort);

        Task<bool> GetListView(FolderUserRelationRequest message, ICRUDRequestHandler<FolderUserRelationResponse> outputPort);
        
        
            
    }
}
