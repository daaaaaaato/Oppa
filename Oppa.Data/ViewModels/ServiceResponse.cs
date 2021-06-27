using System.Collections.Generic;
using System.Linq;

namespace Oppa.Data.ViewModels
{
    public class ServiceResponse
    {
        public ServiceResponse()
        {
            Errors = new List<string>();
        }
        public ICollection<string> Errors { get; set; }
        public bool IsSuccess => !Errors.Any();
    }
}
