<Query Kind="Program">
  <Namespace>Microsoft.AspNetCore.Mvc</Namespace>
  <Namespace>Microsoft.Extensions.Configuration</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
  <Namespace>Microsoft.Extensions.Hosting</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Json</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <IncludeAspNet>true</IncludeAspNet>
</Query>

int[] inputs = new[] { 1974, 1773, 1841, 1932, 1951, 1852, 2000, 1988, 1998, 1670, 969, 2008, 1713, 2007, 1916, 1286, 1652, 1821, 1730, 2002, 1761, 1656, 814, 1999, 2010, 1936, 1794, 1905, 1250, 1920, 1986, 1709, 1914, 1681, 1820, 1982, 1961, 1931, 1331, 1923, 1972, 1631, 1643, 1719, 1926, 1994, 1952, 1981, 1847, 1774, 1296, 1946, 873, 2005, 173, 2006, 1960, 1872, 1894, 1695, 1769, 1800, 1734, 1675, 1860, 1383, 1947, 1768, 1827, 1877, 1721, 1738, 384, 1996, 1958, 1909, 1639, 1831, 1212, 1627, 1699, 1661, 1653, 1748, 1919, 1983, 1223, 1690, 1948, 1218, 1971, 1969, 1753, 1957, 1977, 1943, 1978, 1778, 1937, 1868, 1641, 1979, 1854, 1959, 1739, 2004, 1964, 760, 1890, 1701, 1940, 1840, 1817, 1966, 1799, 1941, 1934, 1929, 1962, 1691, 1927, 1764, 1945, 795, 1993, 1804, 1693, 1970, 1728, 1818, 1545, 1992, 1965, 1786, 2009, 1980, 1698, 1647, 1935, 1880, 1921, 1904, 1953, 1871, 1671, 1826, 1989, 1950, 1791, 1990, 1949, 1301, 1975, 1968, 1895, 1208, 1424, 1985, 1665, 1685, 1942, 1669, 64, 1832, 1995, 1987, 1955, 352, 1984, 1925, 1891, 1933, 1679, 2001, 1930, 1991, 1227, 1973, 1723, 1683, 132, 1718, 1944, 1908, 1900, 1657, 1954, 92, 1997, 1938, 1976, 1747, 1226, 1782, 1963, 1746, 1540, 1759, 1939, 1743 };

void Main() // To run press F5. To run Main1 press ALT+SHIFT+1
{   
    // find the two numbers (x, y) that add up to 2020 (x + y = 2020) and return their product (x * y)
    var discontinue = false;
    foreach(var i in inputs)
    {
        if (discontinue) break;
        foreach(var j in inputs)
        {
            if (i + j == 2020)
            {
                $"{i} * {j} = {i*j}".Dump("Two numbers using Foreach");
                discontinue = true;
                break;
            }
        }
    }
     
    var x = inputs.First(i => inputs.Any(j => i + j == 2020));
    $"{x} * {2020 - x} = {x * (2020-x)}".Dump("Two numbers using Linq");
    Main1();
}

void Main1() //ALT+SHIFT+2
{
    var discontinue = false;
    foreach (var i in inputs)
    {
        if (discontinue) break;
        foreach (var j in inputs)
        {
            if (discontinue) break;
            foreach (var k in inputs)
            {
                if (i + j + k == 2020)
                {
                    $"{i} * {j} * {k} = {i * j * k}".Dump("Three numbers using Foreach");
                    discontinue = true;
                    break;
                }
            }
        }
    }

    //inputs.Count().Dump("Total items");
    Math.Pow(inputs.Count(), 3).Dump("Count of pairs");
    (from a in inputs
    from b in inputs
    from c in inputs
    select new[] {a,b,c})
        .First(m => m.Sum() == 2020)
        .Aggregate((x, y) => x * y)
        .Dump("Three numbers using Linq");
    
    Main2();
}

void Main2()
{
    var arr = inputs;
    var layer = 3;

    arr
        .SelectMany(a => arr.Select(ar => layer > 1 ? new[] { a, ar } : new[] {a}) ) //create array by adding the next value
        .SelectMany(a => arr.Select(ar => layer > 2 ? a.Append(ar) : a)) //add element to the array
        .First(a => a.Sum() == 2020) // check the sum of all the elements of the array meets criteria
        .Aggregate((x, y) => x * y) // multiply each element
    .Dump();

}

void Main3()
{
    var arr = new[] { 1, 2, 3 };
    Math.Pow(arr.Count(), 3).Dump("Count of pairs");
    //Enumerable
    //    .Range(1, 2)
    //    .Aggregate( arr.Select(a => new[] { a }), (x, y) => x.SelectMany(i => arr.Select(a => i.Append(a))). )  
        //x.SelectMany(i => arr.Select(a => x.Append(i))))
        //.SelectMany(e => arr.Select(i => new[] {i}))
        //.Dump();
}


void Main4() 
{
    var arr = new[] { 1, 2, 3, 4 };
    var arrs = arr.Select(a => new[] {a});
    
    var aaaa = arrs.Select(a => arr.Select(ar => a.Append(ar)));
    
    //Enumerable.Range
    
    aaaa.Dump();
      //arrs.SelectMany(a => arr.Select(ar => a.Append(ar))).Dump();
}




