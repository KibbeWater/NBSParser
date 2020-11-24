using NBSParser.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace NBSParser
{
    class Program
    {
        static ushort GetVersion(MemoryStream stream)
        {
            //Save starting position for later restoration
            var startPos = stream.Position;

            //Seek to starting position
            stream.Seek(0, SeekOrigin.Begin);

            //Read first 3 bytes
            byte[] byteArray = new byte[3];
            stream.Read(byteArray, 0, 3);

            //Return memorystream to its original position
            stream.Seek(startPos, SeekOrigin.Begin);

            //Get and return version;
            if (byteArray[0] == 0 && byteArray[1] == 0) {
                return byteArray[2];
            } else {
                return 0;
            }
        }

        static void Log(string msg, bool clear = false, ConsoleColor msgClr = ConsoleColor.White, string prefix = "Main", ConsoleColor prefixClr = ConsoleColor.Cyan)
        {
            var clr = Console.ForegroundColor;
            if (clear)
                Console.Clear();

            //Prefix
            Console.ForegroundColor = prefixClr;
            Console.Write("[");
            Console.ForegroundColor = msgClr;
            Console.Write(prefix);
            Console.ForegroundColor = prefixClr;
            Console.Write("] ");
            Console.ForegroundColor = msgClr;
            Console.Write("{0}\n", msg);
            Console.ForegroundColor = clr;
        }

        static void Main(string[] args)
        {
            ushort version;

            Log("NBS file path:", false, ConsoleColor.White, "Input", ConsoleColor.Red);
            string path = "";
            while (path == "")
            {
                var tempPath = Console.ReadLine();
                if (File.Exists(tempPath))
                    if (tempPath.EndsWith(".nbs"))
                        path = tempPath;
                    else
                        Log("Invalid filetype, NBS file path:", true, ConsoleColor.White, "Error", ConsoleColor.Red);
                else
                    Log("File does not exist, NBS file path:", true, ConsoleColor.White, "Error", ConsoleColor.Red);
            }
            Log("Reading data...", true);
            var stream = new MemoryStream();
            var fileStream = File.Open(path, FileMode.Open);
            Thread.Sleep(1234);

            Log("Copying data to memory stream...");
            fileStream.CopyTo(stream);
            fileStream.Close();
            Thread.Sleep(1403);

            Log("Getting version...");
            version = GetVersion(stream);
            Thread.Sleep(2534);
            Log("Current version is: " + (Versions)version);

            Thread.Sleep(500);
            Log("Gathering information for current file version...\n");
            object data = null;
            switch(version)
            {
                case 4:
                    data = DataParsers.GetDataV4(stream, path);
                    break;
                case 3:
                    data = DataParsers.GetDataV3(stream);
                    break;
                case 2:
                    data = DataParsers.GetDataV2(stream);
                    break;
                case 1:
                    data = DataParsers.GetDataV1(stream);
                    break;
                case 0:
                    data = DataParsers.GetDataV0(stream);
                    break;
            }
            Thread.Sleep(3225);

            var noteblocks = ((FILE)data).Noteblocks;
            Dictionary<byte, int> instruments = new Dictionary<byte, int>();
            for (int i = 0; i < noteblocks.Count; i++)
            {
                var noteblock = noteblocks[i];
                if (!instruments.ContainsKey(noteblock.instrument))
                    instruments[noteblock.instrument] = 0;
                instruments[noteblock.instrument] += 1;
            }

            Dictionary<byte, List<byte>> keys = new Dictionary<byte, List<byte>>();
            for (int i = 0; i < 15; i++) //Initialize dictionary
                keys.Add((byte)i, new List<byte>());

            for (int i = 0; i < noteblocks.Count; i++) { //Add all different keys
                var noteblock = noteblocks[i];
                var containsKey = false;
                for (int x = 0; x < keys[noteblock.instrument].Count; x++) {
                    if (keys[noteblock.instrument][x] == noteblock.key)
                        containsKey = true;
                }

                if (!containsKey)
                    keys[noteblock.instrument].Add(noteblock.key);
            }

            Log("Finished parsing:", true, ConsoleColor.White, "Info");
            foreach (var item in keys) //Write amounts
                if (item.Value.Count > 0)
                    Console.WriteLine("   {0}: {1}", (Instrument)(item.Key), item.Value.Count);

            Thread.Sleep(-1);
        }
    }
}
