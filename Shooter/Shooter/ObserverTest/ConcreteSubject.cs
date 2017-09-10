using System.Collections.Generic;

namespace ObserverTest
{
    public class ConcreteSubject : ISubject
    {
        private int state;
        private IList<IObserver> observers;

        public ConcreteSubject()
        {
            observers = new List<IObserver>();
        }

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }

        public int GetState()
        {
            return state;
        }

        public void SetState(int state)
        {
            this.state = state;
        }
    }
}
