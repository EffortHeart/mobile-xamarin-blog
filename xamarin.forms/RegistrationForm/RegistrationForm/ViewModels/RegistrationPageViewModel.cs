using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using RegistrationForm.Models;
using Xamarin.Forms;

namespace RegistrationForm.ViewModels
{
    public class RegistrationPageViewModel : INotifyPropertyChanged
    {
        public ICommand AddACountryCommand { get; private set; }

        public RegistrationPageViewModel ()
        {
            AddACountryCommand = new Command(AddACountry);
        }

        void AddACountry ()
        {
            _locations.Add(new CountryStateProvince{
                Abbreviation = "XAM",
                Name = "Xamarin " + new Random(2).Next().ToString(),
                Country = "Xamarinia"
            });

            OnPropertyChanged (nameof (Countries));
            OnPropertyChanged (nameof (SelectedCountry));
            OnPropertyChanged (nameof (StatesProvinces));
            OnPropertyChanged (nameof (StateProvinceLabel));
        }

        string _selectedCountry = "United States";
        public string SelectedCountry {
            get {
                return _selectedCountry;
            }

            set {
                if (_selectedCountry != value) {
                    _selectedCountry = value;

                    OnPropertyChanged (nameof (SelectedCountry));
                    OnPropertyChanged (nameof (StatesProvinces));
                    OnPropertyChanged (nameof (StateProvinceLabel));
                }
            }
        }

        int _countriesSelectedIndex;
        public int CountriesSelectedIndex
        {
            get {
                return _countriesSelectedIndex;
            }
            set {
                if(_countriesSelectedIndex != value){
                    _countriesSelectedIndex = value;

                    OnPropertyChanged(nameof(CountriesSelectedIndex));
                    SelectedCountry = Countries[_countriesSelectedIndex];
                }
            }
        }

		public string CountryPlaceholder
		{
			get
			{
				return "Select a Country";
			}
		}

        public string StateProvinceLabel {
            get {
                if (_selectedCountry == "United States") {
                    return "State";
                } else {
                    return "Province";
                }
            }
        }

        public List<string> Countries {
            get {
                return _locations.Select (x => x.Country).Distinct ().ToList ();
            }
        }

        public List<string> StatesProvinces {
            get {
                if (_selectedCountry == "United States") {
                    return _locations.Where (l => l.Country == "United States").Select (x => x.Name).Distinct ().ToList ();
                } else {
                    return _locations.Where (l => l.Country != "United States").Select (x => x.Name).Distinct ().ToList ();
                }
            }
        }

        private ObservableCollection<CountryStateProvince> _locations = new ObservableCollection<CountryStateProvince>{
            new CountryStateProvince {
                Abbreviation = "CA",
                Name = "California",
                Country = "United States"
            },
            new CountryStateProvince {
                Abbreviation = "MA",
                Name = "Massachusetts",
                Country="United States"
            },
            new CountryStateProvince {
                Abbreviation = "WA",
                Name = "Washington",
                Country="United States"
            },
            new CountryStateProvince {
                Abbreviation = "AB",
                Name = "Alberta",
                Country="Canada"
            },
            new CountryStateProvince {
                Abbreviation = "BC",
                Name = "British Columbia",
                Country="Canada"
            },
            new CountryStateProvince {
                Abbreviation = "MB",
                Name = "Manitoba",
                Country="Canada"
            },
            new CountryStateProvince {
                Abbreviation = "NB",
                Name = "New Brunswick",
                Country="Canada"
            }
        };


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged (string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null) {
                PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
            }
        }

    }


}
