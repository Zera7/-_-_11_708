using System;
using System.Text;

namespace hashes
{
    public class GhostsTask :
        IFactory<Document>, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>,
        IMagic
    {
        public GhostsTask()
        {
            segment = new Segment(vec, vec);
            doc = new Document("zadanie", Encoding.Unicode, a);
        }

        byte[] a = { 5, 2, 3 };
        Vector vec = new Vector(10, 12);

        Animal animal = new Animal("oOprosto", DateTime.Now);
        Cat cat = new Cat("o_o", "Oo", DateTime.Now);

        Robot robot = new Robot("klass", 456);
        Segment segment;
        Document doc;

        public Document Create()
        {
            return doc;
        }

        public void DoMagic()
		{
            vec.Add(vec);
            a[0] = 23;
            Robot.BatteryCapacity++;
            cat.Rename("(net)");
            animal.Rename("fgdjd");
        }

		// Чтобы класс одновременно реализовывал интерфейсы IFactory<A> и IFactory<B> 
		// придется воспользоваться так называемой явной реализацией интерфейса.
		// Чтобы отличать методы создания A и B у каждого метода Create нужно явно указать, к какому интерфейсу он относится.
		// На самом деле такое вы уже видели, когда реализовывали IEnumerable<T>.

		Vector IFactory<Vector>.Create()
		{
            return vec;
		}

		Segment IFactory<Segment>.Create()
		{
            return segment;
		}

        Cat IFactory<Cat>.Create()
        {
            return cat;
        }

        Robot IFactory<Robot>.Create()
        {
            return robot;
        }

        // И так даллее по аналогии...
    }
}