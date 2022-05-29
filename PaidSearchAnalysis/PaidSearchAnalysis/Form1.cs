using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using System.Windows.Forms;
using System.Collections;

namespace PaidSearchAnalysis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            input_folder.Text = Settings1.Default.inputFolder;
            output_location.Text = Settings1.Default.outputLocation;
        }

        private void search_input_button_Click(object sender, EventArgs e)
        {
            inputFolder.ShowDialog();
            input_folder.Text = inputFolder.SelectedPath;
        }

        private void output_search_button_Click(object sender, EventArgs e)
        {
            outputLocation.ShowDialog();
            output_location.Text = outputLocation.SelectedPath;
        }

        private void run_button_Click(object sender, EventArgs e)
        {
            Settings1.Default.inputFolder = input_folder.Text;
            Settings1.Default.outputLocation = output_location.Text;
            Settings1.Default.Save();

            string outputPath = output_location.Text;
            var inputFiles = Directory.GetFiles(input_folder.Text);
            string FY2021 = inputFiles.Where(x => x.Contains("21")).FirstOrDefault().ToString();
            string FY2022 = inputFiles.Where(x => x.Contains("22")).FirstOrDefault().ToString();

            generateOutput(FY2021, outputPath);            
        }

        private void generateOutput(string filePath, string outputLocation)
        {
            List<IList> usableData = new List<IList>();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                {
                    DataTable data = reader.AsDataSet().Tables[0];                   

                    for (int i = 1; i < data.Rows.Count; i++)
                    {
                        var currentRow = data.Rows[i].ItemArray;

                        if (currentRow[18].ToString().ToLower().Contains("spirit") && currentRow[5].ToString().ToUpper() != "TO DELETE" && currentRow[4].ToString().ToUpper() == "PERNOD RICARD")
                        {
                            usableData.Add(currentRow);
                        } 
                    }
                }
            }

            List<Output> resultData = null;
            
            if (filePath.Contains("21"))
            {
                resultData = FY2021(usableData);
            }

            Output(resultData, outputLocation);          
        }

        private List<Output> FY2021(List<IList> data)
        {
            List<Output> output = new List<Output>();
            IEnumerable<IList> sortedData2020 = data.Where(row => row[12].ToString() == "2020").Where(row => row[13].ToString() != "JANUARY");
            List<IList> dataConverted = sortedData2020.ToList();

            // Calculate Search Totals

            List<BrandData> brandDataList = new List<BrandData>();

            for (int i = 0; i < dataConverted.Count; i++)
            {
                IList currentData = dataConverted[i];
                string currentBrand = currentData[3].ToString();

                if (!brandDataList.Exists(x => x.Brand == currentBrand))
                {
                    double searchesSum = 0;
                    double impressionsSum = 0;
                    double netCostSum = 0;

                    for (int j = 0; j < currentData.Count; j++)
                    {
                        searchesSum += double.Parse(currentData[19].ToString());
                        impressionsSum += double.Parse(currentData[20].ToString());
                        netCostSum += double.Parse(currentData[16].ToString());
                    }

                    brandDataList.Add(new BrandData
                    {
                        Brand = currentBrand,
                        SearchesSum = searchesSum,
                        ImpressionsSum = impressionsSum,
                        NetCostSum = netCostSum
                    });
                }
                else
                {
                    var alreadyExistingBrand = brandDataList.Where(x => x.Brand == currentBrand).FirstOrDefault();

                    for (int j = 0; j < currentData.Count; j++)
                    {
                        alreadyExistingBrand.SearchesSum += double.Parse(currentData[19].ToString());
                        alreadyExistingBrand.ImpressionsSum += double.Parse(currentData[20].ToString());
                        alreadyExistingBrand.NetCostSum += double.Parse(currentData[16].ToString());
                    }
                }
            }

            brandDataList.Sort((a, b) => b.SearchesSum.CompareTo(a.SearchesSum));
            List<BrandData> sortedBrands = brandDataList;
            List<BrandData> top8 = new List<BrandData>();

            Output H22020Output = new Output();

            double H22020SearchesTotal = 0;
            double H22020ImpressionsTotal = 0;
            double H22020NetCostTotal = 0;


            for (var i = 0; i < 7; i++)
            {
                var currentBrand = sortedBrands[i];

                top8.Add(currentBrand);

                H22020SearchesTotal += currentBrand.SearchesSum;
                H22020ImpressionsTotal += currentBrand.ImpressionsSum;
                H22020NetCostTotal += currentBrand.NetCostSum;

            }

            H22020Output.Outputs = top8;
            H22020Output.SearchesTotal = H22020SearchesTotal;
            H22020Output.ImpressionsTotal = H22020ImpressionsTotal;
            H22020Output.NetCostTotal = H22020NetCostTotal;

            output.Add(H22020Output);

            return output;
            
        }

        public void Output(List<Output> outputs, string outputLocation)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (StreamWriter writer = new StreamWriter(outputLocation, false, new UTF8Encoding(true)))
            {
                writer.WriteLine("");
                writer.WriteLine("");

                writer.WriteLine(String.Join(", ", ", ", "H2 2020", ", ", ", ", ", ", ", ", ", ", "H1 2021", ", ", ", ", ", ", ", ", ", ", "H2 2021"));

                foreach (Output output in outputs)
                {
                    writer.WriteLine(String.Join(", ", ", ", "Searches", "Impressions", "Net Cost"));
                    for (int i = 0; i < output.Outputs.Count; i++)
                    {
                        var currentRow = output.Outputs[i];

                        writer.WriteLine(String.Join(", ", currentRow.Brand, currentRow.SearchesSum, currentRow.ImpressionsSum, currentRow.NetCostSum));
                    }
                    writer.WriteLine(String.Join(", ", "Totals", output.SearchesTotal, output.ImpressionsTotal, output.NetCostTotal));
                }
            }
        }
    }
}