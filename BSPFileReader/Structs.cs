using System;
using System.Runtime.InteropServices;

namespace BSPFileReader
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class SetLumpType : System.Attribute
    {
        private LumpType lump_t;
        public  SetLumpType(LumpType lump_t)
        {
            this.lump_t = lump_t;
        }
    }

    public enum LumpType
    {
        LUMP_ENTITIES = 0,
        LUMP_PLANES,
        LUMP_TEXDATA,
        LUMP_VERTEXES,
        LUMP_VISIBILITY,
        LUMP_NODES,
        LUMP_TEXINFO,
        LUMP_FACES,
        LUMP_LIGHTING,
        LUMP_OCCLUSION,
        LUMP_LEAFS,
        LUMP_FACEIDS,
        LUMP_EDGES,
        LUMP_SURFEDGES,
        LUMP_MODELS,
        LUMP_WORLDLIGHTS,
        LUMP_LEAFFACES,
        LUMP_LEAFBRUSHES,
        LUMP_BRUSHES,
        LUMP_BRUSHSIDES,
        LUMP_AREAS,
        LUMP_AREAPORTALS,
        LUMP_PORTALS,
        LUMP_UNUSED0,
        LUMP_PROPCOLLISION,
        LUMP_CLUSTERS,
        LUMP_UNUSED1,
        LUMP_PROPHULLS,
        LUMP_PORTALVERTS,
        LUMP_UNUSED2,
        LUMP_PROPHULLVERTS,
        LUMP_CLUSERPORTALS,
        LUMP_UNUSED3,
        LUMP_PROPTRIS,
        LUMP_DISPINFO,
        LUMP_ORIGINALFACES,
        LUMP_PHYSDISP,
        LUMP_PHYSCOLLIDE,
        LUMP_VERTNORMALS,
        LUMP_VERTNORMALINDICES,
        LUMP_DISP_LIGHTMAP_ALPHAS,
        LUMP_DISP_VERTS,
        LUMP_DISP_LIGHTMAP_SAMPLE_POSITIONS,
        LUMP_GAME_LUMP,
        LUMP_LEAFWATERDATA,
        LUMP_PRIMITIVES,
        LUMP_PRIMVERTS,
        LUMP_PRIMINDICES,
        LUMP_PAKFILE,
        LUMP_CLIPPORTALVERTS,
        LUMP_CUBEMAPS,
        LUMP_TEXDATA_STRING_DATA,
        LUMP_TEXDATA_STRING_TABLE,
        LUMP_OVERLAYS,
        LUMP_LEAFMINDISTTOWTER,
        LUMP_FACE_MACRO_TEXTURE_INFO,
        LUMP_DISP_TRIS,
        LUMP_PHYSCOLLIDESURFACE,
        LUMP_PROP_BLOB,
        LUMP_WATEROVERALYS,
        LUMP_LIGHTMAPPAGES,
        LUMP_LEAF_AMBIENT_INDEX_HDR,
        LUMP_LIGHTMAPPAGEINFOS,
        LUMP_LEAF_AMBIENT_INDEX,
        LUMP_LIGHTING_HDR,
        LUMP_WORLDLIGHTS_HDR,
        LUMP_LEAF_AMBIENT_LIGHTING_HDR,
        LUMP_LEAF_AMBIENT_LIGHTING,
        LUMP_XZIPPAKFILE,
        LUMP_FACES_HDR,
        LUMP_MAP_FLAGS,
        LUMP_OVERLAY_FADES,
        LUMP_OVERLAY_SYSTEM_LEVELS,
        LUMP_PHYSLEVEL,
        LUMP_DISP_MULTIBLEND
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector
    {
        public float X;
        public float Y;
        public float Z;
    }

    public struct Header
    {
        public string    ident;
        public int     version;
        public lump_t[]  lumps;             // 64
        public int mapRevision;
    }

    public class lump_t
    {
        public int    fileoffset;
        public int    filelength;
        public int    version;
        public byte[] uncompressedLength;   // 4
    }

    public struct dplane_t
    {
        public Vector normal;
        public float dist;
        public int type;
    }

    public struct vertext
    {
        public Vector pos;
    }

    public struct dedge_t
    {
       public ushort[] v; // Vertext Lump Array
    }

    public struct surfedge
    {
        // Positive - First to second edge index. Negative - Second to first edge index. Absolute number is the index of the edge.
        public int indexAndDirection; 
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi), SetLumpType( LumpType.LUMP_FACES ) ]
    public struct dface_t
    {
        [MarshalAs(UnmanagedType.U2)]
        public ushort planenum;                         // the plane number

        public byte side;                               // faces opposite to the node's plane direction
        public byte onNode;                             // 1 of on node, 0 if in leaf

        [MarshalAs(UnmanagedType.I4)]
        public int firstedge;                           // index into surfedges

        [MarshalAs(UnmanagedType.I2)]
        public short numedges;                          // number of surfedges

        [MarshalAs(UnmanagedType.I2)]
        public short texinfo;                           // texture info

        [MarshalAs(UnmanagedType.I2)]
        public short dispinfo;                          // displacement info

        [MarshalAs(UnmanagedType.I2)]
        public short surfaceFogVolumeID;                // ?

        [MarshalAs(UnmanagedType.ByValArray)]
        public byte[]  styles;                          // switchable lighting info, 4

        [MarshalAs(UnmanagedType.I4)]
        public int lightofs;                            // offset into lightmap lump

        [MarshalAs(UnmanagedType.R4)]
        public float area;                              // face area in units^2

        [MarshalAs(UnmanagedType.ByValArray)]
        public int[] LightmapTextureMinsInLuxels;       // texture lighting info, 2

        [MarshalAs(UnmanagedType.ByValArray)]
        public int[] LightmapTextureSizeInLuxels;       // texture lighting info, 2

        [MarshalAs(UnmanagedType.I4)]
        public int origFace;                            // original face this was split from

        [MarshalAs(UnmanagedType.U2)]
        public ushort numPrims;                         // primitives

        [MarshalAs(UnmanagedType.U2)]
        public ushort firstPrimID;

        [MarshalAs(UnmanagedType.U4)]
        public uint smoothingGroups;                    // lightmap smoothing group
    }

    public struct dbrush_t
    {
        public int firstside;
        public int numsides;
        public int contents;
    }

    struct dbrushside_t
    {
        public ushort planenum;    // facing out of the leaf
        public short   texinfo;      // texture info
        public short  dispinfo;     // displacement info
        public short     bevel;        // is the side a bevel plane?
    }

}
