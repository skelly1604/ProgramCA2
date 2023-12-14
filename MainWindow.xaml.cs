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
namespace ProgramCA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Team> teams;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize data
            GetData();
        }

        private void GetData()
        {
            // Create 3 Teams
            Team t1 = new Team() { Name = "France" };
            Team t2 = new Team() { Name = "Italy" };
            Team t3 = new Team() { Name = "Spain" };

            // Create 9 Players and add them to Teams
            Player p1 = new Player() { Name = "Marie", ResultRecord = "WWDDL" };
            Player p2 = new Player() { Name = "Claude", ResultRecord = "DDDLW" };
            Player p3 = new Player() { Name = "Antoine", ResultRecord = "LWDLW" };

            Player p4 = new Player() { Name = "Marco", ResultRecord = "WWDLL" };
            Player p5 = new Player() { Name = "Giovanni", ResultRecord = "LLLLD" };
            Player p6 = new Player() { Name = "Valentina", ResultRecord = "DLWWW" };

            Player p7 = new Player() { Name = "Maria", ResultRecord = "WWWWW" };
            Player p8 = new Player() { Name = "Jose", ResultRecord = "LLLLL" };
            Player p9 = new Player() { Name = "Pablo", ResultRecord = "DDDDD" };

            t1.Players = new List<Player> { p1, p2, p3 };
            t2.Players = new List<Player> { p4, p5, p6 };
            t3.Players = new List<Player> { p7, p8, p9 };

            // Add Teams to the list
            teams = new List<Team> { t1, t2, t3 };
            teamListBox.ItemsSource = teams;

            // Display the first team's players by default
            DisplayTeamPlayers(teams.FirstOrDefault());
        }

        private void teamListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle team selection change
            Team selectedTeam = teamListBox.SelectedItem as Team;
            DisplayTeamPlayers(selectedTeam);
        }

        private void DisplayTeamPlayers(Team team)
        {
            // Display the players of the selected team in playerListBox
            if (team != null)
            {
                playerListBox.ItemsSource = team.Players;
            }
        }

        private void winButton_Click(object sender, RoutedEventArgs e)
        {
            UpdatePlayerResult('W');
        }


        private void drawButton_Click(object sender, RoutedEventArgs e)
        {
            UpdatePlayerResult('D');
        }

        private void lossButton_Click(object sender, RoutedEventArgs e)
        {
            UpdatePlayerResult('L');
        }

        private void UpdatePlayerResult(char result)
        {
            // Update the result for the selected player
            Player selectedPlayer = playerListBox.SelectedItem as Player;
            if (selectedPlayer != null)
            {
                // Remove the first character and add a new character at the end
                selectedPlayer.ResultRecord = selectedPlayer.ResultRecord.Substring(1) + result;
                playerListBox.ItemsSource = null; // Refresh the playerListBox
                playerListBox.ItemsSource = (teamListBox.SelectedItem as Team).Players;
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
