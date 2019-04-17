using App.Characters.Models;
using UnityEngine;
using UnityEngine.UI;

namespace App.Characters.Views
{
    public class CharacterView : MonoBehaviour
    {
        private CharacterStatus _status;
        public Text Hp;
        public Image HpFill;

        public void Init(CharacterStatus status)
        {
            _status = status;
            _status.OnHpChanged += SetHp;

            SetHp(_status.Hp);
        }

        private void SetHp(int hp)
        {
            Hp.text = $"Health: {hp}";
            HpFill.fillAmount = _status.Hp01;
        }

        private void OnDestroy()
        {
            _status.OnHpChanged -= SetHp;
        }
    }
}