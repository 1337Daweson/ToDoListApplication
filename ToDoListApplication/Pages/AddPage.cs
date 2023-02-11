//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using ToDoListApplication.Models;
//using ToDoListApplication.Manager;

//namespace ToDoListApplication.Pages
//{
//    public class AddPage : ContentPage
//    {
//            Entry taskEntry = new Entry
//            {
//                Placeholder = "Task name"
//            };

//            Entry descriptionEntry = new Entry
//            {
//                Placeholder = "Task description"
//            };

//            Switch isCompleteSwitch = new Switch
//            {
//                IsToggled = false
//            };

//            Button saveButton = new Button
//            {
//                Text = "Save",
//                HorizontalOptions = LayoutOptions.EndAndExpand
//            };

//            public AddPage()
//            {
//                Title = "Add Task";

//                saveButton.Clicked += SaveButton_Clicked;

//                Content = new StackLayout
//                {
//                    Margin = 30,
//                    Children =
//                {
//                    taskEntry,
//                    descriptionEntry,
//                    new StackLayout
//                    {
//                        Orientation = StackOrientation.Horizontal,
//                        Children =
//                        {
//                            new Label
//                            {
//                                Text = "Is Complete"
//                            },
//                            isCompleteSwitch
//                        }
//                    },
//                    saveButton
//                }
//                };
//            }

//        private async void SaveButton_Clicked(object sender, EventArgs e)
//        {
//            var toDoItem = new TaskItem
//            {
//                Name = taskEntry.Text,
//                Description = descriptionEntry.Text,
//                IsComplete = isCompleteSwitch.IsToggled
//            };

//            App.manager.Items.Add(toDoItem);
//            await Navigation.PopAsync();
//        }

//    }
//}


using ToDoListApplication;
using ToDoListApplication.Models;

public class AddPage : ContentPage
{
    private Entry taskEntry = new Entry { Placeholder = "Task name" };
    private Entry descEntry = new Entry { Placeholder = "Task description" };
    private Switch isCompleteSwitch = new Switch { IsToggled = false };
    private Button saveButton = new Button { Text = "Save" };

    public AddPage()
    {
        Title = "Add ToDo Item";

        StackLayout stackLayout = new StackLayout
        {
            Children = {
                taskEntry,
                descEntry,
                isCompleteSwitch,
                saveButton
            }
        };

        Content = stackLayout;

        saveButton.Clicked += SaveButton_Clicked;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Create a new ToDoItem with the entered information
        TaskItem newItem = new TaskItem
        {
            Name = taskEntry.Text,
            Description = descEntry.Text,
            IsComplete = isCompleteSwitch.IsToggled
        };

        // Add the new item to the data source
        App.manager.Items.Add(newItem);


        foreach (var page in Navigation.NavigationStack)
        {
            if (page is ToDoList)
            {
                (page as ToDoList).UpdateToDoList();
                break;
            }
        }


        // Navigate back to the main page
        await Navigation.PopAsync();


    }
}