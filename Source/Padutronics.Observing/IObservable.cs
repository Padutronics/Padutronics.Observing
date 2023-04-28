namespace Padutronics.Observing;

public interface IObservable<T> : IReadOnlyObservable<T>
{
    new T? Value { get; set; }
}