using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimpleTextEditorWithImages
{
    public partial class Form1 : Form
    {
        private TextBox textBox;

        public Form1()
        {
            InitializeComponent();
            InitializeTextBox();
        }

        private void InitializeTextBox()
        {
            textBox = new TextBox();
            textBox.Multiline = true;
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.Dock = DockStyle.Fill;
            Controls.Add(textBox);
        }

        private void InsertImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Оберіть зображення";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;

                // Отримуємо зображення для вставки
                Image image = Image.FromFile(selectedImagePath);

                // Вставляємо зображення у TextBox
                Clipboard.SetImage(image);
                textBox.Paste();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Перевіряємо, чи натиснута клавіша Ctrl і V
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Вставляємо зображення у TextBox
                InsertImage();
            }
        }
    }
}
