using System.Threading.Tasks;
using Web.Core.Frame.RequestResponse.UseCaseRequests;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.Interfaces.UseCases
{
    public partial interface IFileStructureUseCase : IUseCaseRequestHandler<FileStructureRequest, FileStructureResponse>
    {
        Task<bool> Save(FileStructureRequest message, ICRUDRequestHandler<FileStructureResponse> outputPort);

        Task<bool> Update(FileStructureRequest message, ICRUDRequestHandler<FileStructureResponse> outputPort);

        Task<bool> Delete(FileStructureRequest message, ICRUDRequestHandler<FileStructureResponse> outputPort);


        Task<bool> GetSingle(FileStructureRequest message, ICRUDRequestHandler<FileStructureResponse> outputPort);

        Task<bool> GetAll(FileStructureRequest message, ICRUDRequestHandler<FileStructureResponse> outputPort);


        Task<bool> GetAllPaged(FileStructureRequest message, ICRUDRequestHandler<FileStructureResponse> outputPort);

        Task<bool> GetListView(FileStructureRequest message, ICRUDRequestHandler<FileStructureResponse> outputPort);
        
        
            
    }
}
