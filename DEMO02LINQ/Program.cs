
using DEMO02LINQ;
using System.Diagnostics.CodeAnalysis;

namespace DEMO02LIN
{

    class ProductComparer : IComparer<Product>
    {
        public int Compare(Product? x, Product? y)
        {
            return x.UnitPrice.CompareTo(y.UnitPrice);
        }
    }


    class CustomProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product? x, Product? y)
        {
            return x.UnitPrice == y.UnitPrice &&
                x.UnitsInStock == y.UnitsInStock &&
                x.ProductID == y.ProductID &&
                x.ProductName == y.ProductName &&
                x.Category == y.Category;
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return HashCode.Combine(obj.ProductID, obj.ProductName, obj.UnitsInStock, obj.UnitPrice, obj.Category);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ EXecution 

            // Differed Ex 
            // Immediate Ex {Conversion  ,Element  , Aggregate} operators 
            //var lst = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };


            //var query = lst.Where(x => x > 5).ToList(); //6,7

            //lst.AddRange([8, 9, 10]);
            //lst.Remove(7);
            //Console.WriteLine("First Enumeration ");

            //foreach (var item in query)
            //{
            //    Console.Write($"{item} ,");
            //}
            //Console.WriteLine();
            //lst.AddRange([11, 12, 13]);
            //lst.Remove(9);
            //Console.WriteLine("Second Enumeration ");
            //foreach (var item in query)
            //{
            //    Console.Write($"{item} ,");
            //}
            #endregion


            #region Ordering Operators  [order by  , then by ,Asc , Desc ]


            //var query = ProductList.OrderByDescending(product => product.UnitsInStock).ThenByDescending(p => p.UnitPrice);

            //var query = from product in ProductList
            //            orderby product.UnitsInStock descending, product.UnitPrice descending
            //            select product;
            #endregion

            #region Element Operators => Immediate Execution
            //[First , Last]
            // Returns the First or Last Element in the input sequence if exists otherwise throws Exception 

            //[First(Func) , Last(Func)]
            // Returns the First or Last Element in the input sequence that matches the Delegate if exists otherwise throws Exception 
            //var lst = new List<int>() { 1, 3 };
            //var result = ProductList.First(p => p.UnitsInStock == 1000);


            //[FirstOrDefault , LastOrDefault ]
            // Returns the First or Last Element in the input sequence if exists otherwise returns the default value for the sequence type 

            //var result = lst.FirstOrDefault(x => x == 3, 5);


            //[ElementAt , ElementAtOrDefault ]

            //var result = ProductList.ElementAtOrDefault(100);



            //[Single ]
            // Single  returns the only Element in the sequence and throws exception if the sequence is empty or contains more than one element
            //Single(Func) returns the element that matches the FUNC and throws exception if 
            // Sequence contains more than one matching element or Sequence contains no matching element
            //var result = ProductList.Single(p => p.ProductID == 1);


            //SingleOrDefault   returns the only Element in the sequence and throws exception if the sequence contains more than one element
            // returns the default value if the sequence is empty 

            //var result = lst.SingleOrDefault();



            //SingleOrDefault(FUnc) => the default value if there is no matching element 
            // throws exception if there is more than one matching element 
            // returns the default value if the sequence is empty 
            //var result = lst.SingleOrDefault(x => x == 2);


            //var result = lst.SingleOrDefault(x => x == 2, 5);

            #endregion

            #region Aggregate Operators  => Immediate Execution

            //{Count , Max  , Min  , MaxBy , MinBy , Sum , Avg , Aggregate  }
            //var result = ProductList.Count(p => p.UnitsInStock == 0);

            //var result = ProductList.Min(new ProductComparer());


            //var result = ProductList.Max((p) => p.UnitPrice);

            //var result = ProductList.MinBy((p) => p.UnitPrice);.

            //var result = ProductList.Sum(p => p.UnitsInStock);

            //var result = ProductList.Average(p => p.UnitsInStock);

            //var names = new List<string> { "Omar", "Amr", "Ahmed", "Osama" };

            //var result = names.Aggregate((acc, name) => $"{acc} {name}");
            //var result = names.Aggregate("Mohammad", (acc, name) => $"{acc} {name}");
            //var result = names.Aggregate("Mohammad", (acc, name) => $"{acc} {name}", s => s.Length);
            #endregion

            #region Conversion Operators  => Immediate Execution
            //var products = ProductList.Where(p => p.UnitsInStock > 0).ToArray();
            //var products = ProductList.Where(p => p.UnitsInStock > 0).ToList();
            //var products = ProductList.Where(p => p.UnitsInStock > 0).ToDictionary(p => p.ProductID, (product) => new { product.ProductName, product.UnitPrice });

            //var products = ProductList.Where(p => p.UnitsInStock > 0).ToHashSet(new CustomProductComparer());

            //Console.WriteLine(products.Count());

            //Console.WriteLine(products[0]);
            #endregion

            #region Generator Operators 


            //var range = Enumerable.Range(0, 120);


            //var repeat = Enumerable.Repeat("$", 20);

            //var empty = Enumerable.Empty<int>();
            #endregion

            #region Set Operators 
            //{Union , UnionBy, Concat ,Distinct ,DistinctBy, intersect ,intersectBy , except,exceptBy}
            //var seq1 = Enumerable.Range(0, 100);
            //var seq2 = Enumerable.Range(50, 100);

            //var query = seq1.Union(seq2);


            //var query = ProductList.Union(ProductListV2, new CustomProductComparer());

            //var query = seq1.Concat(seq2);

            //var query = ProductList.Distinct(new CustomProductComparer());

            //var query = seq1.Intersect(seq2);

            //var query = seq2.Except(seq1);
            //var query = ProductList.DistinctBy((p) => p.UnitsInStock);
            #endregion

            #region Quantifiers Operators 

            //var range = Enumerable.Empty<Product>();
            //Console.WriteLine(range.Any());
            //Console.WriteLine(range.Any(p => p.UnitsInStock == 1000));

            //Console.WriteLine(ProductList.All(p => p.UnitPrice > 0));


            //var seq1 = Enumerable.Range(0, 100);
            //var seq2 = Enumerable.Range(0, 100);

            //Console.WriteLine(seq1.SequenceEqual(seq2));
            #endregion

            //foreach (var item in query)
            //{
            //    Console.Write($"{item},");
            //}
            //Console.WriteLine();
            //Console.WriteLine($"Sequence Count = {query.Count()}");
            Console.ReadKey();
        }
    }
}
