using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using System.Collections.Generic;
using Web.Core.Frame.Dto;
using Web.Core.Frame.Interfaces;

namespace Web.Core.Frame.RequestResponse.UseCaseResponses
{
    public partial class FolderUserRelationResponse : UseCaseResponseMessage
    {
        public folderuserrelationEntity _folderuserrelation_ { get; }

        public IEnumerable<folderuserrelationEntity> _folderuserrelation_List { get; }

        public Error Errors { get; }
        
        public AjaxResponse _ajaxresponse { get; }
        
        
        
        public FolderUserRelationResponse(bool success = false, string message = null, Error errors = null) : base(success, message)
        {
            Errors = errors;
        }

        public FolderUserRelationResponse(IEnumerable<folderuserrelationEntity> folderuserrelation_List, bool success = false, string message = null) : base(success, message)
        {
            _folderuserrelation_List = folderuserrelation_List;
        }
        
        public FolderUserRelationResponse(folderuserrelationEntity folderuserrelation_, bool success = false, string message = null) : base(success, message)
        {
            _folderuserrelation_ = folderuserrelation_;
        }

        public FolderUserRelationResponse(AjaxResponse ajaxresponse, bool success = false, string message = null) : base(success, message)
        {
            _ajaxresponse = ajaxresponse;
        }




    }
}
