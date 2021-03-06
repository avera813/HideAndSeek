﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    abstract class Location
    {
        public string Name { get; private set; }
        public Location(string name)
        {
            Name = name;
        }
        public Location[] Exits;
        public virtual string Description
        {
            get {
                string description = "You're standing in the " + Name;
                if (Exits.Length > 0)
                {
                    description += ". You see exits to the following places: ";
                    for (int i = 0; i < Exits.Length; ++i)
                    {
                        description += Exits[i].Name;
                        if (i != Exits.Length - 1)
                            description += ", ";
                    }
                } 
                description += ".";
                return description;
            }
        }
    }
}
