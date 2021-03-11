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
    }
}



