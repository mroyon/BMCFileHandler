using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.Interfaces.UseCases
{
    public partial interface IFolderStructureUseCase : IUseCaseRequestHandler<FolderStructureRequest, FolderStructureResponse>
    {
        Task<bool> Save(FolderStructureRequest message, ICRUDRequestHandler<FolderStructureResponse> outputPort);

        Task<bool> Update(FolderStructureRequest message, ICRUDRequestHandler<FolderStructureResponse> outputPort);

        Task<bool> Delete(FolderStructureRequest message, ICRUDRequestHandler<FolderStructureResponse> outputPort);


        Task<bool> GetSingle(FolderStructureRequest message, ICRUDRequestHandler<FolderStructureResponse> outputPort);

        Task<bool> GetAll(FolderStructureRequest message, ICRUDRequestHandler<FolderStructureResponse> outputPort);


        Task<bool> GetAllPaged(FolderStructureRequest message, ICRUDRequestHandler<FolderStructureResponse> outputPort);

        Task<bool> GetListView(FolderStructureRequest message, ICRUDRequestHandler<FolderStructureResponse> outputPort);
        
        
            
    }
}
