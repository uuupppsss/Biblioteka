using Biblioteka.mvvm.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.mvvm.viewmodel
{
    public class BookDetailPageViewModel:BaseVM
    {
        public Book Book { get; set; }
        public CommandVM BackClick {  get; set; }

        public BookDetailPageViewModel()
        {
            BackClick = new CommandVM(async()=>
            {
                await Shell.Current.GoToAsync("MainPage");
            });
        }

    }
}
