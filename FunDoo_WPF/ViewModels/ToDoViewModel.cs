using FunDoo_WPF.DAL;
using FunDoo_WPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FunDoo_WPF.ViewModels
{
    internal class ToDoViewModel: INotifyPropertyChanged
    {
        public string WindowTitle
        {
            get { return "FunDoo To Do List Manager"; }
        }

        private List<ToDoItemModel> toDoItemModels;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<ToDoItemModel> ToDoItemModels 
        {
            get
            {
                return toDoItemModels;
            }
            private set 
            { 
                toDoItemModels = value;
                RaisePropertyChanged("ToDoItemModels");
            }
        }

        public ToDoViewModel()
        {
            Load_Async();
        }

        private async void Load_Async()
        {
            try
            {
                this.ToDoItemModels = await FunDoo_API.GetAllToDoItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.ToString() + ".Load_Async\n\n" + ex.Message, "Error found", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
