using BDO.Core.DataAccessObjects.ExtendedEntities;
using BDO.Core.DataAccessObjects.Models;
using BDO.Core.DataAccessObjects.SecurityModels;
using System.Collections.Generic;
using Web.Core.Frame.Dto;
using Web.Core.Frame.Interfaces;

namespace Web.Core.Frame.RequestResponse.UseCaseResponses
{
    public partial class TranTinyURLDataResponse : UseCaseResponseMessage
    {
        public trantinyurldataEntity _trantinyurldata_ { get; }

        public IEnumerable<trantinyurldataEntity> _trantinyurldata_List { get; }

        public Error Errors { get; }
        
        public AjaxResponse _ajaxresponse { get; }
        
        
        
        public TranTinyURLDataResponse(bool success = false, string message = null, Error errors = null) : base(success, message)
        {
            Errors = errors;
        }

        public TranTinyURLDataResponse(IEnumerable<trantinyurldataEntity> trantinyurldata_List, bool success = false, string message = null) : base(success, message)
        {
            _trantinyurldata_List = trantinyurldata_List;
        }
        
        public TranTinyURLDataResponse(trantinyurldataEntity trantinyurldata_, bool success = false, string message = null) : base(success, message)
        {
            _trantinyurldata_ = trantinyurldata_;
        }

        public TranTinyURLDataResponse(AjaxResponse ajaxresponse, bool success = false, string message = null) : base(success, message)
        {
            _ajaxresponse = ajaxresponse;
        }




    }
}
