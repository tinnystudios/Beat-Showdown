using System;

namespace App.Characters.Models
{
    public class CharacterStatus
    {
        public event Action<int> OnHpChanged;

        public CharacterStatus(int hp, int maxHp)
        {
            Hp = hp;
        }

        public int Hp { get; private set; }

        public void DeductHp(int amount)
        {
            Hp -= amount;
            OnHpChanged?.Invoke(Hp);
        }
    }
}