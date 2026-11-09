using Projektv2.Models;

namespace Projektv2.Views;

public partial class CounterView : ContentView
{
	private Counter _counter;

    public event EventHandler? ChangeValue;

    public CounterView(Counter counter)
	{
		InitializeComponent();
		_counter = counter;

		NameLabel.Text = _counter.Name;
		CountLabel.Text = _counter.Count.ToString();
	}

	private void Plus_Clicked(object sender, EventArgs e)
	{
		_counter.Count++;
		UpdateCount();
	}

	private void Minus_Clicked(object sender, EventArgs e)
	{
		_counter.Count--;
		UpdateCount();
	}

	private void UpdateCount()
	{
		CountLabel.Text = _counter.Count.ToString();

        ChangeValue?.Invoke(this, EventArgs.Empty);
    }
}