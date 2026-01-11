List<int> ints = new List<int> { 5, 2, 4, 6, 1, 3 };
List<int> result = new List<int>();

int i = 0;

int key = 0;
for (int j = 1; j < ints.Count; j++)
{
	key = ints[j];
    i = j - 1;
	while (i>=0 && ints[i]>key)
	{
		ints[i+1] = ints[i];
        i--;
    }
    ints[i + 1] = key;//=========onemli
}
ints.ForEach(result.Add);
Console.WriteLine(string.Join(", ", result));