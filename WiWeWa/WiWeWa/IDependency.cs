namespace WiWeWa
{
    public interface IDependency
    {
        string GetWisoDataBasePath();
        string GetSaveDatabasePath();
        void MakeToast(string message);
    }
}
