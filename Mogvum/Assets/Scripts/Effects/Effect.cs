using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Assets.Scripts.Effects
{
    /// <summary>
    /// This is a marker interface indicating the type is a valid effect source.
    /// </summary>
    public interface IEffectSource { }

    /// <summary>
    /// Indicates that a type has a collection of effects. All of which have the same target type.
    /// </summary>
    /// <typeparam name="T">The effect target type.</typeparam>
    public interface IEffectTarget<T> where T : IEffectTarget<T>
    {
        ICollection<IEffect<T>> Effects { get; set; }
        void AddEffect(IEffect<T> effect);
        void RemoveEffect(IEffect<T> effect);
    }

    /// <summary>
    /// Provides functionality of an effect.
    /// </summary>
    public interface IEffect<T>
    {
        IEffectSource Source { get; set; }
        T Target { get; set; }
        bool IsStackable { get; }
        void Validate();
        void Apply();
        void UnApply();
    }

    /// <summary>
    /// Abstract class for more specific effects to inherit from.
    /// </summary>
    /// <typeparam name="TTarget">Any type that implements IEffectTarget of its own type.</typeparam>
    public abstract class Effect<TTarget> : IEffect<TTarget>
        where TTarget : IEffectTarget<TTarget>
    {
        public IEffectSource Source { get; set; }
        public TTarget Target { get; set; }
        public bool IsStackable { get; private set; }
        public ICollection<Func<bool>> Conditions { get; set; }
        public Expression Expression { get; set; }

        protected Effect(IEffectSource source, TTarget target, bool isStackable = true)
        {
            Source = source;
            Target = target;
            IsStackable = isStackable;
            Conditions = new List<Func<bool>>();
        }

        /// <summary>
        /// Remove the effect if it is no longer valid.
        /// </summary>
        public void Validate()
        {
            if(Conditions.Any(x => !x.Invoke())) Target.RemoveEffect(this);
        }

        public void Apply()
        {
            throw new NotImplementedException();
        }

        public void UnApply()
        {
            throw new NotImplementedException();
        }
    }
}
