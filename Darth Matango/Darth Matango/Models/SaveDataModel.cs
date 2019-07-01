using PropertyChanged;
using SD3IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Darth_Matango.Models
{
    [AddINotifyPropertyChangedInterface]
    public class SaveDataRoot : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IIO _io = new SD3IO.SD3IO();

    }

    public class SaveSlot : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>();
        public ItemStorage Item { get; set; } = new ItemStorage();
        public uint Currency { get; set; }

    }

    public class Character : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<byte> Name { get; set; } = new ObservableCollection<byte>();
        public CharacterStatus Status { get; set; } = new CharacterStatus();
        public CharacterEquip Equip { get; set; } = new CharacterEquip();
        public ObservableCollection<Skill> Skills { get; set; } = new ObservableCollection<Skill>();

    }

    public class CharacterStatus : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public uint Level { get; set; }
        public uint Exp { get; set; }
        public uint CurrentHP { get; set; }
        public uint CurrentMP { get; set; }
        public uint MaxHP { get; set; }
        public uint MaxMP { get; set; }
        public uint Str { get; set; }
        public uint Agi { get; set; }
        public uint Vit { get; set; }
        public uint Int { get; set; }
        public uint Spr { get; set; }
        public uint Luk { get; set; }

    }

    public class CharacterEquip : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public uint Weapon { get; set; }
        public uint Helm { get; set; }
        public uint Armor { get; set; }
        public uint Ring { get; set; }
        public uint Shield { get; set; }

    }

    public class Skill : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public uint SkillKind { get; set; }
        public uint Target { get; set; }

    }



    public class ItemStorage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Item> Inventory { get; set; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Stash { get; set; } = new ObservableCollection<Item>();

    }

    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public uint ItemKind { get; set; }
        public uint Count { get; set; }

    }
}
