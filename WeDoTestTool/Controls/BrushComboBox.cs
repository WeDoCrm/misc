using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Elegant.Ui.Samples.ControlsSample.Properties;

namespace Elegant.Ui.Samples.ControlsSample
{
    public class BrushComboBox : ComboBox
    {
        internal class BrushSample
        {
            public BrushSample(string brushName, Image brushSampleImage)
            {
                _brushName = brushName;
                _brushSampleImage = brushSampleImage;
            }

            private readonly string _brushName;

            public string BrushName
            {
                get { return _brushName; }
            }

            private readonly Image _brushSampleImage;

            public Image BrushSampleImage
            {
                get { return _brushSampleImage; }
            }
        }

        public BrushComboBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = _brushSampleSize.Height + 14;
            DropDownHeight = ItemHeight*6 + 10;
            DropDownWidth = _brushSampleSize.Width + SystemInformation.VerticalScrollBarWidth + 16;
            DisplayMember = "BrushName";
            ItemScreentipTextPropertyName = "BrushName";
            AutoCompleteMode = AutoCompleteMode.Append;
            AutoCompleteSource = AutoCompleteSource.CustomSource;

            InitializeItems();
            InitializeAutoCompleteDataSource();
        }

        private readonly Size _brushSampleSize = new Size(158, 28);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int DropDownWidth
        {
            get { return base.DropDownWidth; }
            set { base.DropDownWidth = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int DropDownHeight
        {
            get { return base.DropDownHeight; }
            set { base.DropDownHeight = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int ItemHeight
        {
            get { return base.ItemHeight; }
            set { base.ItemHeight = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string DisplayMember
        {
            get { return base.DisplayMember; }
            set { base.DisplayMember = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string ItemScreentipTextPropertyName
        {
            get { return base.ItemScreentipTextPropertyName; }
            set { base.ItemScreentipTextPropertyName = value; }
        }

        private void InitializeItems()
        {
            DataSource = new BrushSample[]
                {
                    new BrushSample("Hard Round 1 pixel", Resources.BrushHardRound1px),
                    new BrushSample("Hard Round 3 pixels", Resources.BrushHardRound3px),
                    new BrushSample("Hard Round 5 pixels", Resources.BrushHardRound5px),
                    new BrushSample("Hard Round 9 pixels", Resources.BrushHardRound9px),
                    new BrushSample("Hard Round 13 pixels", Resources.BrushHardRound13px),
                    new BrushSample("Hard Round 19 pixels", Resources.BrushHardRound19px),
                    new BrushSample("Soft Round 5 pixels", Resources.BrushSoftRound5px),
                    new BrushSample("Soft Round 9 pixels", Resources.BrushSoftRound9px),
                    new BrushSample("Soft Round 13 pixels", Resources.BrushSoftRound13px),
                    new BrushSample("Soft Round 17 pixels", Resources.BrushSoftRound17px),
                    new BrushSample("Soft Round 21 pixels", Resources.BrushSoftRound21px),
                    new BrushSample("Soft Round 27 pixels", Resources.BrushSoftRound27px),
                    new BrushSample("Airbrush Hard Round 9 pixels", Resources.AirBrushHardRound9px),
                    new BrushSample("Airbrush Hard Round 13 pixels", Resources.AirBrushHardRound13px),
                    new BrushSample("Airbrush Hard Round 19 pixels", Resources.AirBrushHardRound19px),
                    new BrushSample("Spatter 14 pixels", Resources.BrushSpatter14px),
                    new BrushSample("Spatter 24 pixels", Resources.BrushSpatter24px),
                    new BrushSample("Spatter 27 pixels", Resources.BrushSpatter27px),
                    new BrushSample("Spatter 39 pixels", Resources.BrushSpatter39px),
                    new BrushSample("Spatter 46 pixels", Resources.BrushSpatter46px),
                    new BrushSample("Spatter 59 pixels", Resources.BrushSpatter59px),
                    new BrushSample("Dune Grass 112 pixels", Resources.BrushDuneGrass112px),
                    new BrushSample("Grass 134 pixels", Resources.BrushGrass134px),
                    new BrushSample("Scattered Maple Leaves 74 pixels", Resources.BrushScatteredMapleLeaves74px),
                    new BrushSample("Scattered Leaves 95 pixels", Resources.BrushScatteredLeaves95px),
                    new BrushSample("Flowing Stars 29 pixels", Resources.BrushFlowingStars29px),
                    new BrushSample("Fuzzball 192 pixels", Resources.BrushFuzzball192px),
                    new BrushSample("Chalk 36 pixels", Resources.BrushChalk36px),
                    new BrushSample("Charcoal Large Smear 36 pixels", Resources.BrushCharcoalLargeSmear36px),
                    new BrushSample("Hard Pastel On Canvas 33 pixels", Resources.BrushHardPastelOnCanvas33px),
                    new BrushSample("Oil Pastel Large 63 pixels", Resources.BrushOilPastelLarge63px),
                    new BrushSample("Dry Brush Tip Light Flow 66 pixels", Resources.BrushDryBrushTipLightFlow66px),
                    new BrushSample("Dry Brush 39 pixels", Resources.BrushDryBrush39px),
                };
        }

        private void InitializeAutoCompleteDataSource()
        {
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();

            autoCompleteStringCollection.AddRange(
                new string[]
                    {
                        "Hard Round 1 pixel",
                        "Hard Round 3 pixels",
                        "Hard Round 5 pixels",
                        "Hard Round 9 pixels",
                        "Hard Round 13 pixels",
                        "Hard Round 19 pixels",
                        "Soft Round 5 pixels",
                        "Soft Round 9 pixels",
                        "Soft Round 13 pixels",
                        "Soft Round 17 pixels",
                        "Soft Round 21 pixels",
                        "Soft Round 27 pixels",
                        "Airbrush Hard Round 9 pixels",
                        "Airbrush Hard Round 13 pixels",
                        "Airbrush Hard Round 19 pixels",
                        "Spatter 14 pixels",
                        "Spatter 24 pixels",
                        "Spatter 27 pixels",
                        "Spatter 39 pixels",
                        "Spatter 46 pixels",
                        "Spatter 59 pixels",
                        "Dune Grass 112 pixels",
                        "Grass 134 pixels",
                        "Scattered Maple Leaves 74 pixels",
                        "Scattered Leaves 95 pixels",
                        "Flowing Stars 29 pixels",
                        "Fuzzball 192 pixels",
                        "Chalk 36 pixels",
                        "Charcoal Large Smear 36 pixels",
                        "Hard Pastel On Canvas 33 pixels",
                        "Oil Pastel Large 63 pixels",
                        "Dry Brush Tip Light Flow 66 pixels",
                        "Dry Brush 39 pixels",
                    });

            AutoCompleteCustomSource = autoCompleteStringCollection;
        }

        protected override void OnDrawItem(DrawComboBoxItemEventArgs e)
        {
            BrushSample brushSample = Items[e.ItemIndex] as BrushSample;
            if (brushSample == null)
            {
                base.OnDrawItem(e);
                return;
            }

            if (e.IsSelected)
                e.PaintSelectedBackground();
            else
                e.PaintNormalBackground();

            Rectangle sampleBounds = new Rectangle(e.Bounds.Location, _brushSampleSize);
            sampleBounds.X += (e.Bounds.Width - _brushSampleSize.Width)/2;
            sampleBounds.Y += (e.Bounds.Height - _brushSampleSize.Height)/2;

            Rectangle boundingLineBounds = sampleBounds;
            boundingLineBounds.Offset(-1, -1);
            boundingLineBounds.Width += 1;
            boundingLineBounds.Height += 1;

            using (Pen p = new Pen(Color.Black))
            {
                e.Graphics.DrawRectangle(p, boundingLineBounds);
            }

            e.Graphics.DrawImage(brushSample.BrushSampleImage, sampleBounds);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ComboBoxItemCollection Items
        {
            get { return base.Items; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new AutoCompleteSource AutoCompleteSource
        {
            get { return base.AutoCompleteSource; }
            set { base.AutoCompleteSource = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return base.AutoCompleteCustomSource; }
            set { base.AutoCompleteCustomSource = value; }
        }
    }
}