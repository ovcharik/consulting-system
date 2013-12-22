using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class Last : Page
    {
        public ObservableCollection<Answer> AnswersList = new ObservableCollection<Answer>();
        public ObservableCollection<Result> ResultsList = new ObservableCollection<Result>();

        public Last()
        {
            InitializeComponent();
            AnswersListBox.ItemsSource = AnswersList;
            ResultsListBox.ItemsSource = ResultsList;
        }

        public void SetAnswers(Answers ans)
        {
            AnswersList.Clear();

            if (ans.Q_1_ready)
                AnswersList.Add(new Answer() { Name = Answers.Q_1_str, Value = (ans.Q_1 ? "Да" : "Нет") });
            if (ans.Q_2_ready)
                AnswersList.Add(new Answer() { Name = Answers.Q_2_str, Value = (ans.Q_2 ? "Да" : "Нет") });
            if (ans.Q_3_ready)
                AnswersList.Add(new Answer() { Name = Answers.Q_3_str, Value = (ans.Q_3 ? "Да" : "Нет") });
            if (ans.Q_4_ready)
                AnswersList.Add(new Answer() { Name = Answers.Q_4_str, Value = (ans.Q_4 ? "Да" : "Нет") });
            if (ans.Q_5_ready)
                AnswersList.Add(new Answer() { Name = Answers.Q_5_str, Value = ans.Q_5.ToString() });
            if (ans.Q_6_ready)
                AnswersList.Add(new Answer() { Name = Answers.Q_6_str, Value = (ans.Q_6 ? "Да" : "Нет") });
            if (ans.Q_7_ready)
                AnswersList.Add(new Answer() { Name = Answers.Q_7_str, Value = ans.Q_7 });
            if (ans.Q_8_ready)
                AnswersList.Add(new Answer() { Name = Answers.Q_8_str, Value = (ans.Q_8 ? "Да" : "Нет") });
            if (ans.Q_9_ready)
                AnswersList.Add(new Answer() { Name = Answers.Q_9_str, Value = ans.Q_9 });
            if (ans.Q_10_ready)
                AnswersList.Add(new Answer() { Name = Answers.Q_10_str, Value = String.Join(", ", ans.Q_10) });
            if (ans.Q_11_ready)
                AnswersList.Add(new Answer() { Name = Answers.Q_11_str, Value = ans.Q_11.ToString() });
            if (ans.Q_12_ready)
                AnswersList.Add(new Answer() { Name = Answers.Q_12_str, Value = ans.Q_12.ToString() });
            if (ans.Q_13_ready)
                AnswersList.Add(new Answer() { Name = Answers.Q_13_str, Value = (ans.Q_13 ? "Да" : "Нет") });
        }

        public void SetResults(List<Result> results)
        {
            ResultsList.Clear();

            results.Sort((x, y) =>
            {
                if (x.Value > y.Value)
                    return 1;
                else if (x.Value < y.Value)
                    return -1;
                else
                    return 0;
            });

            int q = (new Random()).Next(3) + 3;
            for (int i = 0; i < q; i++)
                ResultsList.Add(results[i]);
        }
    }
}
