using System.Drawing;
using System.Windows.Forms;

namespace AppSenAgriculture
{
    internal static class AppTheme
    {
        internal static readonly Color SavannaGreen = Color.FromArgb(45, 80, 22);
        internal static readonly Color DarkSidebar = Color.FromArgb(26, 46, 15);
        internal static readonly Color WarmCream = Color.FromArgb(245, 240, 232);
        internal static readonly Color Ochre = Color.FromArgb(196, 137, 42);
        internal static readonly Color BaobabOrange = Color.FromArgb(232, 101, 26);
        internal static readonly Color FreshGreen = Color.FromArgb(90, 138, 46);
        internal static readonly Color Anthracite = Color.FromArgb(44, 24, 16);
        internal static readonly Color Danger = Color.FromArgb(140, 54, 32);
        internal static readonly Color MutedText = Color.FromArgb(95, 74, 60);
        internal static readonly Color GridLine = Color.FromArgb(230, 220, 204);

        internal static Font TitleFont(float size)
        {
            return new Font("Playfair Display", size, FontStyle.Bold);
        }

        internal static Font UiFont(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font("Source Sans 3", size, style);
        }

        internal static Font DataFont(float size)
        {
            return new Font("JetBrains Mono", size);
        }

        internal static void ApplyFormTheme(Form form)
        {
            form.BackColor = WarmCream;
            form.ForeColor = Anthracite;
            form.Font = UiFont(12F);
        }

        internal static void StyleInput(TextBox textBox)
        {
            textBox.BackColor = Color.White;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = UiFont(12F);
        }

        internal static void StyleComboBox(ComboBox comboBox)
        {
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = UiFont(12F);
            comboBox.BackColor = Color.White;
        }

        internal static void StyleLabel(Label label)
        {
            label.Font = UiFont(12F, FontStyle.Bold);
            label.ForeColor = Anthracite;
        }

        internal static void StyleButton(Button button, Color backColor, Color foreColor)
        {
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Ochre;
            button.FlatAppearance.BorderSize = backColor == Color.White ? 1 : 0;
            button.Font = UiFont(11F, FontStyle.Bold);
            button.Height = 38;
        }

        internal static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = SavannaGreen;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = UiFont(11F, FontStyle.Bold);
            grid.DefaultCellStyle.Font = DataFont(10F);
            grid.DefaultCellStyle.SelectionBackColor = Ochre;
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.AlternatingRowsDefaultCellStyle.BackColor = WarmCream;
            grid.RowHeadersVisible = false;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = GridLine;
        }
    }
}
