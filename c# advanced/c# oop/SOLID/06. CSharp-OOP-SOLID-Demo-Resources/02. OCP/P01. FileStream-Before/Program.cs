using System;

namespace P01._FileStream_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            IStream file = new File();
            IStream music = new Music();
            IStream video = new Video();
            Video d3 = new Video();
            d3.Format = "H264";
        }
    }
}
