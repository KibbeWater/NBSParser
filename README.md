# Noteblock Studio Parser

This is a program to significantly help in the parsing process of the NBS files if you want to some info from the NBS files you could not get otherwise in an easy way

### How to modify the info returned
Simply change the code from the bottom to whatever you want for your use case

### Whats being parsed as of now
* Header
* Notes
* ~Layers~
* ~Custom Instruments~

### Examples
Getting required blocks to get one of each note
```csharp
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
```

Getting amount of notes in .NBS file
```csharp
  var noteblocks = ((FILE)data).Noteblocks;
  Log("Finished parsing:", true, ConsoleColor.White, "Info");
  Console.WriteLine("This NBS file has {0} notes", noteblocks.Count);
```
