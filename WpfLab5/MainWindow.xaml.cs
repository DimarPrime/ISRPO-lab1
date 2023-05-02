using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Word = Microsoft.Office.Interop.Word;

namespace WpfLab5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// коллекция для хранения данных из таблицы
        /// </summary>
        public ObservableCollection<Shop> Shop { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Shop = new Shop().Initialize();
            // связываем коллекцию Shop и таблицу dgData
            dgData.ItemsSource = Shop;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // создаем приложение ворд
            Word.Application winword = new Word.Application();
            //winword.Visible = true;

            // добавляем документ
            Word.Document document = winword.Documents.Add();

            // добавляем параграф с номером накладной и выбранной датой
            Word.Paragraph invoicePar = document.Content.Paragraphs.Add();
            DateTime? selectDate = invoiceDate.SelectedDate;
            if (selectDate != null)
                invoicePar.Range.Text = string.Concat("Расходная накладная № ", invoiceNumber.Text, " от ", selectDate.Value.ToString("dd.MM.yyyy"));
            else
                invoicePar.Range.Text = string.Concat("Расходная накладная № ", invoiceNumber.Text);
            invoicePar.Range.Font.Name = "Times new roman";
            invoicePar.Range.Font.Size = 14;
            invoicePar.Range.InsertParagraphAfter();

            // добавляем параграф с поставщиком
            Word.Paragraph providerPar = document.Content.Paragraphs.Add();
            providerPar.Range.Text = string.Concat("Поставщик: ", PurchasertxtBox.Text);
            providerPar.Range.Font.Name = "Times new roman";
            providerPar.Range.Font.Size = 14;
            providerPar.Range.InsertParagraphAfter();

            // добавляем параграф с потребителем
            Word.Paragraph customerPar = document.Content.Paragraphs.Add();
            customerPar.Range.Text = "Покупатель: " + ProvidertxtBox.Text;
            customerPar.Range.Font.Name = "Times new roman";
            customerPar.Range.Font.Size = 14;
            customerPar.Range.InsertParagraphAfter();

            // формируем таблицу
            // количество колонок - 5
            // количество строк - nRows
            int nRows = dgData.Items.Count;
            Word.Table myTable = document.Tables.Add(customerPar.Range, nRows, 6);
            myTable.Borders.Enable = 1;
            // устанавливаем названия колонок
            var headerRow = myTable.Rows[1].Cells;
            headerRow[1].Range.Text = "№";
            headerRow[2].Range.Text = "Товар";
            headerRow[3].Range.Text = "Количество, в кг";
            headerRow[4].Range.Text = "Цена, в руб.";
            headerRow[5].Range.Text = "Сумма, в руб.";
            headerRow[6].Range.Text = "Итого, в руб.";
            // добавляем данные из таблицы в ворд
            for (int i = 2; i < Shop.Count + 2; i++)
            {
                var dataRow = myTable.Rows[i].Cells;
                dataRow[1].Range.Text = Shop[i - 2].Id.ToString();
                dataRow[2].Range.Text = Shop[i - 2].Product;
                dataRow[3].Range.Text = Shop[i - 2].Count.ToString();
                dataRow[4].Range.Text = Shop[i - 2].Price.ToString();
                dataRow[5].Range.Text = Shop[i - 2].Sum.ToString();
                dataRow[6].Range.Text = Shop[i - 2].Total.ToString();
            }
            

            // указываем в какой файл сохранить
            // TODO - добавьте возможность выбора названия файла
            // и места где его нужно сохранить
            object filename = @"C:\Users\dimar\source\repos\word_z328_1.docx";
            document.SaveAs(filename);
            document.Close();
            winword.Quit();
        }
    }

}
