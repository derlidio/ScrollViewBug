using System.ComponentModel;

namespace ScrollViewBug;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

		MyStack.PropertyChanged += StackPropertyChanged;
	}

    private void StackPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
		if (e.PropertyName == "Y")
		{
            System.Diagnostics.Debug.WriteLine($"This Stack Y: {Math.Floor(MyStack.Y)}");
        }        
    }

    private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		MyGrid.IsVisible = !MyGrid.IsVisible;

		SemanticScreenReader.Announce(CounterBtn.Text);
    }
}