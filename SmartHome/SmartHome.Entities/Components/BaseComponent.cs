using SmartHome.Entities.Devices;
using SmartHome.Entities.ObserverInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.Components
{    
    public abstract class BaseComponent : ISuccessObservable, IFailObservable
    {
        private ICollection<ISuccessObserver> successObservers = new List<ISuccessObserver>();

        private ICollection<IFailObserver> failObservers = new List<IFailObserver>();

        public int Id { get; set; }

        public string Name { get; set; }            

        public void AddSuccessObserver(ISuccessObserver observer)
        {
            successObservers.Add(observer);
        }

        public void RemoveSuccessObserver(ISuccessObserver observer)
        {
            successObservers.Remove(observer);
        }

        public void NotifySuccessObservers()
        {
            foreach(ISuccessObserver observer in successObservers)
            {
                observer.SuccessUpdate();
            }
        }

        public void AddFailObserver(IFailObserver observer)
        {
            failObservers.Add(observer);
        }

        public void RemoveFailObserver(IFailObserver observer)
        {
            failObservers.Remove(observer);
        }

        public void NotifyFailObservers()
        {
            foreach(IFailObserver observer in failObservers)
            {
                observer.FailUpdate();
            }
        }

        public void RemoveAllSuccessObservers()
        {
            successObservers.Clear();
        }

        public void RemoveAllFailObservers()
        {
            failObservers.Clear();
        }
    }
}
