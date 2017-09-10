using System.Collections.Generic;

namespace ObserverTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var subject = new ConcreteSubject();

            var observers = new List<IObserver>
            {
                new ConcreteObserver(subject),
                new ConcreteObserver(subject),
                new ConcreteObserver(subject)
            };

            subject.Attach(observers[0]);
            subject.Attach(observers[1]);
            subject.Attach(observers[2]);

            subject.SetState(12);

            subject.Notify();
            subject.Notify();
        }
    }
}
