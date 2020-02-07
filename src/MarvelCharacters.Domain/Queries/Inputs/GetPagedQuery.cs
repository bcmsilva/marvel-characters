using Flunt.Notifications;
using Flunt.Validations;
using MarvelCharacters.Shared.Request;

namespace MarvelCharacters.Domain.Queries.Inputs
{
    public class GetPagedQuery : Notifiable, IRequest
    {
        public GetPagedQuery()
        {
            Limit = 20;
        }

        public int Limit { get; set; }
        public int OffSet { get; set; }

        public virtual bool Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsLowerOrEqualsThan(Limit, 100, "Limit", "Limit should be lower or equals to 100")
                .IsGreaterOrEqualsThan(Limit, 0, "Limit", "Limit should be greater or equals to 0")
                .IsGreaterOrEqualsThan(OffSet, 0, "OffSet", "OffSet should be greater or equals to 0"));

            return Valid;
        }
    }
}
