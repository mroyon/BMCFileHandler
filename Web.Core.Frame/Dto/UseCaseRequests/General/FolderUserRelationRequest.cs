using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using Web.Core.Frame.Interfaces;
using Web.Core.Frame.RequestResponse.UseCaseResponses;

namespace Web.Core.Frame.RequestResponse.UseCaseRequests
{
    public partial class FolderUserRelationRequest : IUseCaseRequest<FolderUserRelationResponse>
    {
        public folderuserrelationEntity Objfolderuserrelation { get; }
        
        public FolderUserRelationRequest(folderuserrelationEntity objfolderuserrelation)
        {
            Objfolderuserrelation = objfolderuserrelation;
        }
    }
}
