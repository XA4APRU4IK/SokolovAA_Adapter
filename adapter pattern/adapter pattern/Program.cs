using adapter_pattern;
using System;

namespace AdapterPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ComputerGame witcher3 = new ComputerGame("The Witcher 3", PegiAgeRating.P18, 81, 6144, 35, 6, 4, 3.2);
            ComputerGame rdr2 = new ComputerGame("RDR 2", PegiAgeRating.P18, 80, 8192, 150, 8, 4, 3.0);
            ComputerGame nfsHeat = new ComputerGame("NFS Heat", PegiAgeRating.P7, 30, 2048, 50, 8, 4, 3.0);

            PCGame witcherAdapter = new ComputerGameAdapter(witcher3);
            PCGame rdrAdapter = new ComputerGameAdapter(rdr2);
            PCGame nfsAdapter = new ComputerGameAdapter(nfsHeat);

            DisplayGameInfo(witcherAdapter);
            DisplayGameInfo(rdrAdapter);
            DisplayGameInfo(nfsAdapter);
        }
        private static void DisplayGameInfo(PCGame game)
        {
            Console.WriteLine($"{game.getTitle()} is Triple A: {game.isTripleAGame()}");
            Requirements requirements = game.getRequirements();
            Console.WriteLine("System Requirements:");
            Console.WriteLine($"- Minimum GPU Memory: {requirements.GpuMemoryInGb} GB");
            Console.WriteLine($"- Disk Space Needed: {requirements.DiskSpaceNeededInGB} GB");
            Console.WriteLine($"- RAM Needed: {requirements.RamNeededInGb} GB");
            Console.WriteLine($"- Core Speed: {requirements.CoreSpeedInGhz} GHz");
            Console.WriteLine($"- Cores Needed: {requirements.CoresNeeded}");
            Console.WriteLine();
        }
    }
}
