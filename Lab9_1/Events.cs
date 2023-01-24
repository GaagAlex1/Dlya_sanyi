using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab9_1
{
    public partial class MainWindow : Window
    {
        private void RandomButton_Click(object sender, RoutedEventArgs e)
        {
            if (Size.Text != "")
            {
                pointList = new PointArray(Convert.ToInt32(Size.Text));
                foreach (Canvas c in canvases)
                {
                    List.Children.Remove(c);
                }
                Canvas.SetTop(plusButton, 5);
                canvases = new List<Canvas>();
                choosedItems = new List<Canvas>();
                rightClick = false;

                foreach (Point pt in pointList)
                {
                    MoveDown();

                    Canvas cnv = CreateFilled(pt);
                    canvases.Add(cnv);
                    List.Children.Add(cnv);
                }
            }
        }

        private void CreationButton_Click(object sender, RoutedEventArgs e)
        {
            Canvas thisBlock = (sender as Button).Parent as Canvas;
            TextBox tb1 = thisBlock.Children[0] as TextBox;
            TextBox tb2 = thisBlock.Children[1] as TextBox;
            Button btn = sender as Button;
            Ellipse ind = thisBlock.Children[3] as Ellipse;

            if (tb1.Text != "" && tb2.Text != "")
            {
                Point pt = new Point(Convert.ToDouble(tb1.Text), Convert.ToDouble(tb2.Text));
                pointList += pt;

                ind.Fill = new SolidColorBrush(Color.FromRgb(228, 232, 240));

                btn.Click -= CreationButton_Click;
                btn.Click += DeletionButton_Click;
            }
        }

        private void DeletionButton_Click(object sender, RoutedEventArgs e)
        {

            Canvas thisBlock = (sender as Button).Parent as Canvas;
            int idx = canvases.IndexOf(thisBlock);
            MoveUp(idx);

            List.Children.Remove(thisBlock);
            pointList -= pointList[idx];
            choosedItems.Remove(thisBlock);
        }

        private void Cnv_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Output.Text = "";
            xPt.Text = "";
            yPt.Text = "";
            if (canvasIndex != -1) (canvases[canvasIndex].Children[3] as Ellipse).Fill = new SolidColorBrush(Color.FromRgb(228, 232, 240));
            rightClick = false;
            canvasIndex = -1;

            xPt.Visibility = Visibility.Hidden;
            yPt.Visibility = Visibility.Hidden;

            Canvas item = sender as Canvas;
            Ellipse indicator = item.Children[3] as Ellipse;

            if (choosedItems.IndexOf(item) != -1) return;
            indicator.Fill = new SolidColorBrush(Color.FromRgb(189, 240, 70));
            choosedItems.Add(item);
            if (choosedItems.Count == 2)
            {
                calculateButton.Visibility = Visibility.Visible;
            }
            if (choosedItems.Count > 2)
            {
                Ellipse prevIndicator = choosedItems[0].Children[3] as Ellipse;
                prevIndicator.Fill = new SolidColorBrush(Color.FromRgb(228, 232, 240));

                choosedItems.Remove(choosedItems[0]);
            }
        }

        private void Cnv_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (canvasIndex != -1) (canvases[canvasIndex].Children[3] as Ellipse).Fill = new SolidColorBrush(Color.FromRgb(228, 232, 240));
            canvasIndex = canvases.IndexOf(sender as Canvas);

            foreach (Canvas cnv in choosedItems)
            {
                Ellipse ellp = cnv.Children[3] as Ellipse;
                ellp.Fill = new SolidColorBrush(Color.FromRgb(228, 232, 240));
            }
            choosedItems.Clear();

            Output.Text = "";
            xPt.Text = "";
            yPt.Text = "";

            ((sender as Canvas).Children[3] as Ellipse).Fill = new SolidColorBrush(Color.FromRgb(124, 162, 222));
            rightClick = true;

            calculateButton.Visibility = Visibility.Visible;
            Output.Visibility = Visibility.Visible;
            yPt.Visibility = Visibility.Visible;
            xPt.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pointList.Points.Length == canvases.Count)
            {
                MoveDown();

                Canvas cnv = CreatePointUI();
                canvases.Add(cnv);
                List.Children.Add(cnv);
            }
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (rightClick)
            {
                if (xPt.Text != "" && yPt.Text != "")
                {
                    Point pt1 = pointList.Points[canvasIndex];
                    Point currPoint = new Point(Convert.ToDouble(xPt.Text), Convert.ToDouble(yPt.Text));

                    Output.Text = (pt1 + currPoint).ToString();
                }
            }
            else if (choosedItems.Count == 2)
            {
                Point pt1 = pointList.Points[canvases.IndexOf(choosedItems[0])];
                Point pt2 = pointList.Points[canvases.IndexOf(choosedItems[1])];

                Output.Text = (pt1 + pt2).ToString();
            }
            Output.Visibility = Visibility.Visible;
        }

        private void maxElem_Click(object sender, RoutedEventArgs e)
        {
            ClOutput.Text = "(" + pointList.ClosestToCenter(pointList).X.ToString() + ";" + pointList.ClosestToCenter(pointList).Y.ToString() + ")";
        }

        private void DoubleHandle(object sender, KeyEventArgs e)
        {
            if (!CheckForDouble(sender, e))
            {
                e.Handled = true;
            }
        }

        private void IntHandle(object sender, KeyEventArgs e)
        {
            if (!CheckForInt(sender, e))
            {
                e.Handled = true;
            }
        }

        bool CheckForDouble(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string inp = tb.Text;
            int commaAmount = inp.Count(a => a == ',');

            if (inp.Length <= 15)
            {
                if (inp.Length == 1 && inp[0] == '0') return e.Key == Key.OemComma && commaAmount == 0;
                else
                {
                    return (e.Key <= Key.D9 && e.Key >= Key.D0) || (e.Key == Key.OemComma && commaAmount == 0);
                }
            }
            else
            {
                return false;
            }
        }

        bool CheckForInt(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string inp = tb.Text;

            if (inp.Length <= 15)
            {
                if (inp.Length == 1 && inp[0] == '0') return false;
                else
                {
                    return e.Key <= Key.D9 && e.Key >= Key.D0;
                }
            } else
            {
                return false;
            }
            
        }
    }
}
