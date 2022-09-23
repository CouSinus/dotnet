using ClientConvertisseurV2.Exceptions;
using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using ClientConvertisseurV2.Warnings;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing.Constraints;

namespace ClientConvertisseurV2.ViewModels
{
    internal class ConvertisseurEuroViewModel : ObservableObject
    {
        internal WSService service = WSService.GetInstance();

        private ObservableCollection<Devise> listDevise;

        private String mntEuros;

        public String MntEuros
        {
            get { return mntEuros; }
            set { 
                mntEuros = value;
                OnPropertyChanged();
            }
        }

        private Devise deviseSelected;

        public Devise DeviseSelected
        {
            get { return deviseSelected; }
            set { 
                deviseSelected = value;
                OnPropertyChanged();
            }
        }

        private double mntDevise;

        public double MntDevise
        {
            get { return mntDevise; }
            set { 
                mntDevise = value;
                OnPropertyChanged();
            }
        }


        public IRelayCommand BtnSetConversion { get; }
        

        public ObservableCollection<Devise> ListDevise
        {
			get { return listDevise; }
			set { 
				listDevise = value;
				OnPropertyChanged();
			}
		}

		public ConvertisseurEuroViewModel()
		{
			ActionGetData();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        private void ActionSetConversion()
        {
            float mntEuros;
            try
            {
                mntEuros = float.Parse(MntEuros);
            }catch(FormatException fe)
            {
                new CustomWarning(CustomWarningType.WRONG_FORMAT);
                return;
            }catch(ArgumentNullException age)
            {
                new CustomWarning(CustomWarningType.NO_INPUT);
                return;
            }

            if(DeviseSelected == null)
            {
                new CustomWarning(CustomWarningType.NO_DEVISE_SELECTED);
                return;
            }
            MntDevise = DeviseSelected.Taux * float.Parse(MntEuros);
        }

        private async void ActionGetData()
        {
            var result = await service.GetAllDevisesAsync();
            if(result.Count == 0)
            {
                new CustomWarning(CustomWarningType.WS_SERVICE_OUT);
            }
            ListDevise = new ObservableCollection<Devise>(result);
        }
    }
}
