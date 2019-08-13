namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Models.BattleFields;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepository;
        private ICardRepository cardRepository;
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;
        private IBattleField battleField;
        public ManagerController()
        {
            playerRepository = new PlayerRepository();
            cardRepository = new CardRepository();
            playerFactory = new PlayerFactory();
            cardFactory = new CardFactory();
            battleField = new BattleField();

        }

        public string AddPlayer(string type, string username)
        {
            playerRepository.Add(playerFactory.CreatePlayer(type, username));
            return String.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            cardRepository.Add(cardFactory.CreateCard(type, name));
            return String.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRepository.Find(username);
            var card = this.cardRepository.Find(cardName);
            player.CardRepository.Add(card);
            return String.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            battleField.Fight(playerRepository.Find(attackUser), playerRepository.Find(enemyUser));
            return String.Format(ConstantMessages.FightInfo, playerRepository.Find(attackUser).Health, playerRepository.Find(enemyUser).Health);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach(IPlayer player in playerRepository.Players)
            {
                sb.AppendLine(String.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Count));
                foreach (ICard card in player.CardRepository.Cards)
                    sb.AppendLine(String.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                sb.AppendLine(ConstantMessages.DefaultReportSeparator);

            }
            return sb.ToString().Trim();
        }
    }
}
