
using System;
using System.Collections.Generic;
using DestinySharp;

namespace Destiny.Definitions
{
    public class DestinyItemObjectiveBlockDefinition
    {
        public UInt32[] objectiveHashes;
        public UInt32[] displayActivityHashes;
        public bool requireFullObjectiveCompletion;
        public int questlineItemHash;
        public string narrative;
        public string objectiveVerbName;
        public string questTypeIdentifier;
        public int questTypeHash;
    }
}