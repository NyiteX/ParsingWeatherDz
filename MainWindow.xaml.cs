using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Documents;
using HtmlAgilityPack;
using System.Windows.Controls;
using System.Windows.Media;

namespace ParsingWeatherDz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<TextBox> Labels { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Labels = new ObservableCollection<TextBox>();

            GetHtmlAsync();
        }
        async void GetHtmlAsync()
        {
            string url = "https://www.gismeteo.com/weather-kyiv-4944/10-days/";

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            //все столбцы дней и всё с ними связанное
            var list1 = htmlDoc.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("widget-items")).ToList();

            //дни недели и их даты
            var htmllist = list1[0].Descendants("a")
            .Where(node => node.GetAttributeValue("class", "")
            .Contains("row-item")).ToList();

            //температуры
            var valueTemps = htmlDoc.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("chart ten-days")).ToList();
            //мах температура
            var maxTlist = list1[0].Descendants("div")
            .Where(node => node.GetAttributeValue("class", "")
            .Equals("maxt")).ToList();

            //мин температура
            var minTlist = list1[0].Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("mint")).ToList();

            /*foreach (var s in maxTlist)
            {
                var maxC = s.Descendants("span")
            .Where(node => node.GetAttributeValue("class", "")
            .Equals("unit unit_temperature_c")).ToList();

                foreach (var c in maxC)
                {
                    test_tb.Text += c.InnerText;
                }

            }*/
        
            //////////////////////////////////////////////////////
            /*return;*/
            for (int i = 0; i < htmllist.Count; i++)
            {
                var daylist = htmllist[i].Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("day")).ToList();

                var datelist = htmllist[i].Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Contains("date")).ToList();

                var maxC = maxTlist[i].Descendants("span")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("unit unit_temperature_c")).ToList();

                var minC = minTlist[i].Descendants("span")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("unit unit_temperature_c")).ToList();

                switch (i)
                {
                    case 0:
                        label_day1.Content = daylist.Last().InnerText + "\n" + datelist.Last().InnerText;
                        label_temp1.Content = maxC.Last().InnerText + "\n" + minC.Last().InnerText;
                        break;
                    case 1:
                        label_day2.Content = daylist.Last().InnerText + "\n" + datelist.Last().InnerText;
                        label_temp2.Content = maxC.Last().InnerText + "\n" + minC.Last().InnerText;
                        break;
                    case 2:
                        label_day3.Content = daylist.Last().InnerText + "\n" + datelist.Last().InnerText;
                        label_temp3.Content = maxC.Last().InnerText + "\n" + minC.Last().InnerText;
                        break;
                    case 3:
                        label_day4.Content = daylist.Last().InnerText + "\n" + datelist.Last().InnerText;
                        label_temp4.Content = maxC.Last().InnerText + "\n" + minC.Last().InnerText;
                        break;
                    case 4:
                        label_day5.Content = daylist.Last().InnerText + "\n" + datelist.Last().InnerText;
                        label_temp5.Content = maxC.Last().InnerText + "\n" + minC.Last().InnerText;
                        break;
                    case 5:
                        label_day6.Content = daylist.Last().InnerText + "\n" + datelist.Last().InnerText;
                        label_temp6.Content = maxC.Last().InnerText + "\n" + minC.Last().InnerText;
                        break;
                    case 6:
                        label_day7.Content = daylist.Last().InnerText + "\n" + datelist.Last().InnerText;
                        label_temp7.Content = maxC.Last().InnerText + "\n" + minC.Last().InnerText;
                        break;
                    case 7:
                        label_day8.Content = daylist.Last().InnerText + "\n" + datelist.Last().InnerText;
                        label_temp8.Content = maxC.Last().InnerText + "\n" + minC.Last().InnerText;
                        break;
                    case 8:
                        label_day9.Content = daylist.Last().InnerText + "\n" + datelist.Last().InnerText;
                        label_temp9.Content = maxC.Last().InnerText + "\n" + minC.Last().InnerText;
                        break;
                    case 9:
                        label_day10.Content = daylist.Last().InnerText + "\n" + datelist.Last().InnerText;
                        label_temp10.Content = maxC.Last().InnerText + "\n" + minC.Last().InnerText;
                        break;
                }
            }


                test_tb.Content = "Kyiv";

        }
    }
}
