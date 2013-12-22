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

namespace Main
{
    public partial class MainWindow : Window
    {
        protected List<Page> pages = new List<Page>();
        protected Page firstPage;
        protected Page lastPage;
        protected Int32 current;

        protected Boolean first = true;
        protected Boolean last = false;

        protected Answers answers = new Answers();
        protected List<Result> results = new List<Result>();

        protected Stack<Int32> steps = new Stack<Int32>();

        public MainWindow()
        {
            InitializeComponent();

            firstPage = new Pages.First();
            lastPage = new Pages.Last();

            pages.Add(new Pages.Page1(answers));
            pages.Add(new Pages.Page2(answers));
            pages.Add(new Pages.Page3(answers));
            pages.Add(new Pages.Page4(answers));
            pages.Add(new Pages.Page5(answers));
            pages.Add(new Pages.Page6(answers));
            pages.Add(new Pages.Page7(answers));
            pages.Add(new Pages.Page8(answers));
            pages.Add(new Pages.Page9(answers));
            pages.Add(new Pages.Page10(answers));
            pages.Add(new Pages.Page11(answers));
            pages.Add(new Pages.Page12(answers));
            pages.Add(new Pages.Page13(answers));

            results.Add(new Result() { Answers = answers, Name = "DocsVision",         P_1 = true,  P_2 = true,  P_3 = true,  P_4 = false, P_5 = 10, P_6 = true,  P_7 = new [] {"Windows"},                      P_8 = true,  P_9 = new [] {"Windows"},                   P_10 = new [] {"По содержимому", "По атрибутам", "Совмещенный"}, P_11 = 5000  });
            results.Add(new Result() { Answers = answers, Name = "Мотив",              P_1 = true,  P_2 = true,  P_3 = true,  P_4 = true,  P_5 = 0,  P_6 = true,  P_7 = new [] {"Облачный", "Windows", "Linux"}, P_8 = true,  P_9 = new [] {"Windows", "MacOS"},          P_10 = new [] {"По содержимому", "По атрибутам", "Совмещенный"}, P_11 = 0     });
            results.Add(new Result() { Answers = answers, Name = "Directum",           P_1 = false, P_2 = true,  P_3 = true,  P_4 = true,  P_5 = 10, P_6 = true,  P_7 = new [] {"Облачный", "Windows"},          P_8 = true,  P_9 = new [] {"Windows", "MacOS"},          P_10 = new [] {"По содержимому", "По атрибутам", "Совмещенный"}, P_11 = 5000  });
            results.Add(new Result() { Answers = answers, Name = "GlobusProfessional", P_1 = true,  P_2 = false, P_3 = false, P_4 = false, P_5 = 0,  P_6 = false, P_7 = new [] {"Windows", "Linux"},             P_8 = false, P_9 = new [] {"Windows", "MacOS", "Linux"}, P_10 = new [] {"По содержимому", "По атрибутам"},                P_11 = 5000  });
            results.Add(new Result() { Answers = answers, Name = "1С:Документооборот", P_1 = true,  P_2 = false, P_3 = false, P_4 = false, P_5 = 0,  P_6 = true,  P_7 = new [] {"Облачный", "Windows", "Linux"}, P_8 = true,  P_9 = new [] {"Windows", "MacOS", "Linux"}, P_10 = new [] {"По содержимому", "По атрибутам"},                P_11 = 5000  });
            results.Add(new Result() { Answers = answers, Name = "Босс-референт",      P_1 = true,  P_2 = false, P_3 = true,  P_4 = false, P_5 = 10, P_6 = true,  P_7 = new [] {"Windows", "Linux"},             P_8 = true,  P_9 = new [] {"Windows", "MacOS"},          P_10 = new [] {"По содержимому", "По атрибутам", "Совмещенный"}, P_11 = 5000  });
            results.Add(new Result() { Answers = answers, Name = "Дело",               P_1 = true,  P_2 = true,  P_3 = false, P_4 = true,  P_5 = 10, P_6 = true,  P_7 = new [] {"Облачный", "Windows", "Linux"}, P_8 = true,  P_9 = new [] {"Windows", "Linux"},          P_10 = new [] {"По содержимому", "По атрибутам", "Совмещенный"}, P_11 = 5000  });
            results.Add(new Result() { Answers = answers, Name = "Е1:Евфрат",          P_1 = true,  P_2 = true,  P_3 = true,  P_4 = true,  P_5 = 10, P_6 = true,  P_7 = new [] {"Windows"},                      P_8 = true,  P_9 = new [] {"Windows"},                   P_10 = new [] {"По содержимому", "По атрибутам", "Совмещенный"}, P_11 = 0     });
            results.Add(new Result() { Answers = answers, Name = "FossDoc",            P_1 = true,  P_2 = true,  P_3 = false, P_4 = true,  P_5 = 0,  P_6 = false, P_7 = new [] {"Windows"},                      P_8 = true,  P_9 = new [] {"Windows"},                   P_10 = new [] {"По атрибутам"},                                  P_11 = 5000  });
            results.Add(new Result() { Answers = answers, Name = "LanDocs",            P_1 = true,  P_2 = false, P_3 = false, P_4 = false, P_5 = 0,  P_6 = false, P_7 = new [] {"Windows"},                      P_8 = true,  P_9 = new [] {"Windows"},                   P_10 = new [] {"По содержимому", "По атрибутам", "Совмещенный"}, P_11 = 10000 });
        }

