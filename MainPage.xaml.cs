using Projektv2.Models;
using Projektv2.Views;
using Projektv2.Services;

namespace Projektv2
{
    public partial class MainPage : ContentPage
    {
        private List<Counter> counters = new List<Counter>();

        private bool upload = false;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (upload)
            {
                return;
            }

            counters = await SaveData.Upload();

            foreach (Counter counter in counters)
            {
                AddView(counter);
            }

            upload = true;
        }

        private async void AddCounter_Clicked(object sender, EventArgs e)
        {
            string name = NameEntry.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                DisplayAlert("Błąd", "Podaj nazwę licznika!", "OK");
                return;
            }

            int count = 0;

            if (!string.IsNullOrWhiteSpace(CountEntry.Text))
            {
                if (!int.TryParse(CountEntry.Text, out count))
                {
                    await DisplayAlert(
                        "Błąd",
                        "Podaj prawidłową wartość liczbową!",
                        "OK");

                    return;
                }
            }
            Counter counter = new Counter(name, count);

            counters.Add(counter);

            AddView(counter);

            await SaveData.Save(counters);

            NameEntry.Text = "";
        }

        private void AddView(Counter counter)
        {
            CounterView view = new CounterView(counter);

            view.ChangeValue += async (s, e) =>
            {
                await SaveData.Save(counters);
            };

            CounterList.Children.Add(view);
        }

    }
}
