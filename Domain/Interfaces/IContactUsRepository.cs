using SCT.Domain.Entities;

namespace SCT.Domain.Interfaces
{
    public interface IContactUsRepository
    {
        Task<UserContactUs> AddUserContactAsync(UserContactUs userContactUs, CancellationToken cancellationToken);
    }
}
