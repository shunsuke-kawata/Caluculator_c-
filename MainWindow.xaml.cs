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

namespace calculator
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //数値か小数点をクリックしたとき
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String s = ((Button)sender).Content.ToString();//Tostring-->string型に変換

            //tbl_display.Textが空であるとき
            if (tbl_display.Text == "")

            {
                
                if (s == "." && tbl_display.Text.IndexOf(".") >= 0)
                {
                    return;
                }
                if (s == "." && tbl_display.Text == "" )
                {
                    tbl_display.Text += "0";
                }
                tbl_display.Text += s;
            }
            //tbl_displayが空でなく、演算子がないとき
            else if(tbl_display.Text!="" && en_tbl.Text == "")
            {
                if (s == "." && tbl_display.Text.IndexOf(".") >= 0)
                {
                    return;
                }
                if ((s == "." && tbl_display.Text == "")|| (s=="." && tbl_display.Text=="-"))
                {
                    tbl_display.Text += "0";
                }
                else if (s != "." && tbl_display.Text == "0")
                {
                    tbl_display.Text = "";
                }
                tbl_display.Text += s;
            }
            else if(tbl_display.Text!="" && en_tbl.Text != "")
            {
                if (s == "." && tbl_display2.Text.IndexOf(".") >= 0)
                {
                    return;
                }
                if ((s == "." && tbl_display2.Text == "") || (s=="." && tbl_display2.Text=="-"))
                {
                    tbl_display2.Text += "0";
                }
                else if (s!="." && tbl_display2.Text == "0")
                {
                    tbl_display2.Text = "";
                }
                tbl_display2.Text += s;
            }


        }
        //String num1="";
        //=をクリックしたとき
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if(tbl_display2.Text=="" || en_tbl.Text=="" || tbl_display.Text == ""
                || tbl_display.Text=="-" || tbl_display2.Text=="-")
            {
                MessageBox.Show("正しく入力されておりません");
                return;
            }

            string sub1 = tbl_display.Text.Substring(tbl_display.Text.Length - 1);
            string sub2 = tbl_display2.Text.Substring(tbl_display2.Text.Length - 1);

            if(sub1=="." || sub2 == ".")
            {
                MessageBox.Show("正しく入力されておりません");
                return;
            }
            double result = 0;
            if (en_tbl.Text == "+")
            {
                result = double.Parse(tbl_display.Text) + double.Parse(tbl_display2.Text);
            }
            if (en_tbl.Text == "-")
            {
                result = double.Parse(tbl_display.Text) - double.Parse(tbl_display2.Text);
            }
            if (en_tbl.Text == "×")
            {
                result = double.Parse(tbl_display.Text) * double.Parse(tbl_display2.Text);
            }
            if (en_tbl.Text == "÷")
            {
                if (tbl_display2.Text == "0" || tbl_display2.Text=="0.0")
                {
                    MessageBox.Show("演算不可能です");
                    tbl_display2.Text = "";
                    return;
                }
                result = double.Parse(tbl_display.Text) / double.Parse(tbl_display2.Text);
            }
            
            tbl_display.Text = result.ToString();

            en_tbl.Text = "";
            tbl_display2.Text = "";



        }

        
        //演算子をクリックしたとき
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            String s = ((Button)sender).Content.ToString();//Tostring-->string型に変換
            if (tbl_display.Text == "" )
            {
                if (s == "-")
                {
                    tbl_display.Text += s;
                }
                
                return;
            }
            else if (en_tbl.Text != "" && tbl_display2.Text=="" && s == "-")
            {
                tbl_display2.Text += s;
                return;
            }

            en_tbl.Text = s;
            
        }
        //クリアをクリックしたとき
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            if (tbl_display2.Text != "")
            {
                tbl_display2.Text = "";
                return;
            }
            else if (en_tbl.Text != "")
            {
                en_tbl.Text = "";
                return;
            }
            else if (tbl_display.Text != "")
            {
                tbl_display.Text = "";
                return;
            }

        }


        //オールクリアをクリックしたとき
        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            tbl_display.Text = "";
            en_tbl.Text = "";
            tbl_display2.Text = "";

        }

        //特殊演算子をクリックしたとき
        private void Button_Click5(object sender, RoutedEventArgs e)
        {

            String s = ((Button)sender).Content.ToString();

            int k = 0;
            if (tbl_display2.Text != "")
            {
                k = 2;//display2に対して反応する
            }else if (tbl_display.Text != "")
            {
                k = 1;//display1に対して反応する
            }

            double result1 = 0;
            if (k == 0)
            {
                MessageBox.Show("正しく入力されておりません");
                return;
            }

            

            if (k == 1)//display1に対して処理を行うとき
            {

                if(tbl_display.Text=="-" || tbl_display.Text.Substring(tbl_display.Text.Length - 1) == ".")
                {
                    MessageBox.Show("正しく入力されておりません");
                    return;
                }
                
                
                if (s == "log(x)")
                {
                    if (double.Parse(tbl_display.Text) <=0 )
                    {
                        MessageBox.Show("演算不可能です");
                        return;
                    }
                    result1=Math.Log(double.Parse(tbl_display.Text));
                    

                }
                if (s == "sqrt(x)")
                {
                    if(double.Parse(tbl_display.Text) < 0)
                    {
                        MessageBox.Show("演算不可能です");
                        return;
                    }
                    result1 = Math.Sqrt(double.Parse(tbl_display.Text));
                    
                }
                if (s == "x²")
                {
                    result1 = double.Parse(tbl_display.Text) * double.Parse(tbl_display.Text);
                    
                }

                tbl_display.Text = result1.ToString();
            }

            if (k == 2)//display2に対して処理を行うとき
            {
                if (tbl_display2.Text == "-" || tbl_display2.Text.Substring(tbl_display2.Text.Length - 1) == ".")
                {
                    MessageBox.Show("正しく入力されておりません");
                    return;
                }


                if (s == "log(x)")
                {
                    if (double.Parse(tbl_display2.Text) < 1)
                    {
                        MessageBox.Show("演算不可能です");
                        return;
                    }
                    result1 = Math.Log(double.Parse(tbl_display2.Text));
                    

                }
                if (s == "sqrt(x)")
                {
                    if (double.Parse(tbl_display2.Text) < 0)
                    {
                        MessageBox.Show("演算不可能です");
                        return;
                    }
                    result1 = Math.Sqrt(double.Parse(tbl_display2.Text));
                    
                }
                if (s == "x²")
                {
                    result1 = double.Parse(tbl_display2.Text) * double.Parse(tbl_display2.Text);
                    
                }

                tbl_display2.Text = result1.ToString();



            }


        }

    }
}
