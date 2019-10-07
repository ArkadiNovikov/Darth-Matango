using Prism.Mvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Text;

namespace Darth_Matango.ViewModels
{
    [DoNotNotify]
    public abstract class ViewModelBase : BindableBase, IDisposable
    {
        protected CompositeDisposable CmpDisposable { get; private set; } = new CompositeDisposable();

        public void Dispose()
        {
            this.CmpDisposable.Dispose();
        }
    }
}
