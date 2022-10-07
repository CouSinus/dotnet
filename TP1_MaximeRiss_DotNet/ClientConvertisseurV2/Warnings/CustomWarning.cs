using ClientConvertisseurV2.Warnings;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Runtime.InteropServices;

namespace ClientConvertisseurV2.Exceptions
{
    internal class CustomWarning
    {
        public CustomWarning(CustomWarningType warningType)
        {
            String message;

            switch(warningType)
            {
                case CustomWarningType.WS_SERVICE_OUT:
                    message = "Le web service n'est pas joignable";
                    break;
                case CustomWarningType.NO_INPUT:
                case CustomWarningType.WRONG_FORMAT:
                    message = "Veuillez renseigner un montant en euro";
                    break;
                case CustomWarningType.NO_DEVISE_SELECTED:
                    message = "Veuillez renseigner une devise";
                    break;
                default:
                    throw new Exception("Warning Exception does not exist");
            }
           DisplayWarningDialog(message);
        }

        private async void DisplayWarningDialog(String message)
        {
            ContentDialog warningDialog = new ContentDialog
            {
                Title = "Erreur",
                Content = message,
                CloseButtonText = "Ok"
            };

            warningDialog.XamlRoot = App.MainRoot.XamlRoot;

            try
            {
                ContentDialogResult result = await warningDialog.ShowAsync();
            }catch(COMException come)
            {
                DisplayWarningDialog("error");
            }
            
        }
    }
}
