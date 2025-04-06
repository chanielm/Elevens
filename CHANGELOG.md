# Changelog

## 4/6/2025
### Added
- Messages for when the program is first opened and terminated
- User can now terminate the game at any point by entering 'E'
### Changed
- Console output improvements, less clutter

## 3/31/2025
### Added
- Visual Improvements, now makes use of console color
### Changed
- Moved game flow to ElevensGame, rather than in a separate program file.

## 3/27/2025
### Added
- Added restart functionality
### Changed
- Changed the method cards are selected
- Changed the method cards are displayed on the table

## 3/20/2025
### Added
- All 'ElevensGame' methods implemented
### Changed
- Changed how cards are displayed visually (using numbers and icons instead of words)
- Fixed issue where incorrect cards would be replaced if card indices were selected in any order but ascending

## 3/7/2025
### Added
- Implemented 'Suit' and 'Rank' enums
- Implemented 'Card' class
- Implemented 'Deck' class
- Partially implemented 'ElevensGame' class
  - Constructor
  - ValidateFaceCards
  - ValidateEleven