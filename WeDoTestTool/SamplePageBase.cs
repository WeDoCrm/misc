using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
    public class SamplePageBase : UserControl
    {
        public SamplePageBase()
        {
            SetStyle(
                ControlStyles.DoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint,
                true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.Style |= WinApi.WS_CLIPSIBLINGS | WinApi.WS_CLIPSIBLINGS;
                return createParams;
            }
        }
    }
}