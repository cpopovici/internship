using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorPatterns.Template
{
    class MP4VideoPlayer : VideoPlayer
    {
        public override void DecodeVideo()
        {
            Console.WriteLine("  Decoding MP4 video file ...");
        }
    }
}
