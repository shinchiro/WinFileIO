using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace winfileio
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"copy.mkv";
            string rewrite = @"copied.mkv";

            byte[] wfioBlocks = new byte[WinFileIO.BlockSize];
            using (WinFileIO writer = new WinFileIO(wfioBlocks))
            using (WinFileIO reader = new WinFileIO(wfioBlocks))
            {
                reader.OpenForReading(file);
                writer.OpenForWriting(rewrite);

                while (reader.Position < reader.Length)
                {
                    int read = reader.ReadBlocks(wfioBlocks.Length);
                    writer.WriteBlocks(read);
                }
            }
        }
    }
}
