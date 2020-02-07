using Flunt.Validations;
using MarvelCharacters.Shared.Request;
using System;

namespace MarvelCharacters.Domain.Queries.Inputs
{
    public class GetSeriesByIdCharacterQuery : GetPagedQuery, IRequest
    {
        public int IdCharacter { get; set; }
        public string Title { get; set; }
        public string TitleStartsWith { get; set; }
        public DateTime? ModifiedSince { get; set; }

        public override bool Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(IdCharacter, 0, "IdCharacter", "IdCharacter should be greater than 0"));

            return base.Validate();
        }
    }
}
