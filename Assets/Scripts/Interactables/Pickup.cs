/// <summary>
/// Attach this to an object to allow player
/// to pick it up.
/// </summary>
public class Pickup : Interactable
{
    public override void Interact()
    {
        base.Interact();

        // TODO: functionality go here

        Destroy(this.gameObject);
    }
}
