using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MuseumFinder.Views;
using MuseumFinder.Model;
using MuseumFinder.Services;

namespace MuseumFinder.ViewModels
{

    public partial class MuseumListPageViewModel : ObservableObject
    {
        public static List<MuseumModel> MuseumsListForSearch { get; private set; } = new List<MuseumModel>();
        public ObservableCollection<MuseumModel> Museums { get; set; } = new ObservableCollection<MuseumModel>();

        private readonly IMuseumService _museumService;
        public MuseumListPageViewModel(IMuseumService museumService)
        {
            _museumService = museumService;
        }


        [ICommand]
        public async void GetMuseumList()
        {
            Museums.Clear();
            var studentList = await _museumService.GetMuseumList();
            if (studentList?.Count > 0)
            {
                studentList = studentList.OrderBy(f => f.Name).ToList();
                foreach (var student in studentList)
                {
                    Museums.Add(student);
                }
                MuseumsListForSearch.Clear();
                MuseumsListForSearch.AddRange(studentList);
            }
        }

        [ICommand]
        public async void AddUpdateMuseum()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateMuseumDetail));
        }

        
        [ICommand]
        public async void DisplayAction(MuseumModel museumModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Выберите опцию", "ОК", null, "Изменить", "Удалить");
            if (response == "Изменить")
            {

                var navParam = new Dictionary<string, object>();
                navParam.Add("MuseumDetail", museumModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateMuseumDetail), navParam);
            }
            else if (response == "Удалить")
            {
                var delResponse = await _museumService.DeleteMuseum(museumModel);
                if (delResponse > 0)
                {
                    GetMuseumList();
                }
            }

        }
    }
}
