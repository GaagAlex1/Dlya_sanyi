using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab9_1
{
    public partial class MainWindow : Window
    {
        private PointArray pointList = new PointArray();
        private List<Canvas> canvases = new List<Canvas>();
        private List<Canvas> choosedItems = new List<Canvas>();
        bool rightClick = false;
        int canvasIndex;

        public MainWindow()
        {
            InitializeComponent();
        }

        private Canvas CreatePointUI()
        {
            Canvas cnv = new Canvas();
            cnv.Width = 300;
            cnv.Height = 30;
            Canvas.SetTop(cnv, 5);
            cnv.MouseLeftButtonDown += Cnv_MouseLeftButtonDown;
            cnv.MouseRightButtonDown += Cnv_MouseRightButtonDown;

            Ellipse indicator = new Ellipse();
            indicator.Width = 15;
            indicator.Height = 15;
            Canvas.SetTop(indicator, 6);
            Canvas.SetLeft(indicator, 55);

            TextBox pointX = new TextBox();
            pointX.Width = 50;
            pointX.Height = 20;
            pointX.KeyDown += DoubleHandle;
            Canvas.SetTop(pointX, 5);
            Canvas.SetLeft(pointX, 80);

            TextBox pointY = new TextBox();
            pointY.Width = 50;
            pointY.Height = 20;
            pointY.KeyDown += DoubleHandle;
            Canvas.SetTop(pointY, 5);
            Canvas.SetLeft(pointY, 140);

            Button createButton = new Button();
            createButton.Click += CreationButton_Click;
            createButton.Width = 25;
            createButton.Height = 20;
            createButton.Style = Resources["RoundedButtonStyle"] as Style;
            Canvas.SetTop(createButton, 5);
            Canvas.SetLeft(createButton, 200);

            cnv.Children.Add(pointX);
            cnv.Children.Add(pointY);
            cnv.Children.Add(createButton);
            cnv.Children.Add(indicator);

            return cnv;
        }

        private Canvas CreateFilled(Point pt)
        {
            Canvas cnv = new Canvas();
            cnv.Width = 300;
            cnv.Height = 30;
            Canvas.SetTop(cnv, 5);
            cnv.MouseLeftButtonDown += Cnv_MouseLeftButtonDown;
            cnv.MouseRightButtonDown += Cnv_MouseRightButtonDown;

            Ellipse indicator = new Ellipse();
            indicator.Width = 15;
            indicator.Height = 15;
            indicator.Fill = new SolidColorBrush(Color.FromRgb(228, 232, 240));
            Canvas.SetTop(indicator, 6);
            Canvas.SetLeft(indicator, 55);

            TextBox pointX = new TextBox();
            pointX.Width = 50;
            pointX.Height = 20;
            Canvas.SetTop(pointX, 5);
            Canvas.SetLeft(pointX, 80);
            pointX.Text = pt.X.ToString();

            TextBox pointY = new TextBox();
            pointY.Width = 50;
            pointY.Height = 20;
            Canvas.SetTop(pointY, 5);
            Canvas.SetLeft(pointY, 140);
            pointY.Text = pt.Y.ToString();

            Button createButton = new Button();
            createButton.Click += DeletionButton_Click;
            createButton.Width = 25;
            createButton.Height = 20;
            createButton.Style = Resources["RoundedButtonStyle"] as Style;
            Canvas.SetTop(createButton, 5);
            Canvas.SetLeft(createButton, 200);

            cnv.Children.Add(pointX);
            cnv.Children.Add(pointY);
            cnv.Children.Add(createButton);
            cnv.Children.Add(indicator);

            return cnv;
        }

        private void MoveDown()
        {
            Canvas.SetTop(plusButton, Canvas.GetTop(plusButton) + 30);
            foreach (Canvas cnv in canvases)
            {
                Canvas.SetTop(cnv, Canvas.GetTop(cnv) + 30);
            }
        }

        private void MoveUp(int idx) 
        {
            Canvas.SetTop(plusButton, Canvas.GetTop(plusButton) - 30);
            for (int i = 0; i < idx; i++)
            {
                Canvas.SetTop(canvases[i], Canvas.GetTop(canvases[i]) - 30);
            }
        }
    }
}
