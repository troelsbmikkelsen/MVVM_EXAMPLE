using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_EXAMPLE {
    class ObservableObject : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            //var handler = PropertyChanged;
            //if (handler != null) {
            //    handler(this, new PropertyChangedEventArgs(propertyName));
            //}
        }
    }
}
