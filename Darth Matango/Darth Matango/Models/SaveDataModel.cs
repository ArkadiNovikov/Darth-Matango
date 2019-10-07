using PropertyChanged;
using SD3IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace Darth_Matango.Models
{
    [AddINotifyPropertyChangedInterface]
    public class SaveDataRoot : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IIO _io = new SD3IO.SD3IO();
        private Root rawData;
        public ObservableCollection<SaveSlot> SaveData { get; set; } = new ObservableCollection<SaveSlot>() {new SaveSlot(), new SaveSlot(), new SaveSlot()};
        public bool IsLoaded { get; private set; }
        public string FilePath { get; private set; }

        public void Load(string path)
        {
            IIO io = new SD3IO.SD3IO();
            var resultCode = io.Read(path, out rawData);

            if (resultCode)
            {
                for(int i = 0; i < rawData.slots.Length; i++)
                {
                    if(!rawData.slots[i].header.existsString.SequenceEqual(IIO.EXISTSTRING))
                    {
                        SaveData[i].IsExists = false;
                        continue;
                    }
                    var slot = new SaveSlot();
                    SaveData[i].IsExists = true;
                    SaveData[i].Currency = rawData.slots[i].data.currency;
                    SaveData[i].Location = rawData.slots[i].data.location;
                    SaveData[i].TimePlayed = rawData.slots[i].header.timePlayed;
                    SaveData[i].Characters[0].Name = new ObservableCollection<sbyte>(rawData.slots[i].data.characterName1);
                    SaveData[i].Characters[0].Status.CurrentHP = (uint)rawData.slots[i].data.character1.statusHPCurrent;
                    SaveData[i].Characters[0].Status.CurrentMP = (uint)rawData.slots[i].data.character1.statusMPCurrent;
                    SaveData[i].Characters[0].Status.MaxHP = (uint)rawData.slots[i].data.character1.statusHPMax;
                    SaveData[i].Characters[0].Status.MaxMP = (uint)rawData.slots[i].data.character1.statusMPMax;
                    SaveData[i].Characters[0].Status.Level = (uint)rawData.slots[i].data.character1.level;
                    SaveData[i].Characters[0].Status.Exp = (uint)rawData.slots[i].data.character1.exp;
                    SaveData[i].Characters[0].Status.Agi = (uint)rawData.slots[i].data.character1.statusAgi;
                    SaveData[i].Characters[0].Status.Int = (uint)rawData.slots[i].data.character1.statusInt;
                    SaveData[i].Characters[0].Status.Luk = (uint)rawData.slots[i].data.character1.statusLuk;
                    SaveData[i].Characters[0].Status.Spr = (uint)rawData.slots[i].data.character1.statusSpr;
                    SaveData[i].Characters[0].Status.Str = (uint)rawData.slots[i].data.character1.statusStr;
                    SaveData[i].Characters[0].Status.Vit = (uint)rawData.slots[i].data.character1.statusVit;
                    SaveData[i].Characters[1].Name = new ObservableCollection<sbyte>(rawData.slots[i].data.characterName2);
                    SaveData[i].Characters[1].Status.CurrentHP = (uint)rawData.slots[i].data.character2.statusHPCurrent;
                    SaveData[i].Characters[1].Status.CurrentMP = (uint)rawData.slots[i].data.character2.statusMPCurrent;
                    SaveData[i].Characters[1].Status.MaxHP = (uint)rawData.slots[i].data.character2.statusHPMax;
                    SaveData[i].Characters[1].Status.MaxMP = (uint)rawData.slots[i].data.character2.statusMPMax;
                    SaveData[i].Characters[1].Status.Level = (uint)rawData.slots[i].data.character2.level;
                    SaveData[i].Characters[1].Status.Exp = (uint)rawData.slots[i].data.character2.exp;
                    SaveData[i].Characters[1].Status.Agi = (uint)rawData.slots[i].data.character2.statusAgi;
                    SaveData[i].Characters[1].Status.Int = (uint)rawData.slots[i].data.character2.statusInt;
                    SaveData[i].Characters[1].Status.Luk = (uint)rawData.slots[i].data.character2.statusLuk;
                    SaveData[i].Characters[1].Status.Spr = (uint)rawData.slots[i].data.character2.statusSpr;
                    SaveData[i].Characters[1].Status.Str = (uint)rawData.slots[i].data.character2.statusStr;
                    SaveData[i].Characters[1].Status.Vit = (uint)rawData.slots[i].data.character2.statusVit;
                    SaveData[i].Characters[2].Name = new ObservableCollection<sbyte>(rawData.slots[i].data.characterName3);
                    SaveData[i].Characters[2].Status.CurrentHP = (uint)rawData.slots[i].data.character3.statusHPCurrent;
                    SaveData[i].Characters[2].Status.CurrentMP = (uint)rawData.slots[i].data.character3.statusMPCurrent;
                    SaveData[i].Characters[2].Status.MaxHP = (uint)rawData.slots[i].data.character3.statusHPMax;
                    SaveData[i].Characters[2].Status.MaxMP = (uint)rawData.slots[i].data.character3.statusMPMax;
                    SaveData[i].Characters[2].Status.Level = (uint)rawData.slots[i].data.character3.level;
                    SaveData[i].Characters[2].Status.Exp = (uint)rawData.slots[i].data.character3.exp;
                    SaveData[i].Characters[2].Status.Agi = (uint)rawData.slots[i].data.character3.statusAgi;
                    SaveData[i].Characters[2].Status.Int = (uint)rawData.slots[i].data.character3.statusInt;
                    SaveData[i].Characters[2].Status.Luk = (uint)rawData.slots[i].data.character3.statusLuk;
                    SaveData[i].Characters[2].Status.Spr = (uint)rawData.slots[i].data.character3.statusSpr;
                    SaveData[i].Characters[2].Status.Str = (uint)rawData.slots[i].data.character3.statusStr;
                    SaveData[i].Characters[2].Status.Vit = (uint)rawData.slots[i].data.character3.statusVit;
                }

                IsLoaded = true;
                FilePath = path;
            }
        }

        public void Save()
        {

        }

        public void UnLoad()
        {
            IsLoaded = false;
        }
    }

    public class SaveSlot : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Character> Characters { get; set; } = new ObservableCollection<Character>() { new Character(), new Character(), new Character() };
        public bool IsExists { get; set; } = false;
        public ItemStorage Item { get; set; } = new ItemStorage();
        public uint Currency { get; set; }
        public short Location { get; set; }
        public int TimePlayed { get; set; }

    }

    public class Character : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<sbyte> Name { get; set; } = new ObservableCollection<sbyte>();
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
