class Program
{
    /*
    class pump
    {
        public int id;
        public long petrol;
        public long distonextpump;

        public pump(int i, long p, long d)
        {
            id = i;
            petrol = p;
            distonextpump = d;
        }
    }



    static bool isPath(Queue<pump> path, int startingpump, long tank)
    {
        if (tank < 0) return false;
        pump currentpump = path.Dequeue();
        if (currentpump.id == startingpump && currentpump.petrol == 0) return true;
        else
        {
            tank += currentpump.petrol;
            currentpump.petrol = 0;
            path.Enqueue(currentpump);
            return isPath(path, startingpump, tank);
        }
    }
//Main
    int n = int.Parse(Console.ReadLine());
    var circle = new Queue<pump>();
            for(int i=0; i<n; i++)
            {
                long[] data = Console.ReadLine().Split().Select(long.Parse).ToArray();
    circle.Enqueue(new pump(i, data[0], data[1]));
            }

bool pathfound = false;
            for(int i=0; i<n&&!pathfound; i++)
            {
                Queue<pump> test = new Queue<pump>(circle);
int startingpump = i;
                while (!pathfound)
                {
                    startingpump = test.Peek().id;
                    pathfound = isPath(test, test.Peek().id, 0);
pump move = test.Dequeue();
test.Enqueue(move);
                }
                if (pathfound) Console.WriteLine(startingpump);
            }



    */
}