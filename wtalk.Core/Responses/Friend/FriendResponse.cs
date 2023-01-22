

namespace Wtalk.Core.Responses.Friend
{
    public class FriendResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Avatar { get; set; }
        public bool Online { get; set; }
        public bool Favourite { get; set; }
    }
}
