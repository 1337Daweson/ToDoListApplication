using ToDoListApplication.Models;
using ToDoListApplication.Pages;

namespace ToDoListApplication;

public partial class ItemsPage : ContentPage
{
    public ItemsPage()
    {
        InitializeComponent();
        TaskItem item = new TaskItem() { Name = "Cleaning", Description = "Clean my room especially", IsComplete = false };
        TaskItem item2 = new TaskItem() { Name = "PC setup", Description = "Clean necessary files", IsComplete = false };
        TaskItem item3 = new TaskItem() { Name = "Watch OnePiece", Description = "Episode 965", IsComplete = false };
        TaskItem item4 = new TaskItem() { Name = "Prepair for school", Description = "especially monday for mobile/web app development", IsComplete = false };
        TaskItem item5 = new TaskItem() { Name = "Play Witcher 3", Description = "DLC Blood and Wine", IsComplete = false };
        TaskItem item6 = new TaskItem() { Name = "Job", Description = "Create Profiles as saved filters", IsComplete = false };

        App.manager.Items.Add(item);
        App.manager.Items.Add(item2);
        App.manager.Items.Add(item3);
        App.manager.Items.Add(item4);
        App.manager.Items.Add(item5);
        App.manager.Items.Add(item6);

        BindingContext = App.manager;
        Title = "To-Do List";


        MessagingCenter.Subscribe<ItemDetailPage, TaskItem>(this, UpdateListMessage, (sender, item) =>
        {
            // Call the UpdateToDoList method
            UpdateToDoList();
        });

        MessagingCenter.Subscribe<ItemDetailPage, TaskItem>(this, DeleteTaskMessage, (sender, args) =>
        {
            DeleteTask(args);
        });
    }

    private async void AddToDoButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddPage());
    }

    private void ToDoListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
        {
            return;
        }

        TaskItem selectedTask = e.SelectedItem as TaskItem;

        Navigation.PushAsync(new ItemDetailPage(selectedTask));

        ToDoListView.SelectedItem = null;
    }

    public void UpdateToDoList()
    {
        ToDoListView.ItemsSource = null;
        ToDoListView.ItemsSource = App.manager.Items;
    }

    public void DeleteTask(TaskItem task)
    {
        App.manager.Items.Remove(task);
        UpdateToDoList();
    }

    public static readonly string UpdateListMessage = "UpdateListMessage";
    public static readonly string DeleteTaskMessage = "DeleteTaskMessage";
}