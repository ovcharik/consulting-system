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
    public partial class Page9 : Page, IPage
    {
        Answers answers;

        public Page9(Answers ans)
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
            answers.Q_9_ready = false;
            winButton.IsChecked = false;
            linButton.IsChecked = false;
            macButton.IsChecked = false;
        }

        private void Button_Checked(object sender, RoutedEventArgs e)
        {
            var but = sender as RadioButton;
            var s = but.Content.ToString();
            answers.Q_9_ready = true;
            answers.Q_9 = s;
        }
    }
}
