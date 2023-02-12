using Wtalk.Core.Helpers;

namespace Wtalk.Core.Responses.Message
{
    public class GetMessageListResponse
    {
        public Pagination<MessageResponse> Pagination { get; set; }
    }
}
