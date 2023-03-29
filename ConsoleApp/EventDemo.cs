using ConsoleApp;

void c_ThresholdReached(object sender, EventArgs e)
{
    Console.WriteLine("The threshold was reached.");
    Environment.Exit(0);
}

Counter c = new Counter(2);
c.ThresholdReached += c_ThresholdReached;


Console.WriteLine("press 'a' key to increase total");

while (Console.ReadKey(true).KeyChar == 'a')
{
    Console.WriteLine("adding one");
    c.Add(1);
}
