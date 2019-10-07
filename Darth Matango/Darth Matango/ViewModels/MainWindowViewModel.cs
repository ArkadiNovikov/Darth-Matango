using PropertyChanged;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using Reactive.Bindings;
using Darth_Matango.Models;
using Reactive.Bindings.Extensions;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Darth_Matango.ViewModels
{

    [DoNotNotify]
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly SaveDataRoot _saveData;
        public ReadOnlyReactiveProperty<bool> Loaded { get; set; }
        public ReactiveProperty<int> Currency { get; set; }
        public ReactiveProperty<int> SlotIndex { get; set; }
        public ReadOnlyReactiveCollection<SaveSlot> SlotList { get; set; }
        public ReactiveCommand FileOpenCommand { get; set; }

        public MainWindowViewModel(SaveDataRoot sdr)
        {
            this._saveData = sdr;

            SlotIndex = new ReactiveProperty<int>();
            Loaded = sdr.ObserveProperty(x => x.IsLoaded).ToReadOnlyReactiveProperty();
            Currency = sdr.ObserveProperty(x => (int)x.SaveData[0].Currency).ToReactiveProperty().AddTo(this.CmpDisposable);
            SlotList = sdr.SaveData.ToReadOnlyReactiveCollection().AddTo(this.CmpDisposable);
            FileOpenCommand = new ReactiveCommand();
            FileOpenCommand.Subscribe(x => FileOpen()).AddTo(this.CmpDisposable);

            //_saveData.Load(@"Q:\sd3save_editor\Seiken3.srm");
        }

        public void FileOpen()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                Console.WriteLine(openFileDialog.FileName);
                _saveData.Load(openFileDialog.FileName);
            }
        }
    }
}
