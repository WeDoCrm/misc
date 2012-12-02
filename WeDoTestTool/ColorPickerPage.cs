using System;
using System.Drawing;

namespace Elegant.Ui.Samples.ControlsSample
{
	public partial class ColorPickerPage : SamplePageBase
	{
		public ColorPickerPage()
		{
			InitializeComponent();

			Octagon.Pressed = true;

			BackgroundColorPicker.RecentColor = BackgroundColorPicker.SelectedColor;
			BorderColorPicker.RecentColor = BorderColorPicker.SelectedColor;

			PopulateSelectedShapeComboBox();
		}

		private void PopulateSelectedShapeComboBox()
		{
			Array shapeTypes = Enum.GetValues(typeof(ShapeType));
			ShapeTypeItem[] shapeTypeItems = new ShapeTypeItem[shapeTypes.Length];
			for (int i = 0; i < shapeTypes.Length; i++)
			{
				ShapeType shapeType = (ShapeType)shapeTypes.GetValue(i);
				shapeTypeItems[i] = new ShapeTypeItem(GetShapeName(shapeType), shapeType);
			}

			SelectedShapeComboBox.DataSource = shapeTypeItems;
			SelectedShapeComboBox.SelectedIndex = 0;
			SelectedShapeComboBox.SelectedIndexChanged += SelectedShapeComboBox_SelectedIndexChanged;
		}

		private static string GetShapeName(ShapeType shapeType)
		{
			switch (shapeType)
			{
				case ShapeType.Octagon:
					return "Octagon";
				case ShapeType.Star:
					return "Star";
				case ShapeType.Circle:
					return "Circle";
				case ShapeType.RoundedRectangle:
					return "Rounded rectangle";
			}
			return string.Empty;
		}

		void SelectedShapeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(_selectedShapeChanging)
				return;

			ShapeTypeItem shapeType = (ShapeTypeItem)SelectedShapeComboBox.SelectedItem;
			switch (shapeType.ShapeType)
			{
				case ShapeType.Star:
					Star.Pressed = true;
					break;
				case ShapeType.Octagon:
					Octagon.Pressed = true;
					break;
				case ShapeType.Circle:
					Circle.Pressed = true;
					break;
				case ShapeType.RoundedRectangle:
					RoundedRectangle.Pressed = true;
					break;
			}
		}

		private bool _selectedShapeChanging;

		private ShapeControl _selectedShape;

		private void Shape_PressedChanged(object sender, EventArgs e)
		{
			_selectedShape = (ShapeControl)sender;
			if (!_selectedShape.Pressed)
				return;

			_selectedShapeChanging = true;
			try
			{
				BorderColorPicker.SelectedColor = _selectedShape.BorderColor;
				BackgroundColorPicker.SelectedColor = _selectedShape.BackgroundColor;
				
				foreach (ShapeTypeItem item in SelectedShapeComboBox.Items)
				{
					if (item.ShapeType == _selectedShape.ShapeType)
					{
						SelectedShapeComboBox.SelectedItem = item;
						break;
					}
				}
			}
			finally
			{
				_selectedShapeChanging = false;
			}
		}

		private void BorderColorPicker_SelectedColorChanged(object sender, ColorPropertyChangedEventArgs e)
		{
			_selectedShape.BorderColor = BorderColorPicker.SelectedColor;
		}

		private void BackgroundColorPicker_SelectedColorChanged(object sender, ColorPropertyChangedEventArgs e)
		{
			_selectedShape.BackgroundColor = BackgroundColorPicker.SelectedColor;
		}

		private ColorDialog _colorDialog;

		private void ShowColorDialogButton_Click(object sender, EventArgs e)
		{
			if (_colorDialog == null)
				_colorDialog = new ColorDialog();

			_colorDialog.ColorSelectionMode = HSLRadioButton.Checked ? ColorSelectionMode.HSL : ColorSelectionMode.LSH;
			_colorDialog.ModeSelectorVisible = ModeSelectionVisibleCheckBox.Checked;

			_colorDialog.ShowDialog();
		}
	}
}
