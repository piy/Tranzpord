public class LivingHouse : CityObject
{
    public HouseRuntimeCollection CityHouses;

    public int Residents { get; set; }
    public IntReference DefaultResidents;

    private void OnEnable()
    {
        CityHouses.Add(this);
    }

    private void OnDisable()
    {
        CityHouses.Remove(this);
    }

    private void Start()
    {
        Residents = DefaultResidents;
        //Check for Current Upgrade Level
    }

    //Current Upgrade Level

    //Upgrade

    public override void OnSelected()
    {
        UIManager.House.Show(this);
    }
}
