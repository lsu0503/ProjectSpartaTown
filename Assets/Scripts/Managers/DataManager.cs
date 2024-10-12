public class DataManager
{
    private static DataManager instance;

    public Character playerTemp;

    public static DataManager Instance()
    {
        if(instance == null)
            instance = new DataManager();
        
        return instance;
    }

    public DataManager()
    {
        playerTemp = new Character();
        playerTemp.name = "Temporary";
        playerTemp.avatar = DataDictionary.Instance().GetAvartar(1);
        playerTemp.colorIndex = 1;
        playerTemp.avatarColor = DataDictionary.Instance().GetColor(1);
    }
}