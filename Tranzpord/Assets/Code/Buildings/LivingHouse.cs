using UnityEngine;
using UnityEngine.EventSystems;

public class LivingHouse : MonoBehaviour, IPointerClickHandler
{

    public HouseRuntimeCollection CityHouses;
    public SO_UIManager UIManager;

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


    #region IPointerClickHandler interface
    public void OnPointerClick(PointerEventData eventData)
    {
        UIManager.HQ.Show();
    }
    #endregion

    //testO
//    public void OnMouseDown()
//    {
//        UIManager.HQ.Show();
//    }
}
