using Programming.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programming
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            EnumsListBox.Items.AddRange(new string[]
            {
                "Color",
                "EducationForm",
                "Genre",
                "Manufactures",
                "Season",
                "Weekday"
            });

            EnumsListBox.SelectedIndex = 0;
            SeasonComboBox.Items.AddRange(new string[]
            {
                "Spring",
                "Summer",
                "Autumn",
                "Winter"
            });

            SeasonComboBox.SelectedIndex = 0;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void EnumsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValuesListBox.Items.Clear();

            string selectedEnum = EnumsListBox.SelectedItem.ToString();

            switch (selectedEnum)
            {
                case "Color":
                    foreach (var value in Enum.GetValues(typeof(Model.Color)))
                        ValuesListBox.Items.Add(value);
                    break;
                case "EducationForm":
                    foreach (var value in Enum.GetValues(typeof(EducationForm)))
                        ValuesListBox.Items.Add(value);
                    break;
                case "Genre":
                    foreach (var value in Enum.GetValues(typeof(Genre)))
                        ValuesListBox.Items.Add(value);
                    break;
                case "Manufactures":
                    foreach (var value in Enum.GetValues(typeof(Manufactures)))
                        ValuesListBox.Items.Add(value);
                    break;
                case "Season":
                    foreach (var value in Enum.GetValues(typeof(Season)))
                        ValuesListBox.Items.Add(value);
                    break;
                case "Weekday":
                    foreach (var value in Enum.GetValues(typeof(Weekday)))
                        ValuesListBox.Items.Add(value);
                    break;
            }
        }
        private void ValuesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValuesListBox.SelectedItem == null) return;

            object selectedValue = ValuesListBox.SelectedItem;
            int intValue = (int)selectedValue;
            IntValueTextBox.Text = intValue.ToString();
        }

        private void ParseButton_Click(object sender, EventArgs e)
        {
            string input = ParseTextBox.Text;

            if (Enum.TryParse<Weekday>(input, out Weekday result))
            {
                if (Enum.IsDefined(typeof(Weekday), result))
                {
                    int dayNumber = (int)result + 1;
                    ResultTextBox.Text = $"Это день недели ({result} = {dayNumber})";
                }
                else
                {
                    ResultTextBox.Text = "Нет такого дня недели";
                }
            }
            else
            {
                ResultTextBox.Text = "Нет такого дня недели";
            }
        }

        
        private void SeasonButton_Click(object sender, EventArgs e)
        {
            string selectedSeason = SeasonComboBox.SelectedItem.ToString();

            TabPage enumsTab = MainTabControl.TabPages["Enums"];

            switch (selectedSeason)
            {
                case "Spring":
                    this.BackColor = System.Drawing.Color.FromArgb(85, 156, 69);
                    enumsTab.BackColor = System.Drawing.Color.FromArgb(85, 156, 69);
                    break;
                case "Summer":
                    MessageBox.Show("Ура! Солнце!");
                    break;
                case "Autumn":
                    this.BackColor = System.Drawing.Color.FromArgb(226, 156, 69);
                    enumsTab.BackColor = System.Drawing.Color.FromArgb(226, 156, 69);
                    break;
                case "Winter":
                    MessageBox.Show("Бррр! Холодно!");
                    this.BackColor = System.Drawing.Color.LightBlue;
                    enumsTab.BackColor = System.Drawing.Color.LightBlue;
                    break;
            }
        }

        private void ParseTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
