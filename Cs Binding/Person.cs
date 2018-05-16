﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Binding
{
    // This class implements INotifyPropertyChanged
    // to support one-way and two-way bindings
    // (such that the UI element updates when the source
    // has been changed dynamically)
    public class Person : INotifyPropertyChanged
    {
        private string name;
        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;

        public Person()
        {
        }

        public Person(string value)
        {
            this.name = value;
        }

        public string PersonName
        {
            get { return name; }
            set
            {
                name = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("PersonName");
            }
        }

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
