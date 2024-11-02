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
using Library;

namespace WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var bm = new WriteableBitmap(320, 320, 120, 120, PixelFormats.Bgr32, null);
        SpiraalImage.Source = bm;
    }

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        var priem = new Xennan.Math.Primes(1000000);
        var generator = new CoordinatesGenerator(130);
        var bm = (WriteableBitmap)SpiraalImage.Source;
        byte[] colorData = { 255, 255, 255, 255 };
        int stride = bm.PixelWidth * bm.Format.BitsPerPixel / 8;
        foreach (var (item1, item2, item3) in generator.GetCoordinates())
        {
            var rect = new Int32Rect(item2 + 160, item3 + 160, 1, 1);
            if (item1 > 1 && priem.IsPrime(item1))
            {
                bm.WritePixels(rect, colorData, stride, 0);
            }
        }
    }
}
