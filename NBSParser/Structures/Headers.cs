namespace NBSParser.Structures
{
    struct HEADERv0
    {
        public short hei;

        public string songName;
        public string author;
        public string originalAuthor;
        public string desc;

        public short temp;

        public byte autosave;
        public byte autosaveDurbation;

        public byte timeSig;

        public int minutesSpent;
        public int lmouse;
        public int rmouse;
        public int notesAdded;
        public int notesRemoved;
        public string fileName;
    };

    struct HEADERv1
    {
        public byte customIndex;
        public short hei;

        public string songName;
        public string author;
        public string originalAuthor;
        public string desc;

        public short temp;

        public byte autosave;
        public byte autosaveDurbation;

        public byte timeSig;

        public int minutesSpent;
        public int lmouse;
        public int rmouse;
        public int notesAdded;
        public int notesRemoved;
        public string fileName;
    };

    struct HEADERv2
    {
        public byte customIndex;
        public short hei;

        public string songName;
        public string author;
        public string originalAuthor;
        public string desc;

        public short temp;

        public byte autosave;
        public byte autosaveDurbation;

        public byte timeSig;

        public int minutesSpent;
        public int lmouse;
        public int rmouse;
        public int notesAdded;
        public int notesRemoved;
        public string fileName;
    };

    struct HEADERv3
    {
        public byte customIndex;
        public short songLength;

        public short hei;

        public string songName;
        public string author;
        public string originalAuthor;
        public string desc;

        public short temp;

        public byte autosave;
        public byte autosaveDurbation;

        public byte timeSig;

        public int minutesSpent;
        public int lmouse;
        public int rmouse;
        public int notesAdded;
        public int notesRemoved;
        public string fileName;
    };

    struct HEADERv4
    {
        public byte customIndex;
        public short songLength;

        public short hei;

        public string songName;
        public string author;
        public string originalAuthor;
        public string desc;

        public short temp;

        public byte autosave;
        public byte autosaveDurbation;

        public byte timeSig;

        public int minutesSpent;
        public int lmouse;
        public int rmouse;
        public int notesAdded;
        public int notesRemoved;
        public string fileName;

        public byte loop;
        public byte loopCount;
        public short loopStart;
    };
}
