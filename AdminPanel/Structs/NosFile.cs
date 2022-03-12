using System;

namespace AdminPanel.Structs
{
    public struct NosFile
    {
        public string Name { get; set; }
        public string CreationTimeUtc { get; set; }
        public long Size { get; set; }
        public Guid Version { get; set; }
    }
}