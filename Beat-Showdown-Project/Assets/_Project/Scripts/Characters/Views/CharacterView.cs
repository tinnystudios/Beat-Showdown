using App.Characters.Models;
using UnityEngine;
using UnityEngine.UI;

namespace App.Characters.Views
{
    public class CharacterView : MonoBehaviour
    {
        private CharacterStatus _status;
        public Text Hp;

        public void Init(CharacterStatus status)
        {
            _status = status;
            _status.OnHpChanged += SetHp;
        }

        private void SetHp(int hp)
        {
            Hp.text = $"Health: {hp}";
        }
    }
}