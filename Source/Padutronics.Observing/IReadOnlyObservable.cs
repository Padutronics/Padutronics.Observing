using System;

namespace Padutronics.Observing;

public interface IReadOnlyObservable<T>
{
    bool HasValue { get; }
    T? Value { get; }

    event EventHandler<ValueChangedEventArgs<T?>>? ValueChanged;
}