﻿namespace ToDoListApplication;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("NewPage", typeof(ToDoList));
	}
}
