using ToDoListApplication.Manager;
using ToDoListApplication.Models;

namespace ToDoListApplication;

public class ToDoList : ContentPage
{
    StackLayout toDoListLayout;

    public ToDoList()
    {
        Title = "To-Do List";

        TaskItem item = new TaskItem() { Name = "Walk a dog", Description = "Take a long trip", IsComplete = false };
        TaskItem item2 = new TaskItem() { Name = "Clean", Description = "Clean my bedrom and kitchen", IsComplete = false };
        TaskItem item3 = new TaskItem() { Name = "Beat the meat", Description = "Jerk OFF!", IsComplete = false };
        TaskItem item4 = new TaskItem() { Name = "Koitus", Description = "Fuck my girl", IsComplete = false };

        App.manager.Items.Add(item);
        App.manager.Items.Add(item2);
        App.manager.Items.Add(item3);
        App.manager.Items.Add(item4);
        

        toDoListLayout = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
            VerticalOptions = LayoutOptions.FillAndExpand,
            Padding = new Thickness(20, 20, 20, 20)
        };

        foreach (var toDoItem in App.manager.Items)
        {
            StackLayout toDoItemLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 20
            };

            Label nameLabel = new Label
            {
                Text = toDoItem.Name,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center
            };

            Label descriptionLabel = new Label
            {
                Text = toDoItem.Description,
                VerticalOptions = LayoutOptions.Center
            };

            Switch isCompleteSwitch = new Switch
            {
                IsToggled = toDoItem.IsComplete,
                VerticalOptions = LayoutOptions.Center
            };

            toDoItemLayout.Children.Add(nameLabel);
            toDoItemLayout.Children.Add(descriptionLabel);
            toDoItemLayout.Children.Add(isCompleteSwitch);
            toDoListLayout.Children.Add(toDoItemLayout);
        }

        Button addToDoButton = new Button
        {
            Text = "Add To-Do",
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.End,
            BackgroundColor = Color.FromHex("#2196F3"),
            TextColor = Color.FromHex("#FFFFFF")
        };

        addToDoButton.Clicked += AddToDoButton_Clicked;

        Content = new StackLayout
        {
            Children =
                {
                    toDoListLayout,
                    addToDoButton
                }
        };
    }

    private async void AddToDoButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddPage());

        
        

    }

    public void UpdateToDoList()
    {
        toDoListLayout.Children.Clear();

        // Add a StackLayout for each TaskItem in the data source
        foreach (TaskItem item in App.manager.Items)
        {
            StackLayout toDoItemLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 20
            };

            Label nameLabel = new Label
            {
                Text = item.Name,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center
            };

            Label descriptionLabel = new Label
            {
                Text = item.Description,
                VerticalOptions = LayoutOptions.Center
            };

            Switch isCompleteSwitch = new Switch
            {
                IsToggled = item.IsComplete,
                VerticalOptions = LayoutOptions.Center
            };

            toDoItemLayout.Children.Add(nameLabel);
            toDoItemLayout.Children.Add(descriptionLabel);
            toDoItemLayout.Children.Add(isCompleteSwitch);
            toDoListLayout.Children.Add(toDoItemLayout);

            int a = toDoListLayout.Count();
        }
    }
    



}