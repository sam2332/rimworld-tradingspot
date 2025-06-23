# [PL] Trading Spot - RimWorld Mod

A RimWorld mod that adds a Trading Spot building to designate where traders and visitors will gather when visiting your colony.

## Overview

The Trading Spot mod allows you to control where trading caravans and visitors will set up when they arrive at your colony. Simply place a Trading Spot building anywhere on your map, and incoming traders will automatically move to that location instead of randomly choosing a spot near your colony's edge.

## Features

- **Single Trading Spot per Map**: Only one trading spot can be active per map at a time
- **Automatic Trader Redirection**: Traders and caravans automatically move to the designated trading spot
- **Visitor Support**: Optional setting to make visitors also go to the trading spot (if Hospitality mod is not installed)
- **Configurable Settings**: Mod settings to customize behavior
- **Multi-language Support**: Translated into 10+ languages
- **Harmony Integration**: Uses Harmony library for safe game modification

## Installation

1. **Steam Workshop** (Recommended):
   - Subscribe to the mod on Steam Workshop
   - The mod will be automatically downloaded and installed

2. **Manual Installation**:
   - Download the mod files
   - Extract to your RimWorld mods folder: `C:\Program Files (x86)\Steam\steamapps\common\RimWorld\Mods\`
   - Enable the mod in RimWorld's mod settings

## Requirements

- **RimWorld**: Compatible with versions 1.0, 1.1, 1.2, 1.3, and 1.5
- **Harmony**: Required dependency (automatically handled if using Steam Workshop)

## How to Use

1. **Research**: No research required
2. **Build**: Go to Architect → Misc → Trading Spot
3. **Place**: Select a location where you want traders to gather
4. **Wait**: Incoming traders will automatically move to your designated spot

### Settings

Access mod settings through Options → Mod Settings → Trading Spot:

- **Visitors go to Trading Spot**: Makes visitors (not just traders) also go to the trading spot
- **Requires Work To Place**: Toggle whether placing the trading spot requires work time

## Technical Details

### Building Properties
- **Category**: Miscellaneous
- **Work to Build**: 10 (configurable)
- **Materials**: No materials required
- **Size**: 1x1 tile
- **Hotkey**: Misc12

### Mod Components

- **TradingSpot.cs**: Main building class that handles trader redirection logic
- **Settings.cs**: Mod settings and configuration system
- **Buildings_Production_TradingSpot.xml**: Building definition and properties

### Compatibility

- **Hospitality Mod**: Automatically detected and integrated
- **Other Mods**: Generally compatible with most mods
- **Save Games**: Safe to add to existing saves

## Supported Languages

The mod includes translations for:
- English
- Chinese (Simplified & Traditional)
- Japanese
- German
- Russian
- French
- Spanish
- Spanish (Latin)
- Korean
- Polish

## Development

### Building from Source

The mod includes a build script (`compile_mod.bat`) for developers:

```batch
# Compiles the C# source code into the mod DLL
compile_mod.bat
```

**Requirements for building**:
- .NET Framework 4.0
- RimWorld installation
- Harmony library

### Project Structure

```
rimworld-tradingspot/
├── About/                    # Mod metadata and description
├── Assemblies/              # Compiled mod DLL
├── Defs/                    # Game definition files
├── Languages/               # Localization files
├── Source/                  # C# source code
└── compile_mod.bat          # Build script
```

## Credits

- **Current Maintainer**: Programmer-Lily
- **Original Author**: Kiame Vivacity
- **Harmony Library**: Maintained by Andreas Pardeike

### Translators
- **Vaniat**: Chinese Simplified and Traditional
- **Proxyer**: Japanese
- **Ɲơɴɑɱɛ**: German
- **Gidreess**: Russian
- **Boundir**: French
- **Xion**: Spanish

## Support

- **GitHub**: [https://github.com/sam2332/rimworld-tradingspot](https://github.com/sam2332/rimworld-tradingspot)
- **Steam Workshop**: Available on RimWorld Steam Workshop
- **Issues**: Report bugs and issues on the GitHub repository

## License

This mod is open source. Check the repository for specific license details.

## Changelog

The mod supports multiple RimWorld versions and receives regular updates for compatibility and bug fixes. Check the Steam Workshop page or GitHub repository for detailed changelog information.

---

*This mod enhances your RimWorld trading experience by giving you control over where commerce happens in your colony!*
