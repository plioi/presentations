namespace FixieDemo.Example2_xUnit
{
    public interface IUseFixture<T> where T : new()
    {
        void SetFixture(T data);
    }
}