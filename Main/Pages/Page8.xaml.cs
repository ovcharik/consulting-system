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

namespace Main.Pages
{
    public partial class Page8 : Page, IPage
    {
        Answers answers;

        public Page8(Answers ans)
        {
            answers = ans;
            InitializeComponent();
        }

        public Int32 NextOffset()
        {
            if (answers.Q_8_ready && answers.Q_8)
                return 2;
            else
                return 1;
        }

        public void Clear()
        {
            answers.Q_8_ready = false;
            yesButton.IsChecked = false;
            noButton.IsChecked = false;
        }

        private void Button_Checked(object sender, RoutedEventArgs e)
        {
            var but = sender as RadioButton;
            var s = but.Content.ToString();
            answers.Q_8_ready = true;
            switch (s)
            {
            case "Да":
                answers.Q_8 = true;
                break;
            case "Нет":
                answers.Q_8 = false;
                break;
            }
        }
    }
}
