using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.ObserverInterfaces
{
    public interface IFailObservable
    {
        void AddFailObserver(IFailObserver observer);
        void RemoveFailObserver(IFailObserver observer);
        void RemoveAllFailObservers();
        void NotifyFailObservers();
    }
}
