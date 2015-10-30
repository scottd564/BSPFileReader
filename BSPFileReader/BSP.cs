using System;
using System.Text;
using System.IO;

namespace BSPFileReader
{

    public class BSP
    {

        protected bool headerReady;
        protected Header    header;
        protected string  FileName;

        public BSP(string fileName)
        {
            if (!File.Exists(fileName))
                return;
            CreateHeader(fileName);
        }

        private void CreateHeader( string fileName )
        {
            using (BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read)))
            {

                FileName = fileName;
                header   = new Header()
                {
                    ident = Encoding.ASCII.GetString(br.ReadBytes(4)),
                    version = br.ReadInt32(),
                    lumps = new lump_t[64]
                };

                for (int I = 0; I < header.lumps.Length; I++)
                {
                    lump_t lump = header.lumps[I];
                    lump = new lump_t()
                    {
                        fileoffset          = (int?)br.ReadInt32() ?? 0,
                        filelength          = (int?)br.ReadInt32() ?? 0,
                        version             = (int?)br.ReadInt32() ?? 0,
                        uncompressedLength  = br.ReadBytes(4)
                    };
                }

                header.mapRevision = br.ReadInt32();
                br.Close();
                headerReady = true;
            }
        }

        public lump_t GetLump( int start = 0, int size = 0 )
        {
            return null;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(FileName)) return "[BSPObject Empty]";

            return string.Format( "[BSPObject: {0}, {1}, v{2}, r{3}]",
                FileName,
                header.ident,
                header.version,
                header.mapRevision );

        }

    }
}
