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

        public Animation(Action<int> onNewFrame, int fromValue, int toValue, double duration, Action completion)
        {
            this.onNewFrame = onNewFrame;
            FromValue = fromValue;
            ToValue = toValue;
            this.completion = completion;
            totalFrames = (int)(frameRate * duration);
            step = (ToValue - FromValue) / totalFrames;
        }

        void TimerTick(object sender, EventArgs e) {
            var value = step * currentFrame + FromValue;
            onNewFrame(value);
            currentFrame++;
            if (currentFrame > totalFrames) {
                timer.Tick -= TimerTick;
                completion();
            }
        }

        public void Start() {
            timer.Tick += TimerTick;
        }
    }
}
