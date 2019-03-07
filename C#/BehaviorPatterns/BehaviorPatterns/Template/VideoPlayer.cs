using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorPatterns.Template
{
    public abstract class VideoPlayer
    {
        public void LoadFile(string fileName)
        {
            Console.WriteLine($"Loading {fileName} video ...");
            Console.WriteLine($"  {fileName} Loaded!");
        }

        public abstract void DecodeVideo();

        public void StartPlay()
        {
            Console.WriteLine($"  Video File starts playing!\n");
        }

        public void PlayVideo(string fileName)
        {
            LoadFile(fileName);
            DecodeVideo();
            StartPlay();
        }
    }
}
