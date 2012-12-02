using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
    [ToolboxItem(true)]
    public sealed class EventControl : Control
    {
        private readonly Timer _animationIncreaseTimer;
        private readonly Timer _animationDecreaseTimer;
        private Rectangle _maxSize = new Rectangle(0, 0, 27, 27);
        private Rectangle _minSize = new Rectangle(0, 0, 24, 24);
        private bool _increaseSize;

        public EventControl()
        {
            _animationIncreaseTimer = new Timer();
            _animationIncreaseTimer.Interval = 100;
            _animationIncreaseTimer.Tick += AnimationIncreaseTimer_Tick;
            _animationDecreaseTimer = new Timer();
            _animationDecreaseTimer.Interval = 100;
            _animationDecreaseTimer.Tick += AnimationDecreaseTimer_Tick;

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            MinimumSize = MaximumSize = new Size(27, 27);
        }

        protected override void Dispose(bool disposing)
        {
            if( disposing )
            {
                if( _animationIncreaseTimer != null )
                {
                    _animationIncreaseTimer.Stop();
                    _animationIncreaseTimer.Dispose();
                }
                if (_animationDecreaseTimer != null)
                {
                    _animationDecreaseTimer.Stop();
                    _animationDecreaseTimer.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        protected override bool FlipContentInRtlMode
        {
            get
            {
                return true;
            }
        }

        public override bool ShouldCreateLogic
        {
            get
            {
                return false;
            }
        }

        private void AnimationIncreaseTimer_Tick(object sender, System.EventArgs e)
        {
            _animationDecreaseTimer.Stop();
            _animationIncreaseTimer.Stop();
            _increaseSize = true;
            Refresh();
            _animationDecreaseTimer.Start();
        }

        private void AnimationDecreaseTimer_Tick(object sender, System.EventArgs e)
        {
            _animationIncreaseTimer.Stop();
            _animationDecreaseTimer.Stop();
            _increaseSize = false;
            Refresh();
        }

        public void StartAnimation()
        {
            _animationIncreaseTimer.Start();
        }

        public void StopAnimation()
        {
            _animationIncreaseTimer.Stop();
            _animationDecreaseTimer.Stop();
            _increaseSize = false;
            Refresh();
        }

        public bool IsAnimationEnabled
        {
            get
            {
                return (_animationIncreaseTimer.Enabled || _animationDecreaseTimer.Enabled);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle imageBounds = Rectangle.Empty;
            imageBounds.Size = _increaseSize ? _maxSize.Size : _minSize.Size;

            Image img = _increaseSize ? Properties.Resources.GreenCircle_27x27 : Properties.Resources.TanCircle_27x27;
            
            imageBounds.Location = new Point(
                (ClientRectangle.Width - imageBounds.Width) / 2,
                (ClientRectangle.Height - imageBounds.Height) / 2);

            CompositingQuality compositingQuality = e.Graphics.CompositingQuality;
            InterpolationMode interpolationMode = e.Graphics.InterpolationMode;
            SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.DrawImage(img, imageBounds);
            e.Graphics.CompositingQuality = compositingQuality;
            e.Graphics.InterpolationMode = interpolationMode;
            e.Graphics.SmoothingMode = smoothingMode;
        }
    }
}
