using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Common
{
    public static class ExceptionMessages
    {
        public const string NullOrEmptyUsername = "Player's username cannot be null or an empty string. ";
        public const string HealthBonusBellowZero = "Player's health bonus cannot be less than zero. ";
        public const string DamageBellowZero = "Damage points cannot be less than zero.";

        public const string CardNullOrEmpty = "Card's name cannot be null or an empty string.";
        public const string CardDmgBellow0 = "Card's damage points cannot be less than zero.";
        public const string CardHpBellow0 = "Card's HP cannot be less than zero.";

        public const string BFDeadPlayer = "Player is dead!";

        public const string CRCardNull = "Card cannot be null!";
        public const string CRCardPresent = "Card {0} already exists!";

        public const string PRNullPlayer = "Player cannot be null";
        public const string PRexists ="Player {0} already exists!";
    }
}
