using System.Text;

using (StreamReader inFile = new StreamReader("C://Users/prdb/Desktop/ConsoleApp2/input.txt"))
using (StreamWriter outFile = new StreamWriter("C://Users/prdb/Desktop/ConsoleApp2/output.txt"))
{
    int n, k;
    var firstLine = inFile.ReadLine().Split(' ');
    n = int.Parse(firstLine[0]);
    k = int.Parse(firstLine[1]);

    outFile.Write(n + "=");

    StringBuilder ss = new StringBuilder();

    ss.Append(n / k + ".");

    n %= k;

    for (int i = 0; i <= 3 * k; i++)
    {
        n *= 10;
        ss.Append(n / k);
        n %= k;
    }
    string div = ss.ToString();
    bool wasOutput = false;

    for (char c = '9'; c >= '1'; c--)
    {
        StringBuilder cur = new StringBuilder();
        bool onlyZero = true;

        for (int i = 0; i < div.Length; i++)
        {
            if (div[i] == '.') cur.Append('.');
            else if (div[i] < c) cur.Append('0');
            else
            {
                cur.Append((char)('0' + k));
                onlyZero = false;
            }
        }
        if (onlyZero) continue;
        int period = -1;

        for (int p = k; p >= 1; p--)
            if (cur.ToString().Substring(cur.Length - k, k) == cur.ToString().Substring(cur.Length - p - k, k))
                period = p;

        while (cur[cur.Length - period - 1] == cur[cur.Length - 1])
        {
            cur.Remove(cur.Length - 1, 1);
        }

        while (cur[0] == '0' && cur[1] != '.')
        {
            cur.Remove(0, 1);
        }

        if (period == 1 && cur[cur.Length - 1] == '0')
        {
            cur.Remove(cur.Length - 1, 1);

            if (cur[cur.Length - 1] == '.')
            {
                cur.Remove(cur.Length - 1, 1);
            }
        }
        else
        {
            cur.Insert(cur.Length - period, '(');
            cur.Append(')');
        }

        if (wasOutput) outFile.Write('+');

        outFile.Write(cur.ToString());
        Console.WriteLine(cur.ToString());
        wasOutput = true;
    }
}


