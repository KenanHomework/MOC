using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOC
{
    public class Calculate
    {
        public Calculate()
        {

        }

        public double Add(double num1, double num2) => num1 + num2;

        public double Sub(double num1, double num2) => num1 - num2;

        public double Mul(double num1, double num2) => num1 * num2;

        public double Div(double num1, double num2) => num1 / num2;

        public double Power(double num1, double power)
        {
            double res = num1;
            for (int i = 1; i < power; i++)
                res *= num1;
            return res;
        }

        public double Pip(double num) => num >= 0 ? num : num * -1;

        public double Fact(double num)
        {
            double res = num;
            for (int i = (int)num - 1; i >= 1; i--)
                res *= (num - i);
            return res;
        }

        public double Cicik(double num1, double num2) => num1 < num2 ? num1 : num2;

        public double Boyuk(double num1, double num2) => num1 > num2 ? num1 : num2;

        public bool IsBolen(double bolunen, double num) => !Convert.ToBoolean(bolunen % num);

        public bool IsSimple(double num)
        {
            if (num == 4)
                return false;
            for (int i = 2; i < (num / 2); i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }

        public List<double> SadeEdedler(double num)
        {
            List<double> list = new List<double>();
            for (int i = 2; i <= num; i++)
                if (IsSimple(i))
                    list.Add(i);
            return list;
        }

        public List<double> SadeVuruq(double num)
        {
            List<double> sadeEdedler = SadeEdedler(num);
            List<double> vuruqlar = new List<double>();


            for (int i = 0; i < sadeEdedler.Count(); i++)
            {
                if (!Convert.ToBoolean(num % sadeEdedler[i]))
                {
                    num /= sadeEdedler[i];
                    vuruqlar.Add(sadeEdedler[i]);
                    i--;
                }
            }
            return vuruqlar;

        }

        public List<double> OrtaqVuruqlar(List<double> small, List<double> big)
        {
            List<double> ortaq = new List<double>();
            foreach (int i in big)
            {
                if (small.Contains(i))
                    ortaq.Add(i);
            }
            return ortaq;
        }

        public bool IsQarshiliqliSadeEded(List<double> ortaqVuruqlar) => ortaqVuruqlar.Count == 0;

        public double LCM(double num1, double num2)
        {
            double smallNum = Cicik(num1, num2);
            double bigNum = Boyuk(num2, num1);
            double ekob = bigNum;
            /* EKOB(a,b) = a (bolunen) */
            if (IsBolen(bigNum, smallNum))
                return bigNum;

            /* EKOB(a,b) =  c */
            var smallList = SadeVuruq(smallNum);
            var bigList = SadeVuruq(bigNum);
            List<double> ortaq = OrtaqVuruqlar(smallList, bigList);

            /* Qarsiliqli sade ededlerin EKOB'u onlarin hasiline beraberdir */
            if (IsQarshiliqliSadeEded(ortaq))
                return num1 * num2;

            /* Find Different  ~ C */
            foreach (int i in ortaq)
                smallList.Remove(i);


            foreach (int i in smallList)
                ekob *= i;

            return ekob;

        }

        public double HCF(double num1, double num2)
        {
            double smallNum = Cicik(num1, num2);
            double bigNum = Boyuk(num2, num1);
            double ebob = 1;

            /* EBOB(a,b) = b (bolen) */
            if (IsBolen(bigNum, smallNum))
                return smallNum;

            /* Ortaq Vuruqlar */
            var smallList = SadeVuruq(smallNum);
            var bigList = SadeVuruq(bigNum);
            List<double> ortaq = OrtaqVuruqlar(smallList, bigList);

            /* Qarsiliqli sade ededlerin EBOB'u 1-dir */
            if (IsQarshiliqliSadeEded(ortaq))
                return 1;

            /* EBOB */
            ortaq.ForEach(vuruq => ebob *= vuruq);

            return ebob;
        }
    }
}