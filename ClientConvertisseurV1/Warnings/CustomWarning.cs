using ClientConvertisseurV1.Views;
using ClientConvertisseurV1.Warnings;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV1.Exceptions
{
    internal class CustomWarning
    {
        public CustomWarning(CustomWarningType warningType, Page page)
        {
            String message;

            switch(warningType)
            {
                case CustomWarningType.WS_SERVICE_OUT:
                    message = "Le web service n'est pas joignable";
                    break;
                case CustomWarningType.WRONG_FORMAT:
                    message = "Veuillez renseigner un montant en euro";
                    break;
                case CustomWarningType.NO_DEVISE_SELECTED:
                    message = "Veuillez renseigner une devise";
                    break;
                default:
                    throw new Exception("Warning Exception does not exist");
            }
           DisplayWarningDialog(message, page);
        }

        private async void DisplayWarningDialog(String message, Page page)
        {
            ContentDialog warningDialog = new ContentDialog
            {
                Title = "Erreur",
                Content = message,
                CloseButtonText = "Ok"
            };

            warningDialog.XamlRoot = page.Content.XamlRoot;

            try
            {
                ContentDialogResult result = await warningDialog.ShowAsync();
            }catch(COMException come)
            {
                DisplayWarningDialog("error", page);
            }
            
        }
    }
}
