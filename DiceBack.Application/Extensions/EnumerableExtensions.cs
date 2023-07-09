namespace DiceBack.Application.Extensions
{
    public static class EnumerableExtensions
    {
        public static T Random<T>(this IEnumerable<T> enumerable, int minValue)
        {
            var list = enumerable as IList<T> ?? enumerable.ToList();

            return list.ElementAt(new Random().Next(minValue, maxValue: list.Count));
        }
    }
}
