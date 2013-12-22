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
    public partial class Page5 : Page, IPage
    {
        Answers answers;

        public Page5(Answers ans)
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
            answers.Q_5_ready = false;
            countTextBox.Text = "";
        }

        private void countTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            int v = -1;

            if (Int32.TryParse(tb.Text, out v) == false)
            {
                TextChange tc = e.Changes.ElementAt<TextChange>(0);
                int add = tc.AddedLength;
                int off = tc.Offset;

                tb.Text = tb.Text.Remove(off, add);
            }
            else
            {
                answers.Q_5 = Int32.Parse(tb.Text);
            }

            answers.Q_5_ready = (tb.Text.Length != 0);
        }
    }
}
