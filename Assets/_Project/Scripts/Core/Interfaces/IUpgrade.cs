public interface IUpgrade
{
    string Title { get; }
    string Description { get; }
    void Apply();
}