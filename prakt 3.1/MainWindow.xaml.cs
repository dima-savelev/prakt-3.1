using System;
using System.Collections.Generic;
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
using LibMas;
using Lib_13;
using Microsoft.Win32;

namespace prakt_3._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private int[,] _matrix;

        private void Create(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(columnOut.Text, out int column)) return;
            if (!int.TryParse(rowOut.Text, out int row)) return;
            if (column > 0 && row > 0)
            {
                _matrix = new int[row, column];
                dataGrid.ItemsSource = VisualArray.ToDataTable(_matrix).DefaultView;
                resultOut.Clear();
            }
        }

        private void MainOperation(object sender, RoutedEventArgs e)
        {
            if (_matrix == null) return;
            Practice.MinimumValueMatrix(_matrix, out string result);
            resultOut.Text = result;
        }

        private void FillDataGrid(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(numberMin.Text, out int minimum)) return;
            if (!int.TryParse(numberMax.Text, out int maximum)) return;
            if (!int.TryParse(columnOut.Text, out int column)) return;
            if (!int.TryParse(rowOut.Text, out int row)) return;
            if (maximum > minimum && column > 0 && row > 0)
            {
                _matrix = new int[row, column];
                MatrixOperation.FillRandomValues(_matrix, minimum, maximum);
                dataGrid.ItemsSource = VisualArray.ToDataTable(_matrix).DefaultView;
            }
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //Опряделяем номер столбца
            int indexColumn = e.Column.DisplayIndex;
            //Определяем номер строки
            int indexRow = e.Row.GetIndex();
            //Проверяем правильное значение ввел пользователь
            if (!int.TryParse(((TextBox)e.EditingElement).Text.Replace('.', ','), out int value))
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Заносим введенное значение в матрицу
            _matrix[indexRow, indexColumn] = value;
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            MatrixOperation.ClearMatrix(_matrix);
            dataGrid.ItemsSource = VisualArray.ToDataTable(_matrix).DefaultView;
            columnOut.Clear();
            rowOut.Clear();
            numberMin.Clear();
            numberMax.Clear();
            resultOut.Clear();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenMatrix(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            if (open.ShowDialog() == true)
            {
                if (open.FileName != string.Empty)
                {
                    MatrixOperation.OpenMatrix(open.FileName, out _matrix);
                    rowOut.Text = _matrix.GetLength(0).ToString();
                    columnOut.Text = _matrix.GetLength(1).ToString();
                    dataGrid.ItemsSource = VisualArray.ToDataTable(_matrix).DefaultView;
                }
            }
        }

        private void SaveMatrix(object sender, RoutedEventArgs e)
        {
            if (_matrix == null)
            {
                MessageBox.Show("Таблица пуста", "Ошибка");
                return;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true)
            {
                MatrixOperation.SaveMatrix(save.FileName, _matrix);
            }
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Савельев Дмитрий Александрович В13\nПрактическая работа №3\nДана матрица размера M × N. Найти минимальный среди элементов тех строк, которые упорядочены либо по возрастанию, либо по убыванию. Если упорядоченные строки в матрице отсутствуют, то вывести 0.", "Информация о программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
