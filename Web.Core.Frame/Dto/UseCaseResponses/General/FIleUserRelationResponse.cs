using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using System.Collections.Generic;
using Web.Core.Frame.Dto;
using Web.Core.Frame.Interfaces;

namespace Web.Core.Frame.RequestResponse.UseCaseResponses
{
    public partial class FIleUserRelationResponse : UseCaseResponseMessage
    {
        public fileuserrelationEntity _fileuserrelation_ { get; }

        public IEnumerable<fileuserrelationEntity> _fileuserrelation_List { get; }

        public Error Errors { get; }
        
        public AjaxResponse _ajaxresponse { get; }
        
        
        
        public FIleUserRelationResponse(bool success = false, string message = null, Error errors = null) : base(success, message)
        {
            Errors = errors;
        }

        public FIleUserRelationResponse(IEnumerable<fileuserrelationEntity> fileuserrelation_List, bool success = false, string message = null) : base(success, message)
        {
            _fileuserrelation_List = fileuserrelation_List;
        }
        
        public FIleUserRelationResponse(fileuserrelationEntity fileuserrelation_, bool success = false, string message = null) : base(success, message)
        {
            _fileuserrelation_ = fileuserrelation_;
        }

        public FIleUserRelationResponse(AjaxResponse ajaxresponse, bool success = false, string message = null) : base(success, message)
        {
            _ajaxresponse = ajaxresponse;
        }




    }
}
