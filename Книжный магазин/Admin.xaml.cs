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

namespace Книжный_магазин
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        List<Книги> ServiswList1 = BD.EM.Книги.ToList();
        List<Книги> ServiswList = new List<Книги>();
        public Admin()
        {
            InitializeComponent();
            ServiswList = ServiswList1;
            DGServises.ItemsSource = ServiswList;
        }
        int i = -1;
        int indexChange;
        private void MediaElement_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                i++;
                MediaElement ME = (MediaElement)sender;
                Книги S = ServiswList[i];
                Uri U = new Uri(S.Обложка, UriKind.RelativeOrAbsolute);
                ME.Source = U;
                //   i++;
            }

        }

        private void TextBlock_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Книги S = ServiswList[i];
                TB.Text = S.Название;
              
                //  i++;
            }


        }

        private void BRed_Initialized(object sender, EventArgs e)
        {
            Button BtnRed = (Button)sender;
            if (BtnRed != null)
            {
                BtnRed.Uid = Convert.ToString(i);
            }

        }
        private void StackPanel_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                StackPanel SP = (StackPanel)sender;
                Книги S = ServiswList[i];
                if (S.Цена != 0)
                {
                    SP.Background = new SolidColorBrush(Color.FromRgb(240, 255, 240));
                }
            }

        }

        private void autor_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Книги S = ServiswList[i];
                TB.Text = S.Авторы.Автор;

                //  i++;
            }
        }

        private void cost_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Книги S = ServiswList[i];
                TB.Text = Convert.ToString("Цена:"+S.Цена);

                //  i++;
            }
        }

        private void kolvmagaz_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Книги S = ServiswList[i];
                if (S.Количество_склад >= 5)
                {
                    TB.Text = "Количество в магазине: много";
                }
                else
                {
                    TB.Text = Convert.ToString("Количество в магазине:" + S.Количество_магазин);


                }//  i++;
            }   
        }

        private void kolsklad_Initialized(object sender, EventArgs e)
        {
            if (i < ServiswList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Книги S = ServiswList[i];
                if(S.Количество_склад >= 5)
                {
                    TB.Text = "Количество на складе: много";
                }
                else
                {
                    TB.Text = Convert.ToString("Количество на складе:" + S.Количество_склад);
                }
 

                //  i++;
            }
        }
        private void Zakaz_Initialized(object sender, EventArgs e)
        {
            Button Zakaz = (Button)sender;
            if (Zakaz != null)
            {
                Zakaz.Uid = Convert.ToString(i);
            }
        }
        int k = 0;
        int PriceCost = 0;
        private void Zakaz_Click(object sender, RoutedEventArgs e)
        {
            stZakaz.Visibility = Visibility.Visible;
            Button Zakaz = (Button)sender;
            int ind = Convert.ToInt32(Zakaz.Uid);
            indexChange = Convert.ToInt32(Zakaz.Uid);
            Книги S = ServiswList[ind];
            k++;
            kolKnig.Text = Convert.ToString(+k);
            int price = S.Цена;
            PriceCost += price;
            skidka.Text = PriceCost + "руб.";

            skidkaObsh.Text = 0 + "%";
            if(k>3 || k == 3)
            {
                obshcena.Text = (PriceCost -((PriceCost/100)*5)) + "руб.";
                skidkaObsh.Text = 5 + "%";
                skidka.TextDecorations = TextDecorations.Strikethrough;
            }
            if (k > 5 || k == 5)
            {
                obshcena.Text = (PriceCost - ((PriceCost / 100) * 10)) + "руб.";
                skidkaObsh.Text = 10 + "%";
                skidka.TextDecorations = TextDecorations.Strikethrough;
            }
            if (k > 10 || k == 10)
            {
                obshcena.Text = (PriceCost - ((PriceCost / 100) * 15)) + "руб.";
                skidkaObsh.Text = 15 + "%";
                skidka.TextDecorations = TextDecorations.Strikethrough;
            }
        }

      
    }
}
