namespace TeamGenerator
{
   internal class Team
   {
      public string TeamName;
      public string PccPlayer;
      public string PistolPlayer;
      public Team(string teamName, string pccPlayer, string pistolPlayer)
      {
         this.TeamName = teamName;
         this.PccPlayer = pccPlayer;
         this.PistolPlayer = pistolPlayer;
      }

      public override string ToString()
      {
         string ret = $"{this.TeamName}: {this.PccPlayer}, {this.PistolPlayer}";
         return ret;
      }
   }

   internal class Program
   {
      static void Main(string[] args)
      {
         string pccListFile = @"C:\Temp\PccPlayers.txt"; //args[0];
         string pistolListFile = @"C:\Temp\PistolPlayers.txt"; //args[1];

         List<string> pccPlayers = File.ReadAllLines(pccListFile).ToList<string>();
         List<string> pistolPlayers = File.ReadAllLines(pistolListFile).ToList<string>();

         int maxTeams = Math.Min(pccPlayers.Count, pistolPlayers.Count);
         List<Team> Teams = new List<Team>();

         Random rand = new Random();
         for (int i = 1; i < maxTeams + 1; i++)
         {
            int pcc = rand.Next(pccPlayers.Count - 1);
            int pistol = rand.Next(pistolPlayers.Count - 1);
            string teamName = $"Team {i}";
            Teams.Add(new Team(teamName, pccPlayers[pcc], pistolPlayers[pistol]));
            pccPlayers.RemoveAt(pcc);
            pistolPlayers.RemoveAt(pistol);
         }

         // Print results
         Console.WriteLine("******* Teams *******");
         foreach (var team in Teams)
            Console.WriteLine(team);
      }
   }
}
