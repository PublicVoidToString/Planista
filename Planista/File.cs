using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Planista
{
    internal class File
    {
        private int i;
        private int[] avg;
        private int[] best;
        private string title;

        public File()
        {
            i = 0;
            avg = new int[Data.generationsCount];
            best = new int[Data.generationsCount];
            title = $"Version{Data.version}IterSizeMutCros_{Data.generationsCount}_{Data.schedulesCount}_{Data.mutationChance}_{Data.crossoverChance}";
        }

        public void Insert(int avg, int best)
        {
            this.avg[i] = avg;
            this.best[i] = best;
            i++;
        }

        public void PrintToFile()
        {
            try
            {
                string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Planista_results");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string filePath = Path.Combine(folderPath, $"{this.title}.txt");
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Avg,Max");
                    for (int i = 0; i < avg.Length; i++)
                    {
                        writer.WriteLine($"{this.avg[i]},{this.best[i]}");
                    }
                }
                Console.WriteLine($"Dane zostały zapisane do pliku: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas zapisywania danych: {ex.Message}");
            }
        }

    }

}
