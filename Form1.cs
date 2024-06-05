using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NtfuLedenCheck
{
    public partial class Form1 : Form
    {
        //wat variabelen
        string ColorRed = "#F04540";
        string ColorGreen = "#39C349";


        public Form1()
        {
            InitializeComponent();

            DisplayResult.Visible = false;
        }


        //valideer de input van de textboxen
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            var tb = (TextBox)sender;

            if (tb.Name == "LidNummer")
            {
                //alleen nummers
                tb.Text = string.Concat(tb.Text.Where(Char.IsDigit));
            }
            else if (tb.Name == "PostCode")
            {
                //alleen hoofdletter en nummers
                tb.Text = Regex.Replace(tb.Text.ToUpper().Replace(" ", ""), "[^A-Z0-9]", "");
            }
            else if (tb.Name == "GeboorteDatum")
            {
                //alleen nummers en het '-' teken
                tb.Text = Regex.Replace(tb.Text, "[^0-9-]", "");
            }

            tb.Focus();
            tb.SelectionStart = tb.Text.Length;
            tb.BackColor = Color.White;
        }


        //de button click
        private async void button1_Click(object sender, EventArgs e)
        {
            bool ErrorFound = false;
            DisplayResult.Visible = false;
            LidNummer.BackColor = Color.White;
            PostCode.BackColor = Color.White;
            GeboorteDatum.BackColor = Color.White;

            //lidnummer verplicht
            if (string.IsNullOrEmpty(LidNummer.Text) || LidNummer.Text.Length != 6)
            {
                LidNummer.BackColor = ColorTranslator.FromHtml(ColorRed);
                ErrorFound = true;
            }

            //indien postcode dan moet tussen 4 en 6 tekens land zijn (ook belgische en duitse postcodes toestaan)
            if (!string.IsNullOrEmpty(PostCode.Text) && (PostCode.Text.Length < 4 || PostCode.Text.Length > 6))
            {
                PostCode.BackColor = ColorTranslator.FromHtml(ColorRed);
                ErrorFound = true;
            }

            //indien geboortedaum dan moet lengte minimaal 8 zijn
            if (!string.IsNullOrEmpty(GeboorteDatum.Text) && GeboorteDatum.Text.Length < 8)
            {
                GeboorteDatum.BackColor = ColorTranslator.FromHtml(ColorRed);
                ErrorFound = true;
            }

            //postcode of geboortedatum is verplicht
            if (string.IsNullOrEmpty(PostCode.Text) && string.IsNullOrEmpty(GeboorteDatum.Text))
            {
                PostCode.BackColor = ColorTranslator.FromHtml(ColorRed);
                GeboorteDatum.BackColor = ColorTranslator.FromHtml(ColorRed);
                ErrorFound = true;
            }

            //bij fout gevonden dan stoppen
            if (ErrorFound)
                return;

            //maak van de geboortedaum een datetime object
            DateTime gbdatum = DateTime.TryParse(GeboorteDatum.Text, out gbdatum) ? gbdatum : new DateTime();

            //doe de call naar de ntfu api
            try
            {
                var Resultaat = await LedenCheck.DoLedenCheck(Convert.ToInt32(LidNummer.Text), PostCode.Text, gbdatum);

                //toon het resultaat als een rood/groen vlak
                if (Resultaat == null || !Resultaat.is_lid)
                {
                    DisplayResult.BackColor = ColorTranslator.FromHtml(ColorRed);
                }
                else
                {
                    DisplayResult.BackColor = ColorTranslator.FromHtml(ColorGreen);
                }

                //toon het vlak
                DisplayResult.Visible = true;
            }
            catch (Exception ex)
            {
                //toon de foutmelding
                MessageBox.Show(ex.Message, "Fout!");
            }
        }
    }
}
