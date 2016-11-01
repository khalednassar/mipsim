namespace mipsim
{
    public interface JumpableInstruction
    {
        uint Target { get; }
        string TargetAddressLabel { get; set; }
    }
}
