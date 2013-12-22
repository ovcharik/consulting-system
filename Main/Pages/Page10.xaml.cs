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
    public partial class Page10 : Page, IPage
    {
        Answers answers;

        public Page10(Answers ans)
        {
            answers = ans;
            InitializeComponent();
        }

        public Int32 NextOffset()
        {
            return 1;
        }

        public void Clear()
        {
            answers.Q_10_ready = false;
            answers.Q_10.Clear();
            fullCheckBox.IsChecked = false;
            attrCheckBox.IsChecked = false;
            doubCheckBox.IsChecked = false;
        }


        private void Button_Checked(object sender, RoutedEventArgs e)
        {
            var but = sender as CheckBox;
            var s = but.Content.ToString();
            answers.Q_10_ready = true;
            answers.Q_10.Add(s);
        }

        private void Button_Unchecked(object sender, RoutedEventArgs e)
        {
            var but = sender as CheckBox;
            var s = but.Content.ToString();
            answers.Q_10_ready = true;
            answers.Q_10.Remove(s);
        }
    }
}
