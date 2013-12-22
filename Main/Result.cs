using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Result
    {
        public String Name { get; set; }
        private Int32 _Value;
        public Int32 Value
        {
            get { return _Value; }
        }
        public Answers Answers { get; set; }

        public Boolean P_1 { get; set; }
        public Boolean P_2 { get; set; }
        public Boolean P_3 { get; set; }
        public Boolean P_4 { get; set; }
        public Int32 P_5 { get; set; }
        public Boolean P_6 { get; set; }
        public String[] P_7 { get; set; }
        public Boolean P_8 { get; set; }
        public String[] P_9 { get; set; }
        public String[] P_10 { get; set; }
        public Int32 P_11 { get; set; }
        public Int32 P_12 { get; set; }
        public Boolean P_13 { get; set; }

        public override String ToString()
        {
            return Name;
        }

        public void CalcValue()
        {
            _Value = 13;
            if (Answers.Q_1_ready && Answers.Q_1 && !P_1)
                _Value--;
            if (Answers.Q_2_ready && Answers.Q_2 && !P_2)
                _Value--;
            if (Answers.Q_3_ready && Answers.Q_3 && !P_3)
                _Value--;
            if (Answers.Q_4_ready && Answers.Q_4 && !P_4)
                _Value--;
            if (Answers.Q_5_ready && P_5 < 10 && Answers.Q_5 >= 10)
                _Value--;
            if (Answers.Q_6_ready && Answers.Q_6 && !P_6)
                _Value--;
            if (Answers.Q_7_ready && !P_7.Contains(Answers.Q_7))
                _Value--;
            if (Answers.Q_8_ready && Answers.Q_8 && !P_8)
                _Value--;
            if (Answers.Q_9_ready && !P_9.Contains(Answers.Q_9))
                _Value--;
            if (Answers.Q_10_ready)
            {
                bool f = true;
                foreach (String s in Answers.Q_10)
                    f &= P_10.Contains(s);
                if (!f)
                    _Value--;
            }
            if (Answers.Q_11_ready && P_11 > Answers.Q_11)
                _Value--;
        }
    }
}
