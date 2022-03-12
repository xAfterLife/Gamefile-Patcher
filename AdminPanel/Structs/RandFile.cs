using System;

namespace AdminPanel.Structs
{
    public struct RandFile
    {
        public string Name { get; set; }
        public string Folder { get; set; }
        public string CreationTimeUtc { get; set; }
        public long Size { get; set; }
        public Guid Version { get; set; }
    }
}