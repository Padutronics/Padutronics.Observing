using System;

namespace Padutronics.Observing;

public sealed class ValueChangedEventArgs<T> : EventArgs
{
    public ValueChangedEventArgs(T oldValue, T newValue)
    {
        NewValue = newValue;
        OldValue = oldValue;
    }

    public T NewValue { get; }

    public T OldValue { get; }
}