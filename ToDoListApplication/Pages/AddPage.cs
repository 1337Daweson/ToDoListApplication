using ToDoListApplication;
using ToDoListApplication.Models;

public class AddPage : ContentPage
{
    private Entry taskEntry = new Entry { Placeholder = "Task name" };
    private Entry descEntry = new Entry { Placeholder = "Task description" };
    private Switch isCompleteSwitch = new Switch { IsToggled = false };
    private Button saveButton = new Button { Text = "Save", BackgroundColor = Color.FromHex("#4169e1"), TextColor = Color.FromHex("#FFFFFF") };

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


        // Navigate back to the main page
        await Navigation.PopAsync();


    }
}