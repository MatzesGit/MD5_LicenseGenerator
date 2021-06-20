using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LicenseGenerator.Core;

namespace LicenseGenerator.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für AboutView.xaml
    /// </summary>
    /// 
    public partial class AboutView : UserControl
    {
        public AboutView()
        {
            InitializeComponent();

            RichTextBox _RichTextBox = CreateAndLoadRichTextBox();

            Button button = new Button();
            Button NewButton = button;
            NewButton.Width = 100;

            AboutView_Stackpanel.Children.Add(_RichTextBox);

        }

        private RichTextBox CreateAndLoadRichTextBox()
        {
            string[] Items_Text = GetAboutText.Items_Text();

            RichTextBox richTextBox = new RichTextBox();
            RichTextBox _RichTextBox = richTextBox;
            _RichTextBox.BorderThickness = new Thickness(0);
            _RichTextBox.Background = Brushes.Transparent;
            _RichTextBox.Width = 660;
            _RichTextBox.HorizontalAlignment = HorizontalAlignment.Left;

            FlowDocument _FlowDocument = new FlowDocument();
            // Create a paragraph with text  
            Paragraph _Paragraph_Title = new Paragraph();
            Paragraph _Paragraph_Version = new Paragraph();
            Paragraph _Paragraph_Headline = new Paragraph();
            Paragraph _Paragraph_Description = new Paragraph();

            _Paragraph_Title.FontSize = 17;
            _Paragraph_Title.Foreground = Brushes.Black;
            _Paragraph_Title.FontWeight = FontWeights.Bold;
            _Paragraph_Title.Inlines.Add(new Run(Items_Text[((int)GetAboutText.About_Text_Enum.Title_Text)]));

            _Paragraph_Version.FontSize = 15;
            _Paragraph_Version.Foreground = Brushes.Black;
            _Paragraph_Version.FontWeight = FontWeights.Bold;
            _Paragraph_Version.Inlines.Add(new Run(Items_Text[((int)GetAboutText.About_Text_Enum.Version_Text)]));

            _Paragraph_Headline.FontSize = 15;
            _Paragraph_Headline.Foreground = Brushes.Black;
            _Paragraph_Headline.FontWeight = FontWeights.Bold;
            _Paragraph_Headline.Inlines.Add(new Run(Items_Text[((int)GetAboutText.About_Text_Enum.Headline_Text)]));

            _Paragraph_Description.FontSize = 13;
            _Paragraph_Description.Foreground = Brushes.Black;
            _Paragraph_Description.FontWeight = FontWeights.Bold;
            _Paragraph_Description.Inlines.Add(new Run(Items_Text[((int)GetAboutText.About_Text_Enum.Description_Text)]));

            _FlowDocument.Blocks.Add(_Paragraph_Title);
            _FlowDocument.Blocks.Add(_Paragraph_Version);
            _FlowDocument.Blocks.Add(_Paragraph_Headline);
            _FlowDocument.Blocks.Add(_Paragraph_Description);

            // Adding this RichTextBox in the form
            _RichTextBox.Document = _FlowDocument;

            return _RichTextBox;
        }
    }
}