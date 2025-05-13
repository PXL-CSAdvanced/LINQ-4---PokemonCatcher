using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClassLibrary
{
    public static class DataProcessing
    {
        internal const string TRAINER_FILE = "trainer.xml";

        private static DataSet? pokemonTrainerDataSet;

        // Deze moethode zorgt voor initialisatie van de pokemonTrainerDataSet
        public static void InitializeDataBewerking()
        {
            pokemonTrainerDataSet = new DataSet("TrainerDataSet");

            if (File.Exists(TRAINER_FILE))
            {
                // Lees file met bestaande trainers en gevangen pokemon
                pokemonTrainerDataSet.ReadXml(TRAINER_FILE);
                TrainerData.TrainerDataTable = 
                    pokemonTrainerDataSet.Tables[TrainerData.TRAINERS_DATATABLE_NAME];
                CaugthPokemonData.CaugthPokemonDataTable =
                    pokemonTrainerDataSet.Tables[CaugthPokemonData.CAUGHTPOKEMONS_DATATABLE_NAME];
                PokemonData.PokemonDataTable =
                    pokemonTrainerDataSet.Tables[PokemonData.POKEMONS_DATATABLE_NAME];
            }
            else
            {
                InitializeNewDataSet();
            }
        }

        /// <summary>
        /// Deze methode initialiseert een NIEUWE trainer DataSet. De methode
        /// roept InitializeTrainderDataTable(), InitializeCaugthPokemonDataTable()
        /// en GetPokemonDataTable() van PokemonData op om de tabellen in de DataSet
        /// te initialiseren.
        /// </summary>
        private static void InitializeNewDataSet()
        {
            throw new NotImplementedException();
        }

        // Deze methode exporteert alle gegevens uit de pokemonTrainerDataSet naar een
        // xml bestand, genaamd TRAINER_FILE.
        public static void SaveTrainerDataSet()
        {
            throw new NotImplementedException();
        }
    }
}
