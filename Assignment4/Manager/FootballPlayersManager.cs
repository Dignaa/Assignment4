using MandatoryAssignment;

namespace Assignment4.Manager
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;
        private static readonly List<FootbalPlayer> players = new List<FootbalPlayer>()
        {
            new FootbalPlayer{Id = _nextId++, Name = "Digna", Age = 22, ShirtNumber = 33 },
            new FootbalPlayer{Id = _nextId++, Name = "Szymon", Age = 87, ShirtNumber = 107 },
            new FootbalPlayer{Id = _nextId++, Name = "Tea", Age = 28, ShirtNumber = 50 },
            new FootbalPlayer{Id = _nextId++, Name = "Bartol", Age = 20, ShirtNumber = 40 }
        };

    public List<FootbalPlayer> GetAll()
    {
        List<FootbalPlayer> result = new List<FootbalPlayer>(players);
            return result;
    }
        public FootbalPlayer GetById(int id)
        {
            return players.Find(p=> p.Id == id);
        }

        public FootbalPlayer Add(FootbalPlayer newPlayer)
        {
            newPlayer.Id = _nextId++;
            players.Add(newPlayer);
            return newPlayer;
        }

        public FootbalPlayer? Delete(int id)
        {
            FootbalPlayer player = GetById(id);
            if(player == null) return null;
            players.Remove(player);
            return player;
        }

        public FootbalPlayer? Update(int id, FootbalPlayer updates)
        {
            FootbalPlayer playerToUpdate = GetById(id);
            if (playerToUpdate == null) return null;
            playerToUpdate.Name = updates.Name;
            playerToUpdate.Age = updates.Age;
            playerToUpdate.ShirtNumber = updates.ShirtNumber;

            return playerToUpdate;
        }


    }
}

