using System.Collections.Generic;
using System.Net;

namespace Oppa.Data.ViewModels
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            this.StatusCode = HttpStatusCode.BadRequest;
            this.ErrorMessages = new List<string>();
            this.Data = null;
        }
        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; }
        public List<string> ErrorMessages { get; set; }
        public bool IsSuccess => this.StatusCode == HttpStatusCode.OK;
    }

    public class ResponseModel<TData>
    {
        public ResponseModel()
        {
            this.StatusCode = HttpStatusCode.BadRequest;
            this.ErrorMessages = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public TData Data { get; set; }
        public List<string> ErrorMessages { get; set; }
        public bool IsSuccess => this.StatusCode == HttpStatusCode.OK;
    }

}
