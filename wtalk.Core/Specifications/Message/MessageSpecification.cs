namespace Wtalk.Core.Specifications.Message
{
    public class MessageSpecification : BaseSpecification<Core.Entities.Message>
    {
        public MessageSpecification(MessageSpecParams messageSpecParams)
        {
            if (!string.IsNullOrEmpty(messageSpecParams.Sort))
            {
                switch (messageSpecParams.Sort)
                {
                    case "timestampDesc":
                        AddOrderByDescending(e => e.Timestamp);
                    break;
                }
            }

            ApplyPaging(messageSpecParams.PageSize * (messageSpecParams.PageIndex - 1), messageSpecParams.PageSize);

        }
    }
}
