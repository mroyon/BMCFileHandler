using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.RequestResponse.UseCaseRequests
{
    public partial class FolderStructureRequest : IUseCaseRequest<FolderStructureResponse>
    {
        public folderstructureEntity Objfolderstructure { get; }
        
        public FolderStructureRequest(folderstructureEntity objfolderstructure)
        {
            Objfolderstructure = objfolderstructure;
        }
    }
}
