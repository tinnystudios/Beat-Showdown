using System;

namespace App.Characters.Models
{
    public class CharacterStatus
    {
        public event Action<int> OnHpChanged;

        public CharacterStatus(int hp, int maxHp)
        {
            Hp = hp;
            MaxHp = maxHp;
        }

        public int Hp { get; private set; }
        public int MaxHp { get; private set; }

        /// <summary>
        /// Returns the current HP as a percentage of MaxHp ranging from 0 to 1
        /// </summary>
        public float Hp01 => Hp / (float)MaxHp;

        public void DeductHp(int amount)
        {
            Hp -= amount;
            OnHpChanged?.Invoke(Hp);
        }
    }
}