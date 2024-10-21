using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace adapter_pattern
{
    public class Program
    {
  
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
    public class ComputerGame
    {
        private string name;
        private PegiAgeRating pegiAgeRating;
        private double budgetInMillionsOfDollars;
        private int minimumGpuMemoryInMegabytes;
        private int diskSpaceNeededInGB;
        private int ramNeededInGb;
        private int coresNeeded;
        private double coreSpeedInGhz;

        public ComputerGame(string name,
                            PegiAgeRating pegiAgeRating,
                            double budgetInMillionsOfDollars,
                            int minimumGpuMemoryInMegabytes,
                            int diskSpaceNeededInGB,
                            int ramNeededInGb,
                            int coresNeeded,
                            double coreSpeedInGhz)
        {
            this.name = name;
            this.pegiAgeRating = pegiAgeRating;
            this.budgetInMillionsOfDollars = budgetInMillionsOfDollars;
            this.minimumGpuMemoryInMegabytes = minimumGpuMemoryInMegabytes;
            this.diskSpaceNeededInGB = diskSpaceNeededInGB;
            this.ramNeededInGb = ramNeededInGb;
            this.coresNeeded = coresNeeded;
            this.coreSpeedInGhz = coreSpeedInGhz;
        }
        public string getName() => name;
        public PegiAgeRating getPegiAgeRating() => pegiAgeRating;
        public double getBudgetInMillionsOfDollars() => budgetInMillionsOfDollars;
        public int getMinimumGpuMemoryInMegabytes() => minimumGpuMemoryInMegabytes;
        public int getDiskSpaceNeededInGB() => diskSpaceNeededInGB;
        public int getRamNeededInGb() => ramNeededInGb;
        public int getCoresNeeded() => coresNeeded;
        public double getCoreSpeedInGhz() => coreSpeedInGhz;
    }
    public enum PegiAgeRating
    {
        P3, P7, P12, P16, P18
    }
    public class Requirements
    {
        public int GpuMemoryInGb { get; }
        public int DiskSpaceNeededInGB { get; }
        public int RamNeededInGb { get; }
        public double CoreSpeedInGhz { get; }
        public int CoresNeeded { get; }

        public Requirements(int gpuMemoryInGb, int diskSpaceNeededInGB, int ramNeededInGb, double coreSpeedInGhz, int coresNeeded)
        {
            GpuMemoryInGb = gpuMemoryInGb;
            DiskSpaceNeededInGB = diskSpaceNeededInGB;
            RamNeededInGb = ramNeededInGb;
            CoreSpeedInGhz = coreSpeedInGhz;
            CoresNeeded = coresNeeded;
        }
    }
    public interface PCGame
    {
        string getTitle();
        bool isTripleAGame();
        Requirements getRequirements();
    }
    public class ComputerGameAdapter : PCGame
    {
        private ComputerGame _computerGame;

        public ComputerGameAdapter(ComputerGame computerGame)
        {
            _computerGame = computerGame;
        }
        public string getTitle()
        {
            return _computerGame.getName();
        }
        public bool isTripleAGame()
        {
            
            return _computerGame.getBudgetInMillionsOfDollars() >= 50;
        }
        public Requirements getRequirements()
        {
            int gpuMemoryInGb = _computerGame.getMinimumGpuMemoryInMegabytes() / 1024;
            return new Requirements(
                gpuMemoryInGb,
                _computerGame.getDiskSpaceNeededInGB(),
                _computerGame.getRamNeededInGb(),
                _computerGame.getCoreSpeedInGhz(),
                _computerGame.getCoresNeeded()
            );
        }
    }
}
