using System;

namespace ObserverTest
{
    public class ConcreteObserver : IObserver
    {
        private ConcreteSubject subject;
        private int state;

        public ConcreteObserver(ConcreteSubject subject)
        {
            this.subject = subject;
        }
        
        public void Update()
        {
            state = subject.GetState();
            Console.WriteLine("Stuff");
        }
    }
}
