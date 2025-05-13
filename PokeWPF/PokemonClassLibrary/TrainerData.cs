using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClassLibrary
{
    public static class TrainerData
    {
        internal const string TRAINERS_DATATABLE_NAME = "Trainers";
        private const string TRAINERS_COLUMN_ID = "TrainerId";
        private const string TRAINERS_COLUMN_NAME = "TrainerName";
        private const string TRAINERS_COLUMN_PASSWORD = "TrainerPass";

        internal static DataTable TrainerDataTable { get; set; }

        /// <summary>
        /// In de statische constructor verzekeren we dat de DataTable
        /// geïnitialiseerd is.
        /// </summary>
        static TrainerData()
        {
            if (!File.Exists(DataProcessing.TRAINER_FILE))
            {
                InitializeTrainderDataTable();
            }
        }

        // Maak een DataTable aan met drie kolommen: trainerId (int), trainerName (string)
        // en trainerPassword (string). Gebruik de constante die bovenaan in de klasse 
        // gegeven zijn.
        private static void InitializeTrainderDataTable()
        {
            throw new NotImplementedException();
        }

        // Gebruik de methodes van het disconnected ADO.NET model om een nieuwe
        // rij toe te voegen aan de DataTable. Gebruik GetNextTrainerId() om het correct 
        // TrainerId te vinden voor de DataRow.
        public static void CreateTrainer(string trainerName, string password)
        {
            throw new NotImplementedException();
        }

        // Gebruik een LINQ query om een verzameling van alle trainerId's te
        // selecteren. Geef vervolgens het hoogste id terug en tel er één bij op.
        private static int GetNextTrainerId()
        {
            throw new NotImplementedException();
        }

        // Gebruik een LINQ query om een verzameling van trainers te selecteren
        // die de gegeven naam en wachtwoord hebben. Vervolgens controleer je of
        // er meer dan nul trainers geselecteerd zijn.
        public static bool CheckTrainerLogin(string trainerName, string password)
        {
            throw new NotImplementedException();
        }

        // Gebruik een LINQ query om een verzameling van trainers te selecteren met de
        // gegeven naam. Vervolgens controleer je of er exact nul trainers zijn geselecteerd.
        public static bool CheckUniqueTrainerName(string trainerName)
        {
            throw new NotImplementedException();
        }

        // Gebruik een LINQ query om een verzameling van id's (int) te selecteren uit
        // de DataTable van TrainerData. Geef vervolgens het eerste element terug.
        public static int GetTrainerIdByTrainerName(string trainerName)
        {
            throw new NotImplementedException();
        }
    }
}
