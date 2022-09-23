using ClientConvertisseurV1.Exceptions;
using ClientConvertisseurV1.Models;
using ClientConvertisseurV1.Services;
using ClientConvertisseurV1.Warnings;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static System.Runtime.CompilerServices.RuntimeHelpers;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page
    {
        internal WSService service = WSService.GetInstance();
        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            ActionGetData();
            ConversionButton.Click += ConversionButton_Click;
        }

        private void ConversionButton_Click(object sender, RoutedEventArgs e)
        {            
            Devise devise = (Devise)this.DeviseChoiceBox.SelectedItem;
            if (devise == null)
            {
                new CustomWarning(CustomWarningType.NO_DEVISE_SELECTED, this);
                return;
            }
            double input = 0.0;
            try
            {
                input = Convert.ToDouble(this.MontEuInput.Text);
            }
            catch (FormatException)
            {
                new CustomWarning(CustomWarningType.WRONG_FORMAT, this);
                return;
            }

            double res = input * devise.Taux;
            this.MontDeviseOutput.Text = res.ToString();
        }

        private async void ActionGetData()
        {
            var result = await service.GetAllDevisesAsync();

            if(result.Count == 0)
            {
                new CustomWarning(CustomWarningType.WS_SERVICE_OUT, this);
            }
            this.DeviseChoiceBox.DataContext = new List<Devise>(result);
            //select default input to help user :)
            this.DeviseChoiceBox.SelectedIndex = 0;
        }

    }
}
