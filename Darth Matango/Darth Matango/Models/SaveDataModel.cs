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

    }

    public class Character
    {

    }

    public class CharacterStatus
    {
        public uint Level { get; set; }
        public uint Exp { get; set; }
        public uint CurrentHP { get; set; }
        public uint CurrentMP { get; set; }
        public uint MaxHP { get; set; }
        public uint MaxMP { get; set; }


    }

    public class CharacterSkill
    {

    }

    public class Storage
    {

    }
}
