namespace PPC.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity) : base($"{entity} couldn't be found!") { }
    }
}
