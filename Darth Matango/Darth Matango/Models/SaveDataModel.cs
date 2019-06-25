using PropertyChanged;
using SD3IO;
using System;
using System.Collections.Generic;
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

    public class SaveSlot
    {
        public Character[] Characters { get; set; } = new Character[3];
        public ItemStorage Item { get; set; } = new ItemStorage();
        public uint Currency { get; set; }

    }

    public class Character
    {
        public byte[] Name { get; set; } = new byte[6];
        public CharacterStatus Status { get; set; } = new CharacterStatus();
        public CharacterEquip Equip { get; set; } = new CharacterEquip();
        public Skill[] Skills { get; set; } = new Skill[12];
    }

    public class CharacterStatus
    {
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

    public class CharacterEquip
    {
        public uint Weapon { get; set; }
        public uint Helm { get; set; }
        public uint Armor { get; set; }
        public uint Ring { get; set; }
        public uint Shield { get; set; }
    }

    public class Skill
    {
        public uint SkillKind { get; set; }
        public uint Target { get; set; }
    }



    public class ItemStorage
    {
        public Item[] Inventory { get; set; } = new Item[10];
        public Item[] Stash { get; set; } = new Item[254];
    }

    public class Item
    {
        public uint ItemKind { get;set; }
        public uint Count { get; set; }
    }
}
