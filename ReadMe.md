Here's the documentation for your `HardwareKey` class, inspired by the `Mtf.Serial` documentation format:

---

# Mtf.HardwareKey Library Documentation

## Overview

The `Mtf.HardwareKey` library provides the `HardwareKey` class, designed for interacting with hardware keys for licensing and security. It includes methods for reading and writing data, handling bitwise operations, and checking memory status. This document covers installation, properties, methods, events, and usage examples for integrating with hardware keys in .NET applications.

## Installation

To use `Mtf.HardwareKey`, add the package to your project:

1. **Add Package**:
   Run the following in your project directory:

   ```bash
   dotnet add package Mtf.HardwareKey
   ```

2. **Include the Namespace**:
   Add the `Mtf.HardwareKey` namespace at the beginning of your code:

   ```csharp
   using Mtf.HardwareKey;
   ```

## Class: HardwareKey

The `HardwareKey` class manages hardware key interactions, including read and write operations on specific memory addresses and bit manipulation. This class supports initialization with developer details and hardware key configurations.

### Constructor

**`HardwareKey(HardwareKeyDeveloper developerId, ushort hardwareKeyIndex, string contactServer)`**

- **Parameters**:
  - `developerId`: Identifies the developer for hardware key configuration.
  - `hardwareKeyIndex`: Index of the hardware key to target.
  - `contactServer`: Server contact details for accessing the hardware key's API.

### Properties

| Property              | Type                   | Description                                                       |
|-----------------------|------------------------|-------------------------------------------------------------------|
| `ApiPacket`           | `ulong[]`              | Packet used for API communication with the hardware key.          |
| `HardwareKeyIndex`    | `ushort`               | Index of the selected hardware key.                               |
| `DeveloperId`         | `HardwareKeyDeveloper` | Developer-specific ID used for hardware key access.               |

### Methods

#### Connection and Disposal

- **`Dispose()`**  
  Disposes of the hardware key and releases resources. Called automatically on object destruction.

#### Data Read and Write

- **`ushort ReadCellValue(MemoryAddress address)`**  
  Reads a cell value from a specified memory address.

- **`void WriteCellValue(MemoryAddress address, ushort data, SentinelSuperProAccessCode accessCode = SentinelSuperProAccessCode.ReadWrite)`**  
  Writes a cell value to a specified address with optional access code.

- **`bool CanReadFrom(MemoryAddress address)`**  
  Checks if the hardware key can read data from the specified address.

- **`void OverwriteCellValue(MemoryAddress address, ushort data)`**  
  Attempts to overwrite the value at a memory address.

#### Bitwise Operations

- **`byte ReadByte(MemoryAddress address, ByteType type)`**  
  Reads a specific byte (higher or lower) from a word at a memory address.

- **`void WriteBit(MemoryAddress address, Bit bit, bool bitValue)`**  
  Writes a bit value to a specific bit at a memory address.

#### Utility Methods

- **`string ReadCellValueWithNoException(MemoryAddress address)`**  
  Attempts to read a cell value from a memory address, returning status code as a string if an error occurs.

- **`bool IsOverwriteSucceededOrHasDataAlreadyInAddress(MemoryAddress address, ushort data)`**  
  Checks if the overwrite was successful or if the address already contains the specified data.

- **`ushort GetMemoryAddressStoredValue(MemoryDataType memoryDataType)`**  
  Retrieves stored memory address data based on the developer's configuration.

- **`BitMemoryAddress GetBitMemoryAddress(BitMemoryDataType bitMemoryDataType)`**  
  Retrieves the bit memory address for specified bit data.

### Example Usage

```csharp
using Mtf.HardwareKey;
using Mtf.HardwareKey.Enums;
using System;

public class HardwareKeyExample
{
    public void Example()
    {
        // Initialize HardwareKey with developer ID and server details
        var hardwareKey = new HardwareKey(HardwareKeyDeveloper.YourDeveloperId, 0, "yourContactServer");

        // Read and write cell values
        var address = new MemoryAddress(0x01);
        ushort cellValue = hardwareKey.ReadCellValue(address);
        Console.WriteLine($"Read cell value: {cellValue}");

        hardwareKey.WriteCellValue(address, 1234);
        Console.WriteLine($"New cell value written.");

        // Perform a bitwise operation
        hardwareKey.WriteBit(address, Bit.Bit7, true);

        // Dispose of the hardware key instance
        hardwareKey.Dispose();
    }
}
```

### Notes

- **Exception Handling**: Ensure exception handling for errors during API communication and hardware access.
- **Dispose**: Always dispose of the `HardwareKey` instance to free up resources.
- **Bitwise Operations**: Use bitwise methods to manipulate specific bits if required by your application logic.

--- 

Let me know if you’d like additional examples or details on any specific method.