using Padutronics.Diagnostics.Debugging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Padutronics.Observing;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class ObservableValueHolder<T> : IObservable<T>
    where T : IEquatable<T>
{
    private T? value;

    public ObservableValueHolder() :
        this(default)
    {
    }

    public ObservableValueHolder(T? value)
    {
        Value = value;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"{Value}";

    public bool HasValue => Value is not null;

    public T? Value
    {
        get => value;
        set
        {
            if (!EqualityComparer<T>.Default.Equals(this.value, value))
            {
                var e = new ValueChangedEventArgs<T?>(oldValue: this.value, newValue: value);

                this.value = value;

                OnValueChanged(e);
            }
        }
    }

    public event EventHandler<ValueChangedEventArgs<T?>>? ValueChanged;

    private void OnValueChanged(ValueChangedEventArgs<T?> e)
    {
        ValueChanged?.Invoke(this, e);
    }
}