using ToDoListApplication.Models;

namespace ToDoListApplication;

public class ToDoList : ContentPage
{
    private ListView listView;
    private Entry taskEntry;
    private Button addButton;
    public ToDoList()
	{
        Title = "To-Do List";
        listView = new ListView();
        taskEntry = new Entry();
        addButton = new Button();

        taskEntry.Placeholder = "Enter new task";

        addButton.Text = "Add";
        addButton.Clicked += AddButton_Clicked;

        listView.ItemTemplate = new DataTemplate(typeof(TaskItem));
        listView.ItemSelected += ListView_ItemSelected;
        listView.ItemsSource = App.ToDoManager
        Content = new VerticalStackLayout
		{
			Children = {
                listView,
                taskEntry,
                addButton,
                new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to First Page!"
				}
			}
		};
	}

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void AddButton_Clicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    public class ToDoItemCell : ViewCell
    {
        public ToDoItemCell()
        {
            var label = new Label();
            label.SetBinding(Label.TextProperty, "Name");
            View = label;
        }
    }
}