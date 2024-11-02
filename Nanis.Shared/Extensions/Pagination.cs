namespace Nanis.Shared.Extensions
{
    public class Pagination
    {
        public Pagination(int page, int take)
        {
            Page = page;
            Take = take;
        }

        public int Page { get;}
        public int Take { get;}
    }
}
