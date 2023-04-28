using System;

namespace Padutronics.Observing;

public interface IObservable<T>
{
    T? Value { get; }

    event EventHandler<ValueChangedEventArgs<T?>>? ValueChanged;
}