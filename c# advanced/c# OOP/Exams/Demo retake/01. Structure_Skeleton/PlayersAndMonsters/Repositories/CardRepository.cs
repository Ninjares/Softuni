using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System.Linq;
using PlayersAndMonsters.Common;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cards = new List<ICard>();
        public int Count => cards.Count;

        public IReadOnlyCollection<ICard> Cards => cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null) throw new ArgumentException(ExceptionMessages.CRCardNull);
            else if (cards.Any(x => x.Name == card.Name)) throw new ArgumentException(String.Format(ExceptionMessages.CRCardPresent, card.Name));
            else  cards.Add(card);
        }

        public ICard Find(string name)
        {
            return cards.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (card == null) throw new ArgumentException(ExceptionMessages.CRCardNull);
            return cards.Remove(card);
        }
    }
}
