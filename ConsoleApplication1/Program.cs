using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> carList = new List<ConsoleApplication1.Car>();
            Car car = new Car();
            car.Name = "奔驰";
            car.CarType = "商务车";

            carList.Add(car);


            car = new Car();
            car.Name = "兰博基尼";
            car.CarType = "跑车";

            carList.Add(car);

            foreach (var item in carList)
            {
                Console.WriteLine("名称:{0},类型:{1}", item.Name, item.CarType);

            }
            Console.ReadKey();



        }
    }
}
