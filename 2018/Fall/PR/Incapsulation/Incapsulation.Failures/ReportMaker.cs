using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Failures
{
    public class ReportMaker
    {
        //My code
        private static Dictionary<int, Device> devicesD = new Dictionary<int, Device>();

        // Старый метод
        public static List<string> FindDevicesFailedBeforeDateObsolete(
            int day,
            int month,
            int year,
            int[] failureTypes,
            int[] deviceId,
            object[][] times,
            List<Dictionary<string, object>> devices)
        {
            var failures = new List<Failure>();
            var index = 0;

            var timesCount = times.GetLength(0);

            // Заполнение словаря устройств
            foreach (var item in devices)
            {
                if (!item.ContainsKey("DeviceId") || 
                    !item.ContainsKey("Name") || 
                    devicesD.ContainsKey((int)item["DeviceId"]))
                    break;
                var device = new Device((int)item["DeviceId"], (string)item["Name"]);
                   devicesD.Add(device.DeviceId, device);
            }

            // Создание списка ошибок
            foreach (var item in failureTypes)
            {
                if (index >= failureTypes.Count() || index >= deviceId.Count() ||
                    index >= timesCount || times[index].Count() != 3)
                    break;
                failures.Add(
                    new Failure((Failure.FailureType)failureTypes[index], 
                    deviceId[index], 
                    new DateTime((int)times[index][2], 
                    (int)times[index][1], (int)times[index][0])));
                index++;
            }
            return FindDevicesFailedBeforeDate(new DateTime(year,month,day),failures.ToList());
        }

        public struct Device
        {
            public int DeviceId { get; set; }
            public string Name { get; set; }

            public Device(int deviceId, string name)
            {
                this.Name = name;
                this.DeviceId = deviceId;
            }
            //public override int GetHashCode()
            //{
            //    return DeviceId;
            //}
            //public override bool Equals(object obj)
            //{
            //    return ((Device)obj).DeviceId == DeviceId && ((Device)obj).Name == Name ? true : false;
            //}
        }
        public class Failure
        {
            public FailureType Type { get; set; }
            public int DeviceId { get; set; }
            public DateTime Date { get; set; }

            public Failure(FailureType failureType, int deviceId, DateTime date) {
                this.Type = failureType;
                this.DeviceId = deviceId;
                this.Date = date;
            }

            public enum FailureType
            {
                UnexpectedShutdown,
                ShortNonResponding,
                HardwareFailure,
                ConnectionProblems,
            }

            public bool IsFailureSerious()
            {
                return ((int)Type % 2 == 0);
            }
            /// <summary>
            /// Проверяет, произошла ли ошибка в указанный период времени
            /// </summary>
            /// <param name="date">Дата от которой ведется отсчет</param>
            /// <param name="backOn">Указывает на сколько времени назад учитывать ошибки</param>
            /// <returns></returns>
            public bool IsEarlierFor(DateTime date, TimeSpan backOn)
            {
                if (date.CompareTo(Date) < 0)
                    return false;
                return (date - Date).CompareTo(backOn) <= 0 ? true : false;
            }
        }

        /// <summary>
        /// Ищет ошибки от указанной даты за указанный период времени (по умолчанию = 31 день)
        /// </summary>
        /// <param name="date">Дата отсчета</param>
        /// <param name="failures">Массив ошибок</param>
        /// <param name="backOn">Период времени</param>
        /// <returns>Список названий попадающих под условия девайсов</returns>
        public static List<string> FindDevicesFailedBeforeDate(DateTime date, List<Failure> failures, TimeSpan? backOn = null)
        {
            if (backOn == null)
                backOn = new TimeSpan(31, 0, 0, 0);

            var result = failures
                .Where(a => a.IsEarlierFor(date, (TimeSpan)backOn) && a.IsFailureSerious())
                .Select(a => devicesD[a.DeviceId].Name)
                .ToList();

            devicesD.Clear();
            return result;
        }
        // My code end
    }
}
