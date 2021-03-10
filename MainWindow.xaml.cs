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

        class singleModArray_1
        {

            private int length;
            private double[] arrayOfDoubles;
            private double multiplyValue = 1;
            private int flag = 0;
            Random rnd = new Random();
            private void generateArray(int numbers)
            {
                arrayOfDoubles = new double[length];
                for (int i = 0; i < length; i++)
                {
                    arrayOfDoubles[i] = rnd.Next(0, numbers);
                }
            }

            public singleModArray_1(int len = 1)
            {
                length = len;
                generateArray(100);
            }

            public double getMultiplyValue()
            {
                for (int i = 1; i < arrayOfDoubles.Length - 2; i++)
                {
                    if (flag == 0)
                    {
                        if (arrayOfDoubles[i] % 2 == 0)
                        {
                            flag = 1;
                            continue;
                        }
                    }
                    else if (flag == 1)
                    {
                        if (arrayOfDoubles[i] % 2 == 0)
                        {
                            flag = 2;
                            break;
                        }
                        else
                        {
                            multiplyValue *= arrayOfDoubles[i];
                        }
                    }
                }
                Console.WriteLine($"Произведение равно {multiplyValue}");
                return multiplyValue;
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

        class singleModArray_2
        {
            private int length;
            private double[] arrayOfDoubles;
            Random rnd = new Random();
            private void generateArray(int numbers)
            {
                arrayOfDoubles = new double[10];

                for (int i = 0; i < length; i++)
                {
                    arrayOfDoubles[i] = rnd.Next(0, numbers);
                }
            }

            public singleModArray_2(int len = 1)
            {
                length = len;
                generateArray(100);
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
            singleModArray_1 arr1 = new singleModArray_1(10);
            this.task1Label2.Content = "ssssss";

        }
    }
}

