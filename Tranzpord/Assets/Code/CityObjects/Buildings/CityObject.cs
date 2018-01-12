using UnityEngine;
using UnityEngine.EventSystems;


public class CityObject : MonoBehaviour, IPointerClickHandler
{
    public SO_UIManager UIManager;

    #region IPointerClickHandler interface
    public void OnPointerClick(PointerEventData eventData)
    {
        OnSelected();
    }
    #endregion

    public virtual void OnSelected()
    {

    }
}
