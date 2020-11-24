using System;
using System.IO;

namespace NBSParser
{
    class Functions
    {
        private static MemoryStream stream;

        public Functions(MemoryStream strm)
        {
            stream = strm;
        }

        public byte read_byte()
        {
            var buffer = new byte[1];
            stream.Read(buffer, 0, 1);
            return (byte)buffer[0];
        }

        public short read_short()
        {
            var buffer = new byte[2];
            stream.Read(buffer, 0, 2);
            return BitConverter.ToInt16(buffer, 0);
        }

        public int read_int()
        {
            var buffer = new byte[4];
            stream.Read(buffer, 0, 4);
            return BitConverter.ToInt32(buffer, 0);
        }

        public string read_string_int()
        {
            int length = read_int();

            byte[] buffer = new byte[length];
            stream.Read(buffer, 0, length);

            string str = "";
            for (int i = 0; i < buffer.Length; i++)
                str += (char)buffer[i];

            return str;
        }
    }
}
