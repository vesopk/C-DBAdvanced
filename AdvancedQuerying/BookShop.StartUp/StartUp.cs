using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BookShop.Data;
using BookShop.Models;

namespace BookShop.StartUp
{
    
    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                var result = RemoveBooks(db);
                Console.WriteLine($"{result} books were deleted");
            }
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var enumValue = -1;
            switch (command.ToLower())
            {
                case "minor": enumValue = 0; break;
                case "teen": enumValue = 1; break;
                case "adult": enumValue = 2; break;
            }
            var titles = context.Books.Where(b => b.AgeRestriction == (AgeRestriction)enumValue)
                .Select(b => b.Title).OrderBy(t => t).ToArray();

            var result = String.Join(Environment.NewLine, titles);
            return result;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(t => t.EditionType == EditionType.Gold && t.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title);

            var result = String.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToList();

            var formatedBooks = new List<string>();

            foreach (var book in books)
            {
                var formatedBook = $"{book.Title} - ${book.Price:F2}";
                formatedBooks.Add(formatedBook);
            }
            var result = String.Join(Environment.NewLine, formatedBooks);

            return result;
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            var result = String.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksByCategory(BookShopContext context,string input)
        {
            var categories = input.ToLower().Split(new []{' '},StringSplitOptions.RemoveEmptyEntries).ToList();

            var books = context.Books.Where(b => b.BookCategories.Select(c => c.Category.Name.ToLower())
                    .Intersect(categories)
                    .Any()).OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            var result = String.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string input)
        {
            string format = "dd-MM-yyyy";
            DateTime date = DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);

            var books = context.Books.Where(b => b.ReleaseDate != null && b.ReleaseDate.Value < date)
                .OrderByDescending(b => b.ReleaseDate.Value)
                .Select(b => new
            {
                b.Title,
                b.EditionType,
                b.Price
            }).ToArray();

            return string.Join(Environment.NewLine, books.Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:F2}"));
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var books = context.Books.Where(b => b.Author.FirstName.EndsWith(input))
                .Select(b => new
                {
                    FullName = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .Distinct()
                .OrderBy(b => b.FullName)
                .ToArray();

            var result = string.Join(Environment.NewLine, books.Select(b => b.FullName));

            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books.Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            var result = string.Join(Environment.NewLine, titles);
            return result;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books.Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    FullName = $"{b.Author.FirstName} {b.Author.LastName}",
                    b.Title
                })
                .ToArray();

            var result = string.Join(Environment.NewLine, books.Select(x => $"{x.Title} ({x.FullName})"));

            return result;
        }

        public static int CountBooks(BookShopContext context,int lengthCheck)
        {
            var booksCount = context.Books.Count(b => b.Title.Length > lengthCheck);
            return booksCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var books = context.Books
                .Select(b => new
                {
                    AuthorName = $"{b.Author.FirstName} {b.Author.LastName}",
                    b.Copies
                })
                .GroupBy(b => b.AuthorName)
                .OrderByDescending(x => x.Sum(b => b.Copies))
                .ToArray();

            return string.Join(Environment.NewLine, books.Select(x => x.Key + " - " + x.Sum(y => y.Copies)));
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(x => x.Book.Copies * x.Book.Price)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name)
                .ToArray();

            return string.Join(Environment.NewLine, categories.Select(x => x.Name + " $" + x.Profit));
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    categoryBooksCount = c.CategoryBooks.Count,
                    CategoryBooks = c.CategoryBooks
                        .OrderByDescending(x => x.Book.ReleaseDate.Value)
                        .Take(3)
                        .Select(y => new
                        {
                            y.Book.Title,
                            y.Book.ReleaseDate.Value.Year
                        })
                })
                .OrderBy(c => c.CategoryName)
                .ToArray();

            return string.Join(Environment.NewLine, categories.Select(x => $"--{x.CategoryName}" + Environment.NewLine + string.Join(Environment.NewLine, x.CategoryBooks.Select(y => $"{y.Title} ({y.Year})"))));
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010).ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }
            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Copies < 4200).ToList();

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return books.Count;
        }
    }
}
