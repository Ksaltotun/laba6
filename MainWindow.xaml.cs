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
using System.Text.RegularExpressions;

namespace Laba6_Var_9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        class singleModArray
        {

            private int length;
            private double[] arrayOfDoubles;
            private double multiplyValue;
            private int indexFirst = 0;
            private int indexLast = 0;
            private string arrayString;
            Random rnd = new Random();
            private void generateArray(int numbers)
            {
                arrayOfDoubles = new double[length];
                for (int i = 0; i < length; i++)
                {
                    arrayOfDoubles[i] = rnd.Next(0, numbers);
                    arrayString += Convert.ToString(arrayOfDoubles[i]);
                    if (i != length - 1)
                    {
                        arrayString += " ";
                    }
                }
            }

            private void findFirst()
            {
                for (int i = 0; i < arrayOfDoubles.Length; i++)
                {
                    if (arrayOfDoubles[i] % 2 == 0) 
                    {
                        indexFirst = i;
                        break;
                    }
                }
            }

            private void findLast()
            {
                for (int i = 0; i < arrayOfDoubles.Length; i++)
                {
                    if (arrayOfDoubles[i] % 2 == 0)
                    {
                        indexLast = i;
                    }
                }
            }

            public singleModArray(int len = 1)
            {
                length = len;
                generateArray(100);
            }

            public string getStringForm()
            {
                arrayString = "";
                for (int i = 0; i < length; i++)
                {
                    arrayString += Convert.ToString(arrayOfDoubles[i]);
                    if (i != length - 1)
                    {
                        arrayString += " ";
                    }
                }
                return arrayString;
            }

            public double getMultiplyValue()
            {
                multiplyValue = 1;
                findFirst();
                findLast();
                if (indexFirst + 1 < indexLast)
                {
                    for(int i = indexFirst + 1; i < indexLast; i++)
                    {
                        multiplyValue *= arrayOfDoubles[i];
                    }
                }
                return multiplyValue;
            }

            public void sortBeforeEven()
            {
                double minDouble = arrayOfDoubles[0];
                double buffer = 0;
                int firstEvenPosition = 0;
                for (int i = 0; i < arrayOfDoubles.Length; i++)
                {
                    if (arrayOfDoubles[i] % 2 == 0)
                    {
                        firstEvenPosition = i;
                        break;
                    }
                }
                for (int i = 0; i < firstEvenPosition - 1; i++)
                {
                    for (int j = 0; j < firstEvenPosition - i - 1; j++)
                    {
                        if (arrayOfDoubles[j] < arrayOfDoubles[j + 1])
                        {
                            buffer = arrayOfDoubles[j + 1];
                            arrayOfDoubles[j + 1] = arrayOfDoubles[j];
                            arrayOfDoubles[j] = buffer;
                        }
                    }
                }
            }

            public bool isLengthNotNull()
            {
                if(indexFirst + 1 < indexLast)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            public void printArray()
            {
                for (int i = 0; i < arrayOfDoubles.Length; i++)
                {
                    Console.Write(arrayOfDoubles[i]);
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
        }

        class matrixModArray
        {
            private int rowsLength;
            private int columnLength;
            private double[,] arrayOfDoubles;
            private string textMatrix;
            Random rnd = new Random();
            private int negativeStringCounter = 0;
            private void generateArray(int numbers)
            {
                arrayOfDoubles = new double[rowsLength, columnLength];
                for (int i = 0; i < rowsLength; i++)
                {
                    for (int j = 0; j < columnLength; j++)
                    {
                        arrayOfDoubles[i, j] = rnd.Next(-1 * numbers, numbers);
                    }
                }
            }
            public matrixModArray(int rows = 1, int columns = 1)
            {
                rowsLength = rows;
                columnLength = columns;
                generateArray(100);
            }

            public int calcNegativeRows()
            {
                for (int i = 0; i < rowsLength; i++)
                {
                    for (int j = 0; j < columnLength; j++)
                    {
                        if (arrayOfDoubles[i, j] < 0)
                        {
                            negativeStringCounter++;
                            break;
                        }
                    }
                }
                printMatrixArray();
                Console.WriteLine($"Строк с отрицательными числами: {negativeStringCounter}");
                return negativeStringCounter;
            }

            public string getTextMatrix()
            {

                textMatrix = "";

                for (int i = 0; i < rowsLength; i++)
                {
                    string rowMatrix = "";
                    for (int j = 0; j < columnLength; j++)
                    {
                        string number = Convert.ToString(arrayOfDoubles[i, j]);
                        rowMatrix += String.Format("{0,-6}", number);
                        if (j != columnLength - 1)
                        {
                            rowMatrix += " ";
                        }
                    }

                    textMatrix += rowMatrix;
                    if (i != columnLength - 1)
                    {
                        textMatrix += "\n";
                    }
                }
                return textMatrix;
            }

            public void printMatrixArray()
            {
                for (int i = 0; i < rowsLength; i++)
                {
                    for (int j = 0; j < columnLength; j++)
                    {
                        Console.Write($"{arrayOfDoubles[i, j]}\t");
                    }
                    Console.WriteLine("");
                }
            }
        }

        struct Registration
        {
            public string surname;
            public string sex;
            public string adress;
            public int grade1, grade2, grade3;
        }

        static Tuple<string, string, string, float, int> Corteg(string surname, int surnameEnglish, int birthDayYear, int grade)

        {
            string p = surname, email, otv;
            float sum = 0, sr;
            Registration[] st = new Registration[5];

            st[0].surname = "Петров";
            st[0].sex = "Мужской";
            st[0].adress = "Коммунаров, 51/5";
            st[0].grade1 = 2; st[0].grade2 = 8; st[0].grade3 = 9;

            st[1].surname = "Иванов";
            st[1].sex = "Мужской";
            st[1].adress = "Советская, 43/1";
            st[1].grade1 = 6; st[1].grade2 = 4; st[1].grade3 = 8;

            st[2].surname = "Сидорова";
            st[2].sex = "Женский";
            st[2].adress = "Ленина, 666";
            st[2].grade1 = 6; st[2].grade2 = 6; st[2].grade3 = 6;

            st[3].surname = "Ботанова";
            st[3].sex = "Женский";
            st[3].adress = "Портовая д.666";
            st[3].grade1 = 9; st[3].grade2 = 9; st[3].grade3 = 10;

            st[3].surname = "Литвинова";
            st[3].sex = "Женский";
            st[3].adress = "Лазурная д.17 кв.100";
            st[3].grade1 = 4; st[3].grade2 = 4; st[3].grade3 = 5;

            int nom = -1;
            int roundedYear;
            float averageGrade;
            string sex;

            for (int i = 0; i < 5; i++)
                if (st[i].surname == surname)
                {
                    nom = i;
                    break;
                }
            if (nom != -1)
            {
                email = surnameEnglish + Convert.ToString(birthDayYear) + "@gmail.com";
                sum = st[nom].grade1 + st[nom].grade2 + st[nom].grade3 + grade;
                averageGrade = sum / 4;
                roundedYear = 2021 - birthDayYear;
                sex = st[nom].sex;
            }
            else { email = surnameEnglish + Convert.ToString(birthDayYear) + "@gmail.com"; sex = "udefined"; averageGrade = grade / 4f; roundedYear = 2021 - birthDayYear; }
            
            return Tuple.Create<string, string, string, float, int>(surname, sex, email, averageGrade, roundedYear);
        }

        private bool normalek = true;
        private void Create_SingleArr_1_Button_Click(object sender, RoutedEventArgs e)
        {
            singleModArray arr1 = new singleModArray(10);
            this.task1Label2.Content = arr1.getStringForm();
            double multiply = arr1.getMultiplyValue();
            if (arr1.isLengthNotNull())
            {
                this.task1_label_4.Content = Convert.ToString(multiply);
            } else
            {
                this.task1_label_4.Content = "Нет значений между четными";
            }
        }

        private void task_2_button_1_Click(object sender, RoutedEventArgs e)
        {
            singleModArray arr2 = new singleModArray(10);
            this.task_2_label_2.Content = arr2.getStringForm();
            arr2.sortBeforeEven();
            this.task_2_label_4.Content = arr2.getStringForm();
        }

        private void task_3_button_1_Click(object sender, RoutedEventArgs e)
        {
            matrixModArray arr3 = new matrixModArray(5, 5);
            string textMatrix = arr3.getTextMatrix();
            this.task_3_textBlock_1.Text = textMatrix;
            this.task3_label_3.Content = arr3.calcNegativeRows();
        }

        private void task4_butto1_Click(object sender, RoutedEventArgs e)
        {
            string surname = this.task4_input_1.Text;
            string surnameEnglish = this.task4_input_2.Text;
            int birthdayYear;

            if (!Regex.IsMatch(surnameEnglish, @"[a-zA-z_]{1}\w"))
            {
                MessageBox.Show("Фамилию на английском пишите латинкой.");
                this.task4_input_2.Text = "";
                normalek = false;
            }
            else
            {
                normalek = true;
            }
            try
            {
                birthdayYear = Convert.ToInt32(this.task4_input_3.Text);
                normalek = true;
            }
            catch
            {
                MessageBox.Show("Фамилию на английском пишите латинкой.");
                this.task4_input_3.Text = "";
                normalek = false;
            }
        }
    }
}



