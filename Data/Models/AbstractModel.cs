namespace SoundLibrary.Data.Models
{
    // For now, this contains only Id as it is the only common property between all items
    // Ususally, this includes many pther properties that should be in every persisted model by structure
    public abstract class AbstractModel
    {
        public int Id { get; set; }
    }
}
