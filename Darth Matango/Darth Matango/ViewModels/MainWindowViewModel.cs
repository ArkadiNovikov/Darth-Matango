using PropertyChanged;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Reactive.Bindings;

namespace Darth_Matango.ViewModels
{

    [DoNotNotify]
    public class MainWindowViewModel : BindableBase
    {
        public ReactiveProperty<bool> Loaded { get; set; } = new ReactiveProperty<bool>();

        public MainWindowViewModel()
        {

        }
    }
}
