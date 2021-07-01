#nullable enable
using System;
using System.Linq;
using System.Text;

namespace YearsDesignatedByHeavenlyStemsAndEarthlyBranches
{
    class Program
    {
        /// <summary>
        /// 天干
        /// </summary>
        private static readonly char[] HeavenlyStems = { '庚', '辛', '壬', '癸', '甲', '乙', '丙', '丁', '戊', '己', };
        /// <summary>
        /// 地支
        /// </summary>
        private static readonly char[] Dizhi = { '申', '酉', '戌', '亥', '子', '丑', '寅', '卯', '辰', '巳', '午', '未', };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("请选择转换方式:");
                Console.WriteLine("1.YearToNumber");
                Console.WriteLine("2.NumberToYear:");
                string? select = Console.ReadLine();
                Console.Clear();
                switch (select)
                {
                    case "1":
                        {
                            Console.WriteLine("请输入转换为数字年的干支纪年:");
                            string? year = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(year)
                                && year.Length == 2
                                && HeavenlyStems.Any(h => h == year[0])
                                && Dizhi.Any(d => d == year[1]))
                            {
                                Console.WriteLine(YearToNumber(year));
                                Console.ReadKey();
                                continue;
                            }

                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("请输入转换为干支纪年的数字年:");
                            string? number = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(number)
                                && number.All(char.IsDigit))
                            {
                                var numberToYear = NumberToYear(number);
                                Console.WriteLine($"{number}转换为{numberToYear}年");
                                Console.ReadKey();
                                continue;
                            }

                            break;
                        }
                }
                Console.WriteLine("输入不正确");
            }
        }
        /// <summary>
        /// 干支纪年转数字年
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        static string YearToNumber(string year)
        {
            var heavenlyStems = Array.IndexOf(HeavenlyStems, year[0]);
            var diZhi = Array.IndexOf(Dizhi, year[1]);
            var yearToNumber = heavenlyStems * 6 - diZhi * 5;
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < 35; i++)
            {
                stringBuilder.AppendLine($"{year}转换为{yearToNumber + i * 60}年");
            }
            return stringBuilder.ToString();
        }
        /// <summary>
        /// 数字年转干支纪年
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static string NumberToYear(string number)
        {
            var _number = Convert.ToInt32(number);
            var heavenlyStems = (_number + 10) % 10;
            var diZhi = (_number + 12) % 12;
            return $"{HeavenlyStems[heavenlyStems]}{Dizhi[diZhi]}";
        }
    }
}
