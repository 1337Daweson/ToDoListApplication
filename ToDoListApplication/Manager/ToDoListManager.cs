using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApplication.Models;

namespace ToDoListApplication.Manager
{
    public class ToDoListManager
    {
        public ObservableCollection<TaskItem> Items { get; set; }

        public ToDoListManager()
        {
            Items = new ObservableCollection<TaskItem>();
        }
    }



}
