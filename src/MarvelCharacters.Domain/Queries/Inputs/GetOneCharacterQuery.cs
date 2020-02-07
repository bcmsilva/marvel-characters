using Flunt.Notifications;
using Flunt.Validations;
using MarvelCharacters.Shared.Request;

namespace MarvelCharacters.Domain.Queries.Inputs
{
    public class GetOneCharacterQuery : Notifiable, IRequest
    {
        public int IdCharacter { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(IdCharacter, 0, "IdCharacter", "IdCharacter should be greater than 0"));

            return Valid;
        }
    }
}
