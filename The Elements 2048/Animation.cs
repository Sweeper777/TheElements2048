using System;
using System.Windows.Forms;
namespace The_Elements_2048
{
    public class Animation
    {
        const int frameRate = 20;
        Action<int> onNewFrame;
        Action completion;
        static Timer timer;
        int step;
        int currentFrame;
        int totalFrames;

        public int FromValue { get; }
        public int ToValue { get; }

        static Animation() {
            timer = new Timer();
            timer.Interval = (int)(1.0 / frameRate * 1000);
            timer.Start();
        }

    }
}
