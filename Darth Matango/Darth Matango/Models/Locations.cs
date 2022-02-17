using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Text.Json;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using Utf8Json;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace DarthMatango.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class LocationsRootObject
    {
        public List<Location> Locations { get; set; }

        public static LocationsRootObject GenerateRootObject()
        {
            var path = new Uri("Data/locations.json", UriKind.Relative);
            using var sr = new StreamReader(Application.GetResourceStream(path).Stream, Encoding.UTF8);
            var jsonString = sr.ReadToEnd();
            var ret = System.Text.Json.JsonSerializer.Deserialize<LocationsRootObject>(jsonString);
            return ret;
        }
    }
}
