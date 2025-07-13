enum Architecture : ushort
{
    Unknown = 0x0,
    I386 = 0x014c, // 32-bit
    Intel64 = 0x020, // Intel 64
    Amd64 = 0x8664, // 64-bit
    Arm64 = 0xAA64 // 64-bit ARM
    
    // There are others here omitted for brevity
}