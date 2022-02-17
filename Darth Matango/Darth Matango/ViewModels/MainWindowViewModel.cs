using PropertyChanged;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using Reactive.Bindings;
using DarthMatango.Models;
using Reactive.Bindings.Extensions;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Text;
using System.Collections.ObjectModel;

namespace DarthMatango.ViewModels
{

    [DoNotNotify]
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly SaveDataRoot _saveData;
        public ReadOnlyReactiveProperty<bool> Loaded { get; set; }
        public ReactiveProperty<int> Currency { get; set; }
        public ReactiveProperty<int> TimePlayed { get; set; }
        public ReactiveProperty<int> SlotIndex { get; set; }
        public ReadOnlyReactiveCollection<SaveSlot> SlotList { get; set; }
        public ReadOnlyReactiveCollection<Location> Locations { get; private set; }
        public ReactiveCommand FileOpenCommand { get; set; }

        public MainWindowViewModel(SaveDataRoot sdr)
        {
            this._saveData = sdr;

            SlotIndex = new ReactiveProperty<int>();
            Loaded = _saveData.ObserveProperty(x => x.IsLoaded).ToReadOnlyReactiveProperty();
            Currency = _saveData.ObserveProperty(x => (int)x.SaveData[SlotIndex.Value].Currency).ToReactiveProperty().AddTo(this.CmpDisposable);
            TimePlayed = _saveData.ObserveProperty(x => x.SaveData[SlotIndex.Value].TimePlayed).ToReactiveProperty().AddTo(this.CmpDisposable);
            SlotList = _saveData.SaveData.ToReadOnlyReactiveCollection().AddTo(this.CmpDisposable);
            FileOpenCommand = new ReactiveCommand();
            FileOpenCommand.Subscribe(x => FileOpen()).AddTo(this.CmpDisposable);

            //_saveData.Load(@"Q:\sd3save_editor\Seiken3.srm");

            var locations = LocationsRootObject.GenerateRootObject();
            Locations = new ObservableCollection<Location>(locations.Locations).ToReadOnlyReactiveCollection().AddTo(this.CmpDisposable);
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
