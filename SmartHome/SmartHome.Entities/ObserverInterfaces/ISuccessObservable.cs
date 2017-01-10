using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Entities.ObserverInterfaces
{
    public interface ISuccessObservable
    {
        void AddSuccessObserver(ISuccessObserver observer);
        void RemoveSuccessObserver(ISuccessObserver observer);
        void RemoveAllSuccessObservers();
        void NotifySuccessObservers();
    }
}
