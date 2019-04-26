using UnityEngine;

namespace Experimental
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CharacterObserverBase<TModel, TObservable> : MonoBehaviour, IObserver<TObservable>, IBind<TModel> 
        where TModel : class
        where TObservable : ICharacter
    {
        protected TModel Model;

        public virtual void Bind(TModel dependency)
        {
            Model = dependency;
        }

        public abstract void Register(TObservable source);
    }
}