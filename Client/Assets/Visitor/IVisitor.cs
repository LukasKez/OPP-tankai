
namespace Client
{
    public interface IVisitor
    {
        void Visit(Field field);
        void Visit(Forest forest);
        void Visit(Cave cave);
        void Visit(Desert desert);
    }
}
