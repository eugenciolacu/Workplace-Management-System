namespace WMS.Data.RequestFeatures
{
    public class FloorParameters : RequestParameters
    {
        public uint MinCapacity { get; set; }
        public uint MaxCapacity { get; set; } = int.MaxValue;

        public bool ValidCapacityRange => MaxCapacity > MinCapacity;

        public string SearchTerm { get; set; } = null!;
    }
}
