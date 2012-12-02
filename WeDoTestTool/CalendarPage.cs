using System;
using System.Drawing;
using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class CalendarPage : SamplePageBase
    {
        public CalendarPage()
        {
            InitializeComponent();

            SampleCalendar.FirstVisibleMonth = DateTime.Now;

            CalendarHitTestContextMenu.Owner = SampleCalendar;
            CalendarHitTestContextMenu.HideByClickingOnParentControl = true;

            DayOfWeekDisplayModeComboBox.DataSource = Enum.GetValues(typeof (CalendarDayOfWeekDisplayMode));
            DayOfWeekDisplayModeComboBox.SelectedItem = CalendarDayOfWeekDisplayMode.FirstLetter;

            _CalendarAnimationTimer = new Timer();
            _CalendarAnimationTimer.Interval = 50;
            _CalendarAnimationTimer.Tick += CalendarAnimationTimer_Tick;
        }

        private const int HighlightedDaysCount = 10;

        private void CalendarAnimationTimer_Tick(object sender, EventArgs e)
        {
            CalendarDateRange visibleDateRange = SampleCalendar.VisibleDateRange;
            if (_CurrentCalendarAnimationHead >= visibleDateRange.End)
            {
                SampleCalendar.InvalidateDateRange(new CalendarDateRange(
                    _CurrentCalendarAnimationHead.AddDays(-HighlightedDaysCount), _CurrentCalendarAnimationHead));

                _CurrentCalendarAnimationHead = visibleDateRange.Start;
            }
            else
                _CurrentCalendarAnimationHead = _CurrentCalendarAnimationHead.AddDays(1);

            SampleCalendar.InvalidateDateRange(new CalendarDateRange(
                _CurrentCalendarAnimationHead.AddDays(-HighlightedDaysCount), _CurrentCalendarAnimationHead));
        }

        private readonly Timer _CalendarAnimationTimer;

        private void CalendarDimensionsWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(SampleCalendar.AutoDimensionsMode)
                return;

            SampleCalendar.CalendarDimensions =
                new Size(Convert.ToInt32(CalendarDimensionsWidthNumericUpDown.Value), 
                SampleCalendar.CalendarDimensions.Height);
        }

        private void CalendarDimensionsHeightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (SampleCalendar.AutoDimensionsMode)
                return;

            SampleCalendar.CalendarDimensions =
                new Size(SampleCalendar.CalendarDimensions.Width,
                    Convert.ToInt32(CalendarDimensionsHeightNumericUpDown.Value));
        }

        private void AutoDimensionsModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool autoDimensions = AutoDimensionsModeCheckBox.Checked;
            SampleCalendar.AutoDimensionsMode = autoDimensions;

            CalendarDimensionsWidthNumericUpDown.Enabled = !autoDimensions;
            CalendarDimensionsHeightNumericUpDown.Enabled = !autoDimensions;

            MaximumWidthNumericUpDown.Enabled = autoDimensions;
            MaximumHeightNumericUpDown.Enabled = autoDimensions;
        }

        private void AllowMultipleSelectionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SampleCalendar.AllowMultipleSelection = AllowMultipleSelectionCheckBox.Checked;
        }

        private void MonthSelectionPopupEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SampleCalendar.MonthSelectionPopupEnabled = MonthSelectionPopupEnabledCheckBox.Checked;
        }

        private void NonMonthDaysVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SampleCalendar.NonMonthDaysVisible = NonMonthDaysVisibleCheckBox.Checked;
        }

        private void TodayButtonVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SampleCalendar.TodayButtonVisible = TodayButtonVisibleCheckBox.Checked;
        }

        private void NoneButtonVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SampleCalendar.NoneButtonVisible = NoneButtonVisibleCheckBox.Checked;
        }

        private void DayOfWeekDisplayModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SampleCalendar.DayOfWeekDisplayMode =
                (CalendarDayOfWeekDisplayMode)DayOfWeekDisplayModeComboBox.SelectedItem;
        }

        private void WeekNumbersVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SampleCalendar.WeekNumbersVisible = WeekNumbersVisibleCheckBox.Checked;
        }

        private void MaximumWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SampleCalendar.MaximumAutoDimensions = new Size(Convert.ToInt32(MaximumWidthNumericUpDown.Value),
                SampleCalendar.MaximumAutoDimensions.Height);
        }

        private void MaximumHeightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SampleCalendar.MaximumAutoDimensions = new Size(SampleCalendar.MaximumAutoDimensions.Width,
                Convert.ToInt32(MaximumHeightNumericUpDown.Value));
        }

        private void CustomPaintingDemoToggleButton_PressedChanged(object sender, EventArgs e)
        {
            _CurrentCalendarAnimationHead = SampleCalendar.VisibleDateRange.Start;
            bool pressed = CustomPaintingDemoToggleButton.Pressed;

            SampleCalendar.UseCustomDayDrawing = pressed;
            _CalendarAnimationTimer.Enabled = pressed;
        }

        private DateTime _CurrentCalendarAnimationHead;
        
        private void SampleCalendar_DrawDay(object sender, CalendarDrawDayEventArgs e)
        {
            DateTime date = e.Date;

            if (e.Selected)
            {
                using (Brush b = new SolidBrush(SampleCalendar.SelectedDayBackColor))
                    e.Graphics.FillRectangle(b, e.Bounds);
            }

            if (date <= _CurrentCalendarAnimationHead &&
                date >= _CurrentCalendarAnimationHead.AddDays(-HighlightedDaysCount))
            {
                int alpha = 255 - ((_CurrentCalendarAnimationHead - date).Days * 50);
                if (alpha < 0)
                    alpha = 0;

                Color color = Color.FromArgb(alpha, Color.Green);
                using (Brush b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, e.Bounds);
            }

            Color textColor;
            if (e.NonMonthDay)
                textColor = SampleCalendar.NonMonthDayTextColor;
            else
                textColor = SampleCalendar.DayTextColor;

            Rectangle textRectangle = e.RelativeBounds;
            textRectangle.X += SampleCalendar.DayPadding.Left;

            TextRenderer.DrawText(
                        e.Graphics,
                        date.Day.ToString(),
                        SampleCalendar.DayFont,
                        textRectangle,
                        textColor,
                        TextFormatFlags.Right | TextFormatFlags.TextBoxControl | TextFormatFlags.VerticalCenter);
        }

        private void SampleCalendar_FirstVisibleMonthChanged(object sender, EventArgs e)
        {
            if (CustomPaintingDemoToggleButton.Pressed)
                _CurrentCalendarAnimationHead = SampleCalendar.VisibleDateRange.Start;
        }

        private void SampleCalendar_PreviewMouseUp(object sender, PreviewMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            Point clientPoint = new Point(e.X, e.Y);
            CalendarHitTestResult hitTestResult = SampleCalendar.HitTest(clientPoint);

            if (hitTestResult == null)
                return;

            HitTestInfoButton.Text = "Item Type: " + hitTestResult.ItemType +
                ((hitTestResult.ItemType == CalendarHitTestItemType.DayOfWeek) ? "; Day of week: " + hitTestResult.DayOfWeek :
                "; Date: " + hitTestResult.Date.ToShortDateString());

            Ui.ContextMenu.ShowContextMenu(CalendarHitTestContextMenu,
                SampleCalendar.PointToScreen(clientPoint));
        }
    }
}
