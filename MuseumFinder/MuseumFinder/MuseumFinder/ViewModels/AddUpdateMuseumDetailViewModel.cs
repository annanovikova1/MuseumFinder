using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MuseumFinder.Model;
using MuseumFinder.Services;
using System.Text.RegularExpressions;

namespace MuseumFinder.ViewModels
{
    [QueryProperty(nameof(MuseumDetail), "MuseumDetail")]
    public partial class AddUpdateMuseumDetailViewModel : ObservableObject
    {

        [ObservableProperty]
        private MuseumModels _museumDetail = new MuseumModels();

        private readonly IMuseumService _museumService;
        public AddUpdateMuseumDetailViewModel(IMuseumService museumService)
        {
            _museumService = museumService;
        }


        public bool IsNull()
        {
            // bool flag = true;
            if (string.IsNullOrWhiteSpace(MuseumDetail.Name)
              && string.IsNullOrWhiteSpace(MuseumDetail.Address)
              && string.IsNullOrWhiteSpace(MuseumDetail.Path)
              && string.IsNullOrWhiteSpace(MuseumDetail.Phone)
              && string.IsNullOrWhiteSpace(MuseumDetail.Latitude)
              && string.IsNullOrWhiteSpace(MuseumDetail.Longitude)
              && string.IsNullOrWhiteSpace(MuseumDetail.Rating)
              && string.IsNullOrWhiteSpace(MuseumDetail.Year)
              ) return false;
            else return true;
        }

        public bool Validation()
        {
            //flag = true;

            string patternForPhone = @"^\+375[0-9]{9}$";
            string patternForYear = @"\d{4}";
            string patternForLantitude = @"^(\+|-)?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))$";
            string patternForLongitude = @"^(\+|-)?(?:180(?:(?:\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\.[0-9]{1,6})?))$";
            string patternForRating = @"\d,\d";


            if ((Regex.IsMatch(MuseumDetail.Phone, patternForPhone, RegexOptions.IgnoreCase)
                && (Regex.IsMatch(MuseumDetail.Latitude, patternForLantitude, RegexOptions.IgnoreCase))
                && (Regex.IsMatch(MuseumDetail.Longitude, patternForLongitude, RegexOptions.IgnoreCase))
                && (Regex.IsMatch(MuseumDetail.Rating, patternForRating, RegexOptions.IgnoreCase))
                && (Regex.IsMatch(MuseumDetail.Year, patternForYear, RegexOptions.IgnoreCase)))) return true;
            else return false;



        }
        /*
        if (Regex.IsMatch(MuseumDetail.Phone, patternForPhone, RegexOptions.IgnoreCase))
        {
             Shell.Current.DisplayAlert("ЕГОР КОРОЛЬ","", "ОК");
        }
        if (Regex.IsMatch(Convert.ToString(MuseumDetail.Latitude), patternForLantitude, RegexOptions.IgnoreCase))
        {
            Shell.Current.DisplayAlert("ЛАТИТУДЕ", "", "ОК");
        }
        if (Regex.IsMatch(Convert.ToString(MuseumDetail.Longitude), patternForLongitude, RegexOptions.IgnoreCase))
        {
            Shell.Current.DisplayAlert("ЛОНГИТУДЕ", "", "ОК");
        }
        if (Regex.IsMatch(Convert.ToString(MuseumDetail.Rating), patternForRating, RegexOptions.IgnoreCase))
        {
            Shell.Current.DisplayAlert("РЭЙТИНГ", "", "ОК");
        }
        if (Regex.IsMatch(Convert.ToString(MuseumDetail.Year), patternForYear, RegexOptions.IgnoreCase))
        {
            Shell.Current.DisplayAlert("ГОД", "", "ОК");
        }
        return flag;
    }
    */


        [ICommand]
        public async void AddUpdateMuseum()
        {

            int response = -1;
            if (_museumDetail.MuseumID > 0)
            {
                bool flag = IsNull();
                if (flag == false) { await Shell.Current.DisplayAlert("Внимание!", "Не все поля заполнены", "Ок"); }
                else
                {
                    flag = Validation();
                    if (flag == true)
                    {
                        response = await _museumService.UpdateMuseum(MuseumDetail);
                    }

                    else
                    {
                        await Shell.Current.DisplayAlert("Внимание!", "Данные введены неверно", "Ок");
                    }
                }
            }
            else
            {

                bool flag = IsNull();
                if (flag == false) { await Shell.Current.DisplayAlert("Внимание!", "Не все поля заполнены", "Ок"); }
                else
                {
                    flag = Validation();
                    if (flag == true)
                    {
                        response = await _museumService.AddMuseum(new Model.MuseumModels
                        {
                            Name = MuseumDetail.Name,
                            Address = MuseumDetail.Address,
                            Phone = MuseumDetail.Phone,
                            Year = MuseumDetail.Year,
                            Latitude = MuseumDetail.Latitude,
                            Longitude = MuseumDetail.Longitude,
                            Info = MuseumDetail.Info,
                            Path = MuseumDetail.Path,
                            Rating = MuseumDetail.Rating,
                        });
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Внимание!", "Неверно введены данные", "Ок");
                    }
                }


                if (response > 0)
                {
                    await Shell.Current.DisplayAlert("Запись добавлена", "Запись добавлена в таблицу Музеи", "Ок");
                }
                else
                {
                    // await Shell.Current.DisplayAlert("Внимание!", "Что-то пошло не так при добавлении записи", "Ок");
                }
            }
        }
    }
}
    
