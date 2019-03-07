using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorPatterns.Template
{
    class MkvVideoPlayer : VideoPlayer
    {
        public override void DecodeVideo()
        {
            Console.WriteLine("  Decoding MKV video file ...");
        }
    }
}
