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

namespace BattleShipWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int gridSize = 10;
        String[,] gridArray;
        Button[,] buttonArray;
        Random random = new Random();
        public int randomNumberX;
        public int randomNumberY;
        List<int> dimensionX = new List<int>();
        List<int> dimensionY = new List<int>();
        private int shotsFired = 0;
        private int ships = 0;

        public MainWindow()
        {

            InitializeComponent();
            CreateButtons();
            CreateBattleShip();
            //Reveal();

        }

        private void CreateButtons()
        {
            gridArray = new String[gridSize, gridSize];
            buttonArray = new Button[gridSize, gridSize];

            for (int i = 0; i < gridSize; i++)
            {
                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength(50, GridUnitType.Pixel);
                ViewGrid.RowDefinitions.Add(rd);

                ColumnDefinition cd = new ColumnDefinition();
                cd.Width = new GridLength(50, GridUnitType.Pixel);
                ViewGrid.ColumnDefinitions.Add(cd);
            }

            for (int X = 0; X < gridSize; X++)
            {
                for (int Y = 0; Y < gridSize; Y++)
                {
                    Button btn = new Button();
                    btn.Click += gridClicked(X, Y);
                    btn.Content = "Shoot";
                    buttonArray[X, Y] = btn;
                    btn.Margin = new Thickness(2, 2, 2, 2);
                    ViewGrid.Children.Add(btn);
                    Grid.SetColumn(btn, X);
                    Grid.SetRow(btn, Y);
                }
            }

        }

        public void Reveal()
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    buttonArray[i, j].Content = gridArray[i, j];
                }
            }
        }
        private void Clear()
        {
            dimensionX.Clear();
            dimensionY.Clear();
        }
        private void BattleshipDirection(int antal)
        {
            randomNumberX = random.Next(0, gridSize);
            randomNumberY = random.Next(0, gridSize);
            int dimension = random.Next(1,3);

            for (int i = 0; i < 10; i++)
            {
                dimensionX.Add(0);
                dimensionY.Add(0);
            }

            if (dimension == 1)
            {
                dimensionX.Clear();
                for (int i = 0; i < antal; i++)
                {
                    dimensionX.Add(i);
                }
            }
            else if (dimension == 2)
            {
                dimensionY.Clear();
                for (int i = 0; i < antal; i++)
                {
                    dimensionY.Add(i);
                }
            }
        }
        public void CreateBattleShip()
        {
            AddTwo();
            AddThree();
            AddFour();
            AddFive();
            FillGrid();
        }
        public void FillGrid()
        {
            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    if (gridArray[x, y] == null)
                    {
                        gridArray[x, y] = "X";
                    }
                }
            }
        }
        public void Rules()
        {
            
            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    if (buttonArray[x,y].Content != "X" && buttonArray[x,y].Content != "Shoot") ships++;
                }
            }
            if (ships == 14) GameOver();
            else ships = 0;
        }
        public void GameOver()
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    buttonArray[i, j].IsEnabled = false;
                    
                }
            }
            CounterTextBlock.Text = "Du har vundet! \nDu ramte forbi " + shotsFired + " gange.";
        }

        public void AddTwo()
        {
            Here: ;
            Clear();
            int minAntal = 2;
            int maxAntal = gridSize - minAntal;
            BattleshipDirection(minAntal);

            if (randomNumberX > maxAntal || randomNumberY > maxAntal) goto Here;
            else
            {
                if (gridArray[randomNumberX, randomNumberY] == null &&
                    gridArray[randomNumberX + dimensionX[1], randomNumberY + dimensionY[1]] == null)
                {
                    gridArray[randomNumberX, randomNumberY] = "Ship" + minAntal;
                    gridArray[randomNumberX + dimensionX[1], randomNumberY + dimensionY[1]] = "Ship" + minAntal;

                }
                else
                {
                    goto Here;
                }
            }
        }
        public void AddThree()
        {
            Here:;
            Clear();
            int minAntal = 3;
            int maxAntal = gridSize - minAntal;
            BattleshipDirection(minAntal);

            if (randomNumberX > maxAntal || randomNumberY > maxAntal) goto Here;
            else
            {
                if (gridArray[randomNumberX, randomNumberY] == null &&
                    gridArray[randomNumberX + dimensionX[1], randomNumberY + dimensionY[1]] == null &&
                    gridArray[randomNumberX + dimensionX[2], randomNumberY + dimensionY[2]] == null)
                {
                    gridArray[randomNumberX, randomNumberY] = "Ship" + minAntal;
                    gridArray[randomNumberX + dimensionX[1], randomNumberY + dimensionY[1]] = "Ship" + minAntal;
                    gridArray[randomNumberX + dimensionX[2], randomNumberY + dimensionY[2]] = "Ship" + minAntal;

                }
                else
                {
                    goto Here;
                }
            }
        }
        public void AddFour()
        {
            Here:;
            Clear();
            int minAntal = 4;
            int maxAntal = gridSize - minAntal;
            BattleshipDirection(minAntal);

            if (randomNumberX > maxAntal || randomNumberY > maxAntal) goto Here;
            else
            {
                if (gridArray[randomNumberX, randomNumberY] == null &&
                    gridArray[randomNumberX + dimensionX[1], randomNumberY + dimensionY[1]] == null &&
                    gridArray[randomNumberX + dimensionX[2], randomNumberY + dimensionY[2]] == null &&
                    gridArray[randomNumberX + dimensionX[3], randomNumberY + dimensionY[3]] == null)
                {
                    gridArray[randomNumberX, randomNumberY] = "Ship" + minAntal;
                    gridArray[randomNumberX + dimensionX[1], randomNumberY + dimensionY[1]] = "Ship" + minAntal;
                    gridArray[randomNumberX + dimensionX[2], randomNumberY + dimensionY[2]] = "Ship" + minAntal;
                    gridArray[randomNumberX + dimensionX[3], randomNumberY + dimensionY[3]] = "Ship" + minAntal;

                }
                else
                {
                    goto Here;
                }
            }
        }
        public void AddFive()
        {
            Here:;
            Clear();
            int minAntal = 5;
            int maxAntal = gridSize - minAntal;
            BattleshipDirection(minAntal);

            if (randomNumberX > maxAntal || randomNumberY > maxAntal) goto Here;
            else
            {
                if (gridArray[randomNumberX, randomNumberY] == null &&
                    gridArray[randomNumberX + dimensionX[1], randomNumberY + dimensionY[1]] == null &&
                    gridArray[randomNumberX + dimensionX[2], randomNumberY + dimensionY[2]] == null &&
                    gridArray[randomNumberX + dimensionX[3], randomNumberY + dimensionY[3]] == null &&
                    gridArray[randomNumberX + dimensionX[4], randomNumberY + dimensionY[4]] == null)
                {
                    gridArray[randomNumberX, randomNumberY] = "Ship" + minAntal;
                    gridArray[randomNumberX + dimensionX[1], randomNumberY + dimensionY[1]] = "Ship" + minAntal;
                    gridArray[randomNumberX + dimensionX[2], randomNumberY + dimensionY[2]] = "Ship" + minAntal;
                    gridArray[randomNumberX + dimensionX[3], randomNumberY + dimensionY[3]] = "Ship" + minAntal;
                    gridArray[randomNumberX + dimensionX[4], randomNumberY + dimensionY[4]] = "Ship" + minAntal;

                }
                else
                {
                    goto Here;
                }
            }
        }


        private RoutedEventHandler gridClicked(int i, int j)
        {
            return (btn, e) =>
            {
                buttonArray[i, j].Content = gridArray[i, j];
                buttonArray[i, j].IsEnabled = false;
                if (gridArray[i, j] == "X")
                {
                    shotsFired++;
                    CounterTextBlock.Text = "Shots Missed: " + shotsFired;
                }
                Rules();
            };
        }
    }
}
