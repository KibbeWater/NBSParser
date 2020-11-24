using NBSParser.Structures;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace NBSParser
{
    class DataParsers
    {
        public static FILE GetDataV0(MemoryStream stream)
        {
            stream.Position = 2;

            Functions func = new Functions(stream);

            FILE file = new FILE();
            HEADERv0 header = new HEADERv0();

            header.hei = func.read_short();

            header.songName = func.read_string_int();
            header.author = func.read_string_int();
            header.originalAuthor = func.read_string_int();
            header.desc = func.read_string_int();

            header.temp = func.read_short();

            header.autosave = func.read_byte();
            header.autosaveDurbation = func.read_byte();

            header.timeSig = func.read_byte();

            header.minutesSpent = func.read_int();
            header.lmouse = func.read_int();
            header.rmouse = func.read_int();
            header.notesAdded = func.read_int();
            header.notesRemoved = func.read_int();

            header.fileName = func.read_string_int();

            file.Header = header;

            List<Noteblock> Noteblocks = new List<Noteblock>();
            while (true)
            {
                var a = func.read_short();
                if (a == 0)
                    break;
                while (true)
                {
                    var s = func.read_short();
                    if (s == 0)
                        break;

                    var ins = func.read_byte();
                    var key = func.read_byte();

                    byte vel = 100;
                    byte pan = 100;
                    short pit = 0;

                    Noteblock noteblock = new Noteblock();

                    noteblock.jmpLayer = a;
                    noteblock.jmpTick = s;

                    noteblock.instrument = ins;
                    noteblock.key = key;

                    noteblock.volume = vel;
                    noteblock.panning = pan;
                    noteblock.pitch = pit;

                    Noteblocks.Add(noteblock);
                }
            }

            file.Noteblocks = Noteblocks;

            return file;
        }
        public static FILE GetDataV1(MemoryStream stream)
        {
            stream.Position = 3;

            Functions func = new Functions(stream);

            FILE file = new FILE();
            HEADERv1 header = new HEADERv1();

            header.customIndex = func.read_byte();
            header.hei = func.read_short();

            header.songName = func.read_string_int();
            header.author = func.read_string_int();
            header.originalAuthor = func.read_string_int();
            header.desc = func.read_string_int();

            header.temp = func.read_short();

            header.autosave = func.read_byte();
            header.autosaveDurbation = func.read_byte();

            header.timeSig = func.read_byte();

            header.minutesSpent = func.read_int();
            header.lmouse = func.read_int();
            header.rmouse = func.read_int();
            header.notesAdded = func.read_int();
            header.notesRemoved = func.read_int();

            header.fileName = func.read_string_int();

            file.Header = header;

            List<Noteblock> Noteblocks = new List<Noteblock>();
            while (true)
            {
                var a = func.read_short();
                if (a == 0)
                    break;
                while (true)
                {
                    var s = func.read_short();
                    if (s == 0)
                        break;

                    var ins = func.read_byte();
                    var key = func.read_byte();

                    byte vel = 100;
                    byte pan = 100;
                    short pit = 0;

                    Noteblock noteblock = new Noteblock();

                    noteblock.jmpLayer = a;
                    noteblock.jmpTick = s;

                    noteblock.instrument = ins;
                    noteblock.key = key;

                    noteblock.volume = vel;
                    noteblock.panning = pan;
                    noteblock.pitch = pit;

                    Noteblocks.Add(noteblock);
                }
            }

            file.Noteblocks = Noteblocks;

            return file;
        }
        public static FILE GetDataV2(MemoryStream stream)
        {
            stream.Position = 3;

            Functions func = new Functions(stream);

            FILE file = new FILE();
            HEADERv2 header = new HEADERv2();

            header.customIndex = func.read_byte();
            header.hei = func.read_short();

            header.songName = func.read_string_int();
            header.author = func.read_string_int();
            header.originalAuthor = func.read_string_int();
            header.desc = func.read_string_int();

            header.temp = func.read_short();

            header.autosave = func.read_byte();
            header.autosaveDurbation = func.read_byte();

            header.timeSig = func.read_byte();

            header.minutesSpent = func.read_int();
            header.lmouse = func.read_int();
            header.rmouse = func.read_int();
            header.notesAdded = func.read_int();
            header.notesRemoved = func.read_int();

            header.fileName = func.read_string_int();

            file.Header = header;

            List<Noteblock> Noteblocks = new List<Noteblock>();
            while (true)
            {
                var a = func.read_short();
                if (a == 0)
                    break;
                while (true)
                {
                    var s = func.read_short();
                    if (s == 0)
                        break;

                    var ins = func.read_byte();
                    var key = func.read_byte();

                    byte vel = 100;
                    byte pan = 100;
                    short pit = 0;

                    Noteblock noteblock = new Noteblock();

                    noteblock.jmpLayer = a;
                    noteblock.jmpTick = s;

                    noteblock.instrument = ins;
                    noteblock.key = key;

                    noteblock.volume = vel;
                    noteblock.panning = pan;
                    noteblock.pitch = pit;

                    Noteblocks.Add(noteblock);
                }
            }

            file.Noteblocks = Noteblocks;

            return file;
        }
        public static FILE GetDataV3(MemoryStream stream)
        {
            stream.Position = 3;

            Functions func = new Functions(stream);

            FILE file = new FILE();
            HEADERv3 header = new HEADERv3();

            header.customIndex = func.read_byte();
            header.songLength = func.read_short();
            header.hei = func.read_short();

            header.songName = func.read_string_int();
            header.author = func.read_string_int();
            header.originalAuthor = func.read_string_int();
            header.desc = func.read_string_int();

            header.temp = func.read_short();

            header.autosave = func.read_byte();
            header.autosaveDurbation = func.read_byte();

            header.timeSig = func.read_byte();

            header.minutesSpent = func.read_int();
            header.lmouse = func.read_int();
            header.rmouse = func.read_int();
            header.notesAdded = func.read_int();
            header.notesRemoved = func.read_int();

            header.fileName = func.read_string_int();

            file.Header = header;

            List<Noteblock> Noteblocks = new List<Noteblock>();
            while (true)
            {
                var a = func.read_short();
                if (a == 0)
                    break;
                while(true)
                {
                    var s = func.read_short();
                    if (s == 0)
                        break;

                    var ins = func.read_byte();
                    var key = func.read_byte();

                    byte vel = 100;
                    byte pan = 100;
                    short pit = 0;

                    Noteblock noteblock = new Noteblock();

                    noteblock.jmpLayer = a;
                    noteblock.jmpTick = s;

                    noteblock.instrument = ins;
                    noteblock.key = key;

                    noteblock.volume = vel;
                    noteblock.panning = pan;
                    noteblock.pitch = pit;

                    Noteblocks.Add(noteblock);
                }
            }

            file.Noteblocks = Noteblocks;

            return file;
        }

        public static FILE GetDataV4(MemoryStream stream, string path)
        {
            stream.Position = 3;

            Functions func = new Functions(stream);

            FILE file = new FILE();
            HEADERv4 header = new HEADERv4();

            header.customIndex = func.read_byte();
            header.songLength = func.read_short();
            header.hei = func.read_short();

            header.songName = func.read_string_int();
            header.author = func.read_string_int();
            header.originalAuthor = func.read_string_int();
            header.desc = func.read_string_int();

            header.temp = func.read_short();

            header.autosave = func.read_byte();
            header.autosaveDurbation = func.read_byte();

            header.timeSig = func.read_byte();

            header.minutesSpent = func.read_int();
            header.lmouse = func.read_int();
            header.rmouse = func.read_int();
            header.notesAdded = func.read_int();
            header.notesRemoved = func.read_int();

            header.fileName = func.read_string_int();

            header.loop = func.read_byte();
            if (Regex.Matches(Path.GetFileName(path), "format4beta").Count == 1)
            {
                header.loopStart = func.read_byte();
            } else {
                header.loopCount = func.read_byte();
                header.loopStart = func.read_short();
            }

            file.Header = header;

            List<Noteblock> Noteblocks = new List<Noteblock>();
            while (true)
            {
                var a = func.read_short();
                if (a == 0)
                    break;
                while (true)
                {
                    var s = func.read_short();
                    if (s == 0)
                        break;

                    var ins = func.read_byte();
                    var key = func.read_byte();

                    var vel = func.read_byte();
                    var pan = func.read_byte();
                    var pit = func.read_short();

                    Noteblock noteblock = new Noteblock();

                    noteblock.jmpLayer = a;
                    noteblock.jmpTick = s;

                    noteblock.instrument = ins;
                    noteblock.key = key;

                    noteblock.volume = vel;
                    noteblock.panning = pan;
                    noteblock.pitch = pit;

                    Noteblocks.Add(noteblock);
                }
            }

            file.Noteblocks = Noteblocks;

            return file;
        }
    }
}
