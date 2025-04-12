using UnityEngine;

public enum ItemType
{
    Tire,
    CarChassis,
    Engine,
    CarDoor,
    PlaneWings,
    Turbine,
    BikeChassis,
    Wheel,
    Car,       // final product
    Plane,
    Bike
}

public class ConveyorItem : MonoBehaviour
{
    public ItemType itemType;
}
