using UnityEngine;

namespace Experimental
{
    public abstract class CharacterComponentBase<TModel, TCharacter> : MonoBehaviour, ICharacterComponent<TCharacter>, IBind<TModel> 
        where TModel : class
        where TCharacter : ICharacter
    {
        protected TModel Model;

        public virtual void Bind(TModel dependency)
        {
            Model = dependency;
        }

        public abstract void Activate(TCharacter source);
    }
}