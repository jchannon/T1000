namespace FunctionalCarterProject.Features.NamedDelegatesFilms.Directors
{
    using Models;

    public static class GetDirectorByIdQuery
    {
        public static Director Execute(int id)
        {
            //Do some SQL

            return new Director { Name = "Steven Spielberg" };
        }
    }
}
