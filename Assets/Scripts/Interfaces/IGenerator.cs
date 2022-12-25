namespace BusinessSimulator
{
    public interface IGenerator<T>
    {
        public T Result { get; }

        public void Generate();
    }
}
