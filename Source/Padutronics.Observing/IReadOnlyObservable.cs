using System;

namespace Padutronics.Observing;

public interface IReadOnlyObservable<T>
{
    T? Value { get; }

    event EventHandler<ValueChangedEventArgs<T?>>? ValueChanged;
}