        protected void UpdateButtons()
        {
            backButton.IsEnabled = true;
            if (first)
                backButton.Content = "Выход";
            else
            {
                backButton.Content = "Назад";
                if (steps.Count == 0)
                    backButton.IsEnabled = false;
            }
            if (first)
                nextButton.Content = "Приступить";
            else if (last)
                nextButton.Content = "Сначала";
            else
                nextButton.Content = "Далее";
        }

        protected void GotoFirst()
        {
            current = -1;
            first = true;
            last = false;
            mainFrame.NavigationService.Navigate(firstPage);
            UpdateButtons();
        }

        protected void Goto(int n, bool fwd = true)
        {
            if (n >= pages.Count)
            {
                GotoLast();
                return;
            }
            if (fwd)
            {
                if (n == 0)
                    steps.Clear();
                else
                    steps.Push(current);
            }
            current = n;
            first = false;
            last = false;
            mainFrame.NavigationService.Navigate(pages[n]);
            UpdateButtons();
        }

        protected void GotoLast()
        {
            printButton.Visibility = Visibility.Visible;
            CalcResults();
            steps.Push(current);
            current = -1;
            first = false;
            last = true;
            (lastPage as Pages.Last).SetAnswers(answers);
            (lastPage as Pages.Last).SetResults(results);
            mainFrame.NavigationService.Navigate(lastPage);
            UpdateButtons();
        }

        protected void ClearPages()
        {
            foreach (Pages.IPage page in pages)
                page.Clear();
        }

        protected void CalcResults()
        {
            foreach (Result r in results)
                r.CalcValue();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            GotoFirst();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            printButton.Visibility = Visibility.Hidden;
            if (first || last)
            {
                ClearPages();
                Goto(0);
            }
            else
            {
                int o = (pages[current] as Pages.IPage).NextOffset();
                for (int i = 1; i < o; i++)
                {
                    if (current + i >= pages.Count) break;
                    (pages[current + i] as Pages.IPage).Clear();
                }
                Goto(current + o);
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (first)
                Close();
            else if (steps.Count != 0)
            {
                Goto(steps.Pop(), false);
            }
                
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog p = new PrintDialog();
            if (p.ShowDialog() == true)
            {
                double h = MaxHeight;
                double h1 = Height;
                MaxHeight = 700;
                Height = 700;
                p.PrintVisual(this, "Результат тестирования");
                Height = h1;
                MaxHeight = h;
            }
        }
    }
}
