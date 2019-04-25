using System;

namespace App.Characters.Models
{
    public class CharacterStatus : ICharacterStatus
    {
        public Action<int> OnHpChanged { get;set; }

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

        public void AddHp(int amount)
        {
            Hp += amount;
            OnHpChanged?.Invoke(Hp);
        }
    }

    public interface ICharacterStatus
    {
        Action<int> OnHpChanged { get; set; }
        float Hp01 { get; }
        int Hp { get; }
        int MaxHp { get; }
        void AddHp(int amount);
        void DeductHp(int amount);
    }
}