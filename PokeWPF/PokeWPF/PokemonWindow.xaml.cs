using PokemonClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PokeWPF
{
    /// <summary>
    /// Interaction logic for PokemonWindow.xaml
    /// </summary>
    public partial class PokemonWindow : Window
    {
        private string currentTrainerName;
        private int currentTrainerId;
        private DispatcherTimer timer;
        private Random random;
        private int randomPokemonNumber;
        private bool isCaught = false;
        private int maxNumber;

        public PokemonWindow(string currentTrainer)
        {
            InitializeComponent();
            this.currentTrainerName = currentTrainer;
            this.currentTrainerId = TrainerData.GetTrainerIdByTrainerName(currentTrainer);

            PokemonDataGrid.ItemsSource = PokemonData.GetPokemonDataView();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += Timer_Tick;
            timer.Start();

            random = new Random();

            maxNumber = PokemonData.GetMaxPokemonNumber();

            SetRandomPokemon();

            LoadAllCaughtPokemons();
        }

        private void LoadAllCaughtPokemons()
        {
            List<int> pokemonIds = CaugthPokemonData.GetCaugthPokemonIdsByTrainerId(currentTrainerId);
            if (pokemonIds != null)
            {
                foreach (var pokemonId in pokemonIds)
                {
                    AddCaugthPokemon(pokemonId);
                }
            }
        }

        private void AddCaugthPokemon(int pokemonId)
        {
            BitmapImage bitmapImg = new BitmapImage(
                    new Uri($"/images/pokemon/{pokemonId}.png",
                    UriKind.Relative));
            Image miniImg = new Image();
            miniImg.Source = bitmapImg;
            miniImg.Height = 25;
            CaughtListBox.Items.Insert(0, miniImg);
        }

        private void SetRandomPokemon()
        {
            randomPokemonNumber = random.Next(1, maxNumber);
            LoadPokemonImage();
            isCaught = false;
        }

        private void LoadPokemonImage()
        {
            PokemonImage.Source = new BitmapImage(
                new Uri($"/images/pokemon/{randomPokemonNumber}.png",
                UriKind.Relative));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SetRandomPokemon();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            timer.Stop();
            DataProcessing.SaveTrainerDataSet();
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = FilterTextBox.Text;
            PokemonDataGrid.ItemsSource = PokemonData.GetPokemonDataViewByNameFilter(filter);
        }

        private void PokemonDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PokemonDataGrid.SelectedItem != null)
            {
                DataRowView row = (DataRowView)PokemonDataGrid.SelectedItem;
                int number = Convert.ToInt32(row.Row["Number"]);
                if (number == randomPokemonNumber && !isCaught)
                {
                    isCaught = true;
                    AddCaugthPokemon(randomPokemonNumber);
                    CaugthPokemonData.CatchPokemon(currentTrainerId, randomPokemonNumber);
                }
            }
        }
    }
}
