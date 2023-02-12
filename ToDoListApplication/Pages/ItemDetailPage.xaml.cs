using System.Threading.Tasks;
using ToDoListApplication.Models;

namespace ToDoListApplication.Pages;

public partial class ItemDetailPage : ContentPage
{
	public ItemDetailPage(TaskItem selected)
	{
		InitializeComponent();
        BindingContext = selected;
    }

	private void SaveChangesButton_Clicked(object sender, EventArgs e)
	{
        var taskItem = BindingContext as TaskItem;
        if (taskItem != null)
        {
            taskItem.Name = NameEntry.Text;
            taskItem.Description = DescEditor.Text;
            taskItem.IsComplete = isCompleteSwitch.IsToggled;

            MessagingCenter.Send(this, ItemsPage.UpdateListMessage, taskItem);

        }
        Navigation.PopAsync();
        
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        var taskItem = BindingContext as TaskItem;
        MessagingCenter.Send<ItemDetailPage, TaskItem>(this, ItemsPage.DeleteTaskMessage, taskItem);
        Navigation.PopAsync();

    }
}