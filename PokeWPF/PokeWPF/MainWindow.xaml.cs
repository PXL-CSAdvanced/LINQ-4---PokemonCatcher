using PokemonClassLibrary;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataProcessing.InitializeDataProcessing();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            if (TrainerData.CheckTrainerLogin(UserNameTextBox.Text, UserPasswordBox.Password))
            {
                PokemonWindow pokemonWindow = new PokemonWindow(UserNameTextBox.Text);
                pokemonWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show(
                    "Incorrecte logingegevens", 
                    "Je naam of wachtwoord was incorrect",
                    MessageBoxButton.OK, 
                    MessageBoxImage.Exclamation);
            }
            ClearLogin();
        }

        private void NewUser_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(UserNameTextBox.Text) 
                && !String.IsNullOrWhiteSpace(UserPasswordBox.Password))
            {
                if (TrainerData.CheckUniqueTrainerName(UserNameTextBox.Text))
                {
                    TrainerData.CreateTrainer(UserNameTextBox.Text, UserPasswordBox.Password);
                    PokemonWindow pokemonWindow = new PokemonWindow(UserNameTextBox.Text);
                    pokemonWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Naam niet uniek", "De gekozen trainer naam is al in gebruik",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                ClearLogin();
            }
        }

        private void ClearLogin()
        {
            UserNameTextBox.Clear();
            UserPasswordBox.Clear();
        }
    }
}
