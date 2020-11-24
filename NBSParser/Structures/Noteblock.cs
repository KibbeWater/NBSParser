namespace NBSParser.Structures
{
    struct Noteblock
    {
        public short jmpTick;
        public short jmpLayer;

        public byte instrument;
        public byte key;

        public byte volume;
        public byte panning;
        public short pitch;
    }
}
