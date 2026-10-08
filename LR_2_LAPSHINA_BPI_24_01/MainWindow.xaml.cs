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

namespace LR_2_LAPSHINA_BPI_24_01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Formula_1 form1 = new Formula_1();
        private Formula_2 form2 = new Formula_2();
        private Formula_3 form3 = new Formula_3();
        private Formula_4 form4 = new Formula_4();
        private Formula_5 form5 = new Formula_5();

        public MainWindow()
        {
            InitializeComponent();

            Img1.Source = form1.WpfSource;
            Img2.Source = form2.WpfSource;
            Img3.Source = form3.WpfSource;
            Img4.Source = form4.WpfSource;
            Img5.Source = form5.WpfSource;

            BtnCalc.Click += Calc_Click;

            Radio1.Checked += editReadOnlyForm1;
            Radio2.Checked += editReadOnlyForm2;
            Radio3.Checked += editReadOnlyForm3;
            Radio4.Checked += editReadOnlyForm4;
            Radio5.Checked += editReadOnlyForm5;

            R1TextA.TextChanged += validateInput;
            R2TextA.TextChanged += validateInput;
            R2TextB.TextChanged += validateInput;
            R3TextA.TextChanged += validateInput;
            R3TextB.TextChanged += validateInput;
            R4TextD.TextChanged += validateInput;
            R4TextA.TextChanged += validateInput;
            R5TextX.TextChanged += validateInput;
            R5TextY.TextChanged += validateInput;

            editReadOnlyForm1(null, null);
        }


        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Formula selected = null;

                // ---------- Формула 1: S = sin(f·a) ----------
                if (Radio1.IsChecked == true)
                {
                    form1.A = double.Parse(R1TextA.Text);
                    form1.F = double.Parse(R1ComboF.Text);
                    selected = form1;
                }
                // ---------- Формула 2: S = cos(f·a) + sin(f·b) ----------
                else if (Radio2.IsChecked == true)
                {
                    form2.A = double.Parse(R2TextA.Text);
                    form2.B = double.Parse(R2TextB.Text);
                    form2.F = double.Parse(R2ComboF.Text);
                    selected = form2;
                }
                // ---------- Формула 3: S = c·a² + d·b² ----------
                else if (Radio3.IsChecked == true)
                {
                    form3.A = double.Parse(R3TextA.Text);
                    form3.B = double.Parse(R3TextB.Text);
                    form3.C = double.Parse(R3ComboC.Text);
                    form3.D = double.Parse(R3ComboD.Text);
                    selected = form3;
                }
                // ---------- Формула 4: S = Σ(c+a)^i ----------
                else if (Radio4.IsChecked == true)
                {
                    form4.A = double.Parse(R4TextA.Text);
                    form4.D = double.Parse(R4TextD.Text);
                    form4.C = double.Parse(R4ComboC.Text);
                    selected = form4;
                }
                // ---------- Формула 5 (вариант 8) ----------
                else if (Radio5.IsChecked == true)
                {
                    form5.X = double.Parse(R5TextX.Text);
                    form5.Y = double.Parse(R5TextY.Text);
                    form5.N = int.Parse(R5TextN.Text);
                    form5.K = int.Parse(R5TextK.Text);
                    selected = form5;
                }

                if (selected == null)
                {
                    MessageBox.Show("Выберите формулу!");
                    return;
                }

                double result = selected.Calculate();

                resultBox.Text = "Ответ: " + result.ToString("F4");
                this.Title = "Ответ: " + result.ToString("F4");
            }
            catch (FormatException)
            {
                MessageBox.Show("Проверьте правильность ввода чисел!",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message,
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void validateInput(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Background = Brushes.White;
                return;
            }

            try
            {
                double.Parse(tb.Text);
                tb.Background = Brushes.LightGreen;
            }
            catch
            {
                tb.Background = Brushes.LightPink;
            }
        }

        private void setAllReadOnly()
        {
            List<TextBox> textBoxes = new List<TextBox>
            {
                R1TextA,
                R2TextA, R2TextB,
                R3TextA, R3TextB,
                R4TextD, R4TextA,
                R5TextX, R5TextY
            };

            foreach (TextBox tb in textBoxes)
            {
                tb.Text = "";
                tb.IsReadOnly = true;
                tb.Background = Brushes.White;
            }
        }

        private void editReadOnlyForm1(object sender, RoutedEventArgs e)
        {
            setAllReadOnly();
            R1TextA.IsReadOnly = false;
        }

        private void editReadOnlyForm2(object sender, RoutedEventArgs e)
        {
            setAllReadOnly();
            R2TextA.IsReadOnly = false;
            R2TextB.IsReadOnly = false;
        }

        private void editReadOnlyForm3(object sender, RoutedEventArgs e)
        {
            setAllReadOnly();
            R3TextA.IsReadOnly = false;
            R3TextB.IsReadOnly = false;
        }

        private void editReadOnlyForm4(object sender, RoutedEventArgs e)
        {
            setAllReadOnly();
            R4TextD.IsReadOnly = false;
            R4TextA.IsReadOnly = false;
        }

        private void editReadOnlyForm5(object sender, RoutedEventArgs e)
        {
            setAllReadOnly();
            R5TextX.IsReadOnly = false;
            R5TextY.IsReadOnly = false;
        }
    }
}