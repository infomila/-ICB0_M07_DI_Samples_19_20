using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;

namespace _10_dialegs_flyouts
{
    class ColorPickerDialog: ContentDialog
    {
        CustomColorPicker cp;

        public Color UnColor { get; set; }
        public ContentDialogResult Result { get; set; }

        public ColorPickerDialog()
        {
            cp = new CustomColorPicker();
            cp.ClosedEvent += Cp_ClosedEvent;
            cp.CanceledEvent += Cp_CanceledEvent;

            this.Content = cp;
            
        }

        private void Cp_CanceledEvent(object sender, EventArgs e)
        {
            // informar de que el dialeg s'ha cancelat
            Result = ContentDialogResult.None;
            this.Hide();
        }

        private void Cp_ClosedEvent(object sender, EventArgs e)
        {
            Result = ContentDialogResult.Primary;
            UnColor = cp.UnColor;
            this.Hide();
        }
    }
}